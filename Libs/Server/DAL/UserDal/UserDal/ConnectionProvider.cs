#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionProvider.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
// </summary>
// <creation issue="" date="13-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion
using System;
using System.Configuration;
using Logger;
using UserDal.Interfaces;

namespace UserDal
{
    class ConnectionProviderConfig: ConfigurationSection
    {
        [ConfigurationProperty("type", DefaultValue = "DefaultConnection", IsRequired = false)]
        public string TypeConnection
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

        [ConfigurationProperty("connectionString", DefaultValue = "", IsRequired = true)]
        public string ConnectionString
        {
            get
            {
                return (string)this["connectionString"];
            }
            set
            {
                this["connectionString"] = value;
            }
        }
    }
    public static class ConnectionProvider
    {
        private static IConnection _connection;
        public static IConnection GetConnection()
        {
            //If the connection was already created then return this connection
            if (_connection != null)
            {
                return _connection;
            }

            var connectionConfig = new ConnectionProviderConfig();
            if (connectionConfig.ConnectionString == String.Empty)
            { 
                AppLogger.Error("[ConnectionProvider][GetConnection]:connectionString Empty");

                throw new ArgumentException(("[ConnectionProvider][GetConnection]:connectionString Empty"));
            }
            switch (connectionConfig.TypeConnection)
            {
                case "DefaultConnection" :
                    _connection = new DefaultConnection(connectionConfig.ConnectionString);
                    break;
                default:
                    AppLogger.Error("[ConnectionProvider][GetConnection]:Coon");
                    throw new ArgumentException("[ConnectionProvider][GetConnection]: connection time does not exist");
                    // add default case with logging type error

            }

            return _connection;
        }      
    }   
}
