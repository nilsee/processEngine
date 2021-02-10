using ProcessEngine.Framework.Interfaces;
using ProcessEngine.Framework.Steps;
using System;
using System.Collections.Generic;

namespace ProcessEngine.Framework
{

    public abstract class Process<D> : ProcessBase
    {

        // E. g. can the process be re run and still produce identical result?
        private bool _isIdempotent;

        #region process steps
        protected IStartStep<D> StartStep { get; set; }

        private List<IIntermediateStep<D>> _intermediateSteps;

        #region end step setup

        protected IEndStep<D> EndStep { get; set; }

        public IToken<D> Result
        {
            get
            {
                return EndStep?.FinalToken;
            }
        }

        #endregion

        #region error step setup
        protected IErrorStep<D> ErrorStep {get; set;}

        public Action<IToken<D>, ProcessException> StartErrorAction { get; set; }

        public Action<IToken<D>, ProcessException> IntermidiateErrorAction { get; set; }

        public Action<IToken<D>, ProcessException> EndErrorAction { get; set; }
        #endregion

        #endregion

        public Process(bool isIdempotent = false) 
        {

            _intermediateSteps = new List<IIntermediateStep<D>>();

            _isIdempotent = isIdempotent;

            Completed = false;

            ErrorStep = new ErrorStep<D>();

            StartErrorAction = IntermidiateErrorAction = EndErrorAction = (IToken<D> token, ProcessException pex) =>
            {
                Debug($"On Default Error Action For Process: {Name}", pex);
                throw pex;
            };

        }

        public void AddIntermediateStep(IIntermediateStep<D> step)
        {
            if (_intermediateSteps == null)
            {
                _intermediateSteps = new List<IIntermediateStep<D>>();
            }

            _intermediateSteps.Add(step);
        }

        protected override IToken RunProcess()
        {
            if ( ! VerifyProcessSetup() )
            {
                throw new ProcessException($"Process: '{Name}' missing either Start, End or Error step(s).");
            }

            if ( ! _isIdempotent && Completed)
            {
                throw new ProcessException($"Atempting to re-run a non-idempotent process: '{Name}'.");
            }

            IToken<D> token = StartStep.ExecuteStep();

            if (token.Terminate)
            {
                ErrorStep.ExecuteStep(token, new ProcessException(StartStep, token, $"Process terminated in start-up step: '{StartStep?.Name}'."), StartErrorAction);
                return token;
            }

            if (_intermediateSteps != null)
            {
                foreach (var step in _intermediateSteps)
                {
                    token = step.ExecuteStep(token);

                    if (token.Terminate)
                    {
                        ErrorStep.ExecuteStep(token, new ProcessException(StartStep, token, $"Process terminated in intermediate step: '{step?.Name}'."), IntermidiateErrorAction);
                        return token;
                    }
                }
            }
            
            EndStep.ExecuteStep(token);
            
            if (token.Terminate)
            {
                ErrorStep.ExecuteStep(token, new ProcessException(StartStep, token, $"Process terminated in end step: '{EndStep?.Name}'"), EndErrorAction);
                return token;
            }

            Completed = true;

            return token;

        }

        private bool VerifyProcessSetup()
        {
            return StartStep != null && EndStep != null && ErrorStep != null;
        }

    }

}
 