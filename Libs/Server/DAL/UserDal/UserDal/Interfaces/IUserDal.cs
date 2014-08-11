#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserDal.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
// </summary>
// <creation issue="" date="13-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserDal.Interfaces
{
    public interface IUserDal
    {
        User GetUser(String userId);

        bool CreateUser(User user);

        bool DeleteUser(String userId);

        DataSet GetUsers();

        string GetUserNamebyEmail(string email);
    }
}
