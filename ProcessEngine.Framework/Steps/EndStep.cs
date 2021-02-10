using ProcessEngine.Framework.Interfaces;
using System;

namespace ProcessEngine.Framework.Steps
{

    public abstract class EndStep<D> : StepBase, IEndStep<D>
    {
        public IToken<D> FinalToken { get; protected set; }

        public void ExecuteStep(IToken<D> token)
        {
            try
            {

                PreExecution(token);

                DoStep(token);

                PostExecution(token);

            }
            catch (ProcessException pex)
            {

                Error($"Error on executing end step: {base.Name}", pex);

                ExecutionError(pex);

                throw;
            }
            catch (System.Exception ex)
            {

                Error($"Error on executing end step: {base.Name}", ex);

                ExecutionError(ex);

                throw;
            }
        }

        protected abstract void DoStep(IToken<D> token);

    }

}
