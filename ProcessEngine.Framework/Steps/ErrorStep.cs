using ProcessEngine.Framework.Interfaces;
using System;

namespace ProcessEngine.Framework.Steps
{

    public class ErrorStep<D> : StepBase, IErrorStep<D>
    {

        public IToken<D> ErrorToken
        {
            get;
            protected set;
        }

        public void ExecuteStep(IToken<D> token, ProcessException exception, Action<IToken<D>, ProcessException> error)
        {
            try
            {

                PreExecution(token);

                DoStep(token, exception, error);

                PostExecution(token);
            }
            catch (ProcessException pex)
            {

                Error($"Error on executing error step: {base.Name}", pex);

                ExecutionError(pex);

                throw;
            }
            catch (System.Exception ex)
            {

                Error($"Error on executing error step: {base.Name}", ex);

                ExecutionError(ex);

                throw;
            }

        }

        protected virtual void DoStep(IToken<D> token, ProcessException exception, Action<IToken<D>, ProcessException> errorAction)
        {
            var exceptions = token?.ProcessExceptions;

            if (exceptions != null)
            {
                foreach (var execption in exceptions)
                {
                    Error($"Exception thrown while processing: '{token?.ProcessName}'", exception);

                    if (exception.InnerException != null)
                    {
                        Error($"InnerException thrown while processing: '{token?.ProcessName}'", exception.InnerException);
                    }
                }
            }

            errorAction(token, exception);

            ErrorToken = token;
        }

    }

}
