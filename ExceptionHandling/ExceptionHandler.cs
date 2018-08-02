using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Microsoft.Practices.EnterpriseLibrary.Logging;


namespace ExceptionHandling
{
    public class ExceptionHandler
    {
        #region Static Variables  

        private static LogWriter logWriter;
        private static readonly ExceptionPolicyFactory _exceptionPolicyFactory;
        private static readonly ExceptionManager _exceptionManager;

        #endregion

        #region Constructor  

        static ExceptionHandler()
        {
            logWriter = new LogWriterFactory().Create();
            Logger.SetLogWriter(logWriter, false);

            _exceptionPolicyFactory = new ExceptionPolicyFactory();
            _exceptionManager = _exceptionPolicyFactory.CreateManager();
        }

        #endregion

        #region Static Methods  

        /// <summary>  
        /// Performs the handling of an application towards the configured policy.         
        /// <param name="ex">Exception to handle.</param>  
        public string HandleException(Exception ex)
        {
            Exception exceptionToThrow = null;
            string errmessage = "";
            //The HandleException method will return true if the exception should be (re-)thrown.  
            if (_exceptionManager.HandleException(ex, "DivideByZero Exception Handler", out exceptionToThrow))
            {
                if (exceptionToThrow == null)
                {
                    errmessage = ex.Message;
                }
                else
                {
                    errmessage = exceptionToThrow.Message;
                }
            }
            return errmessage;
        }

        #endregion
    }
}