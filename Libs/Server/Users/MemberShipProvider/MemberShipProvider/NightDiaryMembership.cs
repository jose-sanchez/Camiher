using System;
using System.Web.Security;
using Encryption;
using UserDal;
using UserDal.Interfaces;

namespace MemberShipProvider
{
    public class NightDiaryMembership : System.Web.Security.MembershipProvider
    {
        private readonly IUserDal _usersDalc = new CUsersDalcs();
        public override MembershipUser CreateUser(String userName, String password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            status = MembershipCreateStatus.Success;
            var args = new ValidatePasswordEventArgs(userName, password, true);
            OnValidatingPassword(args);

            if (args.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }

            if (RequiresUniqueEmail && GetUserNameByEmail(email) != string.Empty)
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }
            
          //Check if user exist
          var membershipUser = GetUser(userName, false);
            if (membershipUser == null)
            {

                _usersDalc.CreateUser(new User()
                {
                    UserName = userName,
                    Password = password,
                    Email = email,
                    PasswordQuestion = passwordQuestion,
                    PasswordAnswer = passwordAnswer
                });
                return GetUser(userName, true);
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }          
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
             var user = _usersDalc.GetUser(username);
            if (user != null)
            {
                return new MembershipUser(
                                        "NightDiaryMembership",
                                        user.UserName, 
                                        user.UserId,
                                        user.Email, 
                                        String.Empty,
                                        String.Empty, 
                                        true, 
                                        false, 
                                        DateTime.MinValue, 
                                        DateTime.MinValue, 
                                        DateTime.MinValue, 
                                        DateTime.Now, 
                                        DateTime.Now);
            }
            else
            {
                return null;
            }            
        }
        /// <summary>
        /// validate user comparing the encrypted password with the password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public override bool ValidateUser(string username, string password)
        {
            User user =_usersDalc.GetUser(username);
            return PasswordHash.ValidatePassword(password, user.Password);
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            return _usersDalc.GetUserNamebyEmail(email);
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { return true; }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }


    }
}
