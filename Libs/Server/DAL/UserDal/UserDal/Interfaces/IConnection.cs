#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IConnection.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Logger Provider
// </summary>
// <creation issue="" date="13-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion

using System.Data.SqlClient;

namespace UserDal.Interfaces
{
    public interface IConnection
    {
        SqlConnection Connection{get;}
        string ConnectionString { get; }
    }
}
