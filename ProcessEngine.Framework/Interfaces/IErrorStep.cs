using System;

namespace ProcessEngine.Framework.Interfaces
{
    public interface IErrorStep<D> : IStep
    {
        void ExecuteStep(IToken<D> token, ProcessException exception, Action<IToken<D>, ProcessException> error);

        IToken<D> ErrorToken
        {
            get;
        }
    }
}
