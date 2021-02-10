using ProcessEngine.Framework.Interfaces;
using ProcessEngine.Framework.Utils;
using System;

namespace ProcessEngine.Framework.Steps
{

    public abstract class StepBase : Logger, IStep
    {

        public StepBase()
        {
            OnExecuting += OnEcecutingDefault;
            OnExecuted += OnExecutedgDefault;
            OnError += OnErrorDefault;
        }
        
        public virtual string Name
        {
            get
            {
                return GetType()?.Name;
            }
        }

        public event Action<IStep, IToken> OnExecuting;
        protected void PreExecution(IToken token)
        {
            OnExecuting?.Invoke(this, token);
        }

        protected virtual void OnEcecutingDefault(IStep step, IToken token)
        {
            Debug($"On executing step: {step?.Name} for process: '{token?.ProcessName}'");
        }
        
        public event Action<IStep, IToken> OnExecuted;

        protected void PostExecution(IToken token)
        {
            OnExecuted?.Invoke(this, token);
        }

        protected virtual void OnExecutedgDefault(IStep step, IToken token)
        {
            Debug($"Executed step {step?.Name} for process: '{token?.ProcessName}'");
        }

        public event Action<IStep, Exception> OnError;

        protected void ExecutionError(Exception exception)
        {
            OnError?.Invoke(this, exception);
        }

        protected virtual void OnErrorDefault(IStep step, Exception exception)
        {
            Debug($"Error on executing start step: '{step?.Name}'", exception);
        }
    }

}
