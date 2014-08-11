#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NLogWrapper.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
// </summary>
// <creation issue="" date="13-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion

using System;
using Common.Logger.Interfaces;

namespace Common.Logger.Loggers
{
    class NLogWrapper:ILogger
    {
        private readonly NLog.Logger _logger;

        public NLogWrapper()
        {
            _logger = NLog.LogManager.GetCurrentClassLogger();
        }

        /// <summary>
        /// Log a error message plus the exception
        /// </summary>
        /// <param name="message">error message</param>
        /// <param name="exception">exceptio </param>
        public void ErrorException(string message , Exception exception)
        {
            _logger.Error(message, exception);
        }

        /// <summary>
        /// Log a error message
        /// </summary>
        /// <param name="message">error message</param>
        public void Error(string message)
        {
            _logger.Error(message);
        }

        /// <summary>
        /// Log a information message
        /// </summary>
        /// <param name="message">information message</param>
        public void Info(string message)
        {
            _logger.Info(message);
        }

        /// <summary>
        /// Log a trace message
        /// </summary>
        /// <param name="message">trace message</param>
        public void Trace(string message)
        {
            _logger.Trace(message);
        }
    }
}
