using System;

namespace ProcessEngine.Framework.Interfaces
{
    public interface IStep
    {

        string Name
        {
            get;
        }

        event Action<IStep, IToken> OnExecuting;

        event Action<IStep, IToken> OnExecuted;

        event Action<IStep, Exception> OnError;

    }
}
