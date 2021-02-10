using System.Collections.Generic;

namespace ProcessEngine.Framework.Interfaces
{
    public interface IToken
    {

        string ProcessName
        {
            get;
        }

        bool Terminate
        {
            get;
        }

        void AddException(IStep step, string message, System.Exception innerException, bool isSuspending = true);

        void AddException(ProcessException exception);

        List<ProcessException> ProcessExceptions
        {
            get;
        }

        bool HasTerminatingExceptions();

    }

    public interface IToken<D> : IToken
    {
        D GetData();
    }
}
