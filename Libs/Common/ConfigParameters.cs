#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigParameters.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Helps to get parameters from web.config / app.config
// </summary>
// <creation issue="" date="11-08-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion
using System;
using System.Configuration;
using Logger;

namespace Common
{
    public class ConfigParameters
    {
        public static string GetKey(string key)
        {
            return GetKey(key, null);
        }
        public static string GetKey(string key, string defaultValue)
        {
            string parameter = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrEmpty(parameter))
            {
                if (defaultValue != null)
                {
                    return defaultValue;
                }
                else
                {
                    AppLogger.Error(String.Format("key '{0}' does not exist or is empty",key));
                    throw new ArgumentException(String.Format("key '{0}' does not exist or is empty", key));
                }
            }

            return parameter;
        }
    }
}
