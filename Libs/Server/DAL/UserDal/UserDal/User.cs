#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="User.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Store information which will be store in tha User table
// </summary>
// <creation issue="" date="15-07-2014" author="Jose Sanchez" />
// --------------------------------------------------------------------------------------------------------------------
#endregion

namespace UserDal
{
     public class User
    {
         public string UserId { get; set; }
         public string UserName { get; set; }
         public string Password { get; set; }
         public string Email { get; set; }
         public string PasswordQuestion { get; set; }
         public string PasswordAnswer { get; set; }        
    }
}
