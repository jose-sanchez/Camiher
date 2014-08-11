#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppLogger.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
// </summary>
// <creation issue="" date="13-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion

using System;
using Common.Logger.Interfaces;
using Common.Logger.Interfaces;
using Logger;

namespace CommonLogger
{
    public static class AppLogger
    {
        private static  ILogger _logger;

        static AppLogger()
        {
            _logger = new LoggerProvider().GetLogger();
        }

        /// <summary>
        /// Log a message in the Info level
        /// </summary>
        /// <param name="message"></param>
        public static void Info(String message)
        {
            _logger.Info(message);
        }

        /// <summary>
        /// Log a message in the Trace level
        /// </summary>
        /// <param name="message"></param>
        public static void Trace(String message)
        {
            _logger.Trace(message);
        }

        /// <summary>
        /// Log a message in the Error level
        /// </summary>
        /// <param name="message"></param>
        public static void Error(String message)
        {
            _logger.Error(message);
        }

        public static void ErrorException(String message,Exception exception)
        {
            _logger.ErrorException(message,exception);
        }

    }
}
