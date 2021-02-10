using System;

namespace ProcessEngine.Framework.Interfaces
{

    public interface IProcess
    {

        bool Completed
        {
            get;
        }

        string Name
        {
            get;
        }

        void Setup();

        void Execute();

        void RetryOrSuspend();

        event Action<IProcess> OnExecuting;

        event Action<IProcess, IToken> OnExecuted;

        event Action<IProcess, Exception> OnError;

    }

}
