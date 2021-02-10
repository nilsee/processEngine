using System;
using log4net;
using System.Collections.Generic;

namespace ProcessEngine.Framework.Utils
{

    public class Logger 
    {

        private readonly ILog _log;

        private List<System.Exception> _exceptions;

        public Logger()
        {

            _log = LogManager.GetLogger(GetType());

            _exceptions = new List<System.Exception>();

        }

        public void Debug(string message)
        {
            if (_log.IsDebugEnabled)
            {
                _log.Debug(message);
            }
        }

        public void Debug(string message, System.Exception exception)
        {
            if (exception != null)
            {
                _exceptions.Add(exception);
            }

            if (_log.IsDebugEnabled)
            {
                _log.Debug(message, exception);
            }
        }

        public void Error(string message)
        {
            if (_log.IsErrorEnabled)
            {
                _log.Error(message);
            }
        }

        public void Error(string message, System.Exception exception)
        {
            if (exception != null)
            {
                _exceptions.Add(exception);
            }

            if (_log.IsErrorEnabled)
            {
                _log.Error(message, exception);
            }
        }

        public void Fatal(string message)
        {
            if (_log.IsFatalEnabled)
            {
                _log.Fatal(message);
            }
        }

        public void Fatal(string message, System.Exception exception)
        {
            if (exception != null)
            {
                _exceptions.Add(exception);
            }

            if (_log.IsFatalEnabled)
            {
                _log.Fatal(message, exception);
            }
        }

        public void Info(string message)
        {
            if (_log.IsInfoEnabled)
            {
                _log.Info(message);
            }
        }

        public void Warn(string message)
        {
            if (_log.IsWarnEnabled)
            {
                _log.Warn(message);
            }
        }

        public System.Exception[] GetLoggedExceptions()
        {
            return _exceptions.ToArray();
        }

    }

}
