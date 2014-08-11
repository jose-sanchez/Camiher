#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DefaultConnection.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
// Model the connection string
// </summary>
// <creation issue="" date="13-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion
using System.Data.SqlClient;
using UserDal.Interfaces;

namespace UserDal
{
    class DefaultConnection:IConnection
    {
        private readonly SqlConnection _sqlconnection;
        private readonly string _connectionString;
        public SqlConnection Connection 
        {
            get
            {
                return _sqlconnection;
            }
        }
        public string ConnectionString
        {
            get
            {
                return _connectionString;
            }
        }

        public DefaultConnection(string ConnectionString)
        {
            _sqlconnection = new SqlConnection(ConnectionString);
            _connectionString = ConnectionString;
        }
    }
}
