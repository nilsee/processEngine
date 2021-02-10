using ProcessEngine.Framework.Interfaces;
using System;

namespace ProcessEngine.Framework.Steps
{

    public abstract class StartStep<D> : StepBase, IStartStep<D>
    {

        public IToken<D> ExecuteStep()
        {
            try
            {

                PreExecution(null);

                IToken<D> token = DoStep();

                PostExecution(token);

                return token;
            }
            catch (ProcessException pex)
            {

                Error($"Error on executing start step: {base.Name}", pex);

                ExecutionError(pex);

                throw;
            }
            catch (System.Exception ex)
            {

                Error($"Error on executing start step: {base.Name}", ex);

                ExecutionError(ex);

                throw;
            }

        }

        protected abstract IToken<D> DoStep();

    }

}