#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoggerProvider.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Logger Provider
// </summary>
// <creation issue="" date="13-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion

using System.Configuration;
using Logger.Interfaces;
using Logger.Loggers;

namespace Logger
{
    class LoggerProvider
    {
        private ILogger _logger;

        /// <summary>
        /// Return a unique instance of system logger;
        /// </summary>
        /// <returns></returns>
        public ILogger GetLogger()
        {
            if (_logger != null) return _logger;
            var loggerConfig = new LoggerProviderConfig();
            switch (loggerConfig.TypeLog)
            {
                case "NLogWrapper":
                    _logger = new NLogWrapper();
                    break;
            }
            return _logger;
        }
    }
    class LoggerProviderConfig : ConfigurationSection
    {
        [ConfigurationProperty("type", DefaultValue = "NLogWrapper", IsRequired = true)]
        public string TypeLog
        {
            get
            {
                return (string)this["type"];
            }
            set
            {
                this["type"] = value;
            }
        }
    }
}
