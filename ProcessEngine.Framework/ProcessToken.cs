using ProcessEngine.Framework.Interfaces;
using System;
using System.Collections.Generic;

namespace ProcessEngine.Framework
{
    public class ProcessToken<D> : IToken<D>
    {
        protected D _data;

        private string _processName;
        
        protected List<ProcessException> _exceptions;
        
        private bool _terminate;

        public ProcessToken(D data, string processName, IEnumerable<ProcessException> exceptions, bool terminate = false)
        {
            _data = data;

            _processName = processName;

            ProcessExceptions = new List<ProcessException>();
            foreach (var exception in exceptions)
            {
                ProcessExceptions.Add(exception);
            }

            _terminate = terminate;
        }

        public ProcessToken(D data, string processName, bool terminate = false, params ProcessException [] exceptions) : this(data, processName, exceptions, terminate) {
        }

        public ProcessToken(ProcessToken<D> token) : this(token._data, token._processName, token._exceptions, token._terminate) {
        }

        public D GetData()
        {
            return _data;
        }

        public List<ProcessException> ProcessExceptions
        {
            get
            {
                return _exceptions;
            }
            protected set
            {
                _exceptions = value;
            }
        }

        public void AddException(IStep step, string message, System.Exception innerException, bool isTerminating = true)
        {
            if (_exceptions == null)
            {
                _exceptions = new List<ProcessException>();
            }

            _exceptions.Add(new ProcessException(step, this, message, innerException, isTerminating));
        }

        public void AddException(ProcessException exception)
        {
            if (_exceptions == null)
            {
                _exceptions = new List<ProcessException>();
            }

            _exceptions.Add(exception);
        }

        public bool HasTerminatingExceptions()
        {
            return ProcessExceptions == null && ProcessExceptions.FindAll( p => p.IsTerminating ).Count > 0;
        }

        public string ProcessName
        {
            get
            {
                return _processName;
            }
        }

        public bool Terminate
        {
            get
            {
                return _terminate;
            }

            protected set
            {
                _terminate = value;
            }
        }

    }

}
