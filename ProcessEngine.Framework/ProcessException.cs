using ProcessEngine.Framework.Interfaces;
using System;

namespace ProcessEngine.Framework
{

    public class ProcessException : ApplicationException
    {

        public bool IsTerminating { get; protected set; }

        public IStep Step { get; protected set; }

        public IToken Token { get; protected set; }

        public ProcessException(string message, bool isTerminating = true) : base(message)
        {
            Step = null;
            Token = null;
            IsTerminating = isTerminating;
        }

        public ProcessException(string message, System.Exception innerException, bool isTerminating = true) : base(message, innerException)
        {
            Step = null;
            Token = null;
            IsTerminating = isTerminating;
        }

        public ProcessException(IToken token, string message, System.Exception innerException, bool isTerminating = true) : base(message, innerException)
        {
            Step = null;
            Token = token;
            IsTerminating = isTerminating;
        }

        public ProcessException(IStep step, IToken token, string message, bool isTerminating = true) : base(message)
        {
            Step = step;
            Token = token;
            IsTerminating = isTerminating;
        }
        public ProcessException(IStep step, string message, bool isTerminating = true) : base(message)
        {
            Step = step;
            Token = null;
            IsTerminating = isTerminating;
        }

        public ProcessException(IStep step, IToken token, string message, System.Exception innerException, bool isTerminating = true) : base(message, innerException)
        {
            Step = step;
            Token = token;
            IsTerminating = isTerminating;
        }

    }

}
