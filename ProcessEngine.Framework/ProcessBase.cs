using System;
using ProcessEngine.Framework.Interfaces;
using ProcessEngine.Framework.Utils;

namespace ProcessEngine.Framework
{

    public abstract class ProcessBase : Logger, IProcess
    {

        public ProcessBase()
        {
            OnExecuting += OnExecutingDefault;
            OnExecuted += OnExecutedDefault;
            OnError += OnErrorDefault;
        }

        public bool Completed
        {
            get;
            protected set;
        }

        public string Name
        {
            get
            {
                return GetType()?.Name;
            }
        }

        public event Action<IProcess> OnExecuting;

        protected void PreExecution()
        {
            OnExecuting?.Invoke(this);
        }

        protected virtual void OnExecutingDefault(IProcess process)
        {
            Debug($"On executing process: {Name}");
        }

        public event Action<IProcess, IToken> OnExecuted;
        protected void PostExecution(IToken token)
        {
            OnExecuted?.Invoke(this, token);
        }
        protected virtual void OnExecutedDefault(IProcess process, IToken token)
        {
            Debug($"On executed process: {Name}");
        }

        public event Action<IProcess, Exception> OnError;

        protected void ExecutionError(Exception exception)
        {
            OnError?.Invoke(this, exception);
        }

        protected virtual void OnErrorDefault(IProcess process, Exception exception)
        {
            Debug($"On Error in process: {Name}", exception);
        }

        public void Execute()
        {
            try
            {

                PreExecution();

                var token = RunProcess();

                PostExecution(token);
            }
            catch (ProcessException ex)
            {

                Error($"Error on executing process: '{Name}'", ex);

                ExecutionError(ex);

                if (ex.IsTerminating)
                {
                    RetryOrSuspend();
                }

                throw;
            }
            catch (System.Exception ex)
            {

                Error($"Error on executing process: '{Name}'", ex);

                ExecutionError(ex);

                RetryOrSuspend();

                throw;
            }
        }

        protected abstract IToken RunProcess();

        public abstract void Setup();

        public abstract void RetryOrSuspend();

    }

}
