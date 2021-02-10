using ProcessEngine.Framework.Interfaces;
using ProcessEngine.Framework.Steps;
using System;

namespace ProcessEngine.Framework
{

    public abstract class IntermedateStep<D> : StepBase, IIntermediateStep<D>
    {

        public IToken<D> ExecuteStep(IToken<D> token)
        {
            try
            {

                PreExecution(token);

                IToken<D> result = DoStep(token);

                PostExecution(token);

                return result;
            }
            catch (ProcessException pex)
            {

                Error($"Error on executing intermedate step: {base.Name}", pex);

                ExecutionError(pex);

                throw;
            }
            catch (System.Exception ex)
            {

                Error($"Error on executing intermediate step: {base.Name}", ex);

                ExecutionError(ex);

                throw;
            }
        }

        protected abstract IToken<D> DoStep(IToken<D> token);

    }

}
