#region copyright
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CUsersDalcs.cs" company="Jose">
//      Jose Maria Sanchez Simon. All rights reserved.
// </copyright>
// <summary>
//  Data access layer for User
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
using System.Data.SqlClient;
using Logger;
using UserDal.Interfaces;

namespace UserDal
{
    public class CUsersDalcs:IUserDal
    {
        private readonly IConnection _connection;

        /// <summary>
        /// Store Procedure name by default to get user information from the database
        /// </summary>
        private const String UsersGetUser = "Users.GetUser";
        private const String UsersGetUserbyEmail = "Users.GetUserByEmail";
        private const String UsersInsertUser = "Users.InsertUser";
        private const String UsersDeleteUser = "Users.DeleteUser";
        private const String UsersGetAllUsers = "Users.GetAllUser";

        public CUsersDalcs()
        {
            _connection = ConnectionProvider.GetConnection();
        }

        /// <summary>
        /// Get a specific user using his ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(string userId)
        {
            var newUser = new User();
            try
            {
                using (SqlConnection conn = _connection.Connection)
                {
                    using (var cmd = new SqlCommand(UsersGetUser, conn))
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = userId;
                        conn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                newUser.UserId = dr["UserId"].ToString();
                                newUser.UserName = dr["UserName"].ToString();
                                newUser.Password = dr["Password"].ToString();
                                newUser.Email = dr["Email"].ToString();
                                newUser.PasswordQuestion = dr["PasswordQuestion"].ToString();
                                newUser.PasswordAnswer = dr["PasswordAnswer"].ToString();
                            }
                            else
                            {
                                newUser = null;
                            }
                        }
                    }
                }

                return newUser;
            }
            catch (Exception ex)
            {
                AppLogger.ErrorException(String.Format("[CUsersDalcs][GetUser]: for user: {0} ", userId),ex);
                throw;
            }
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CreateUser(User user)
        {
            try
            {
                using (SqlConnection conn = _connection.Connection)
                {
                    using (var cmd = new SqlCommand(UsersInsertUser, conn))
                    {
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = user.UserName;
                        cmd.Parameters.Add("@Password", SqlDbType.VarChar).Value = user.Password;
                        cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = user.Email;
                        cmd.Parameters.Add("@PasswordQuestion", SqlDbType.VarChar).Value = user.PasswordQuestion;
                        cmd.Parameters.Add("@PasswordAnswer", SqlDbType.VarChar).Value = user.PasswordAnswer;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                AppLogger.ErrorException(String.Format("[CUsersDalcs][CreateUser]: for user: {0} ", user.UserName), ex);
                return false;
            }
        }

        /// <summary>
        /// Delete a user from the database
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool DeleteUser(string userId)
        {
            try
            {
                using (SqlConnection conn = _connection.Connection)
                {
                    using (var cmd = new SqlCommand(UsersDeleteUser, conn))
                    {
                        cmd.Parameters.Add("@UserName", SqlDbType.VarChar).Value = userId;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                AppLogger.ErrorException(String.Format("[CUsersDalcs][CreateUser]: for user: {0} ", userId), ex);
                return false;
            }
        }

        /// <summary>
        /// Get all user in the database
        /// </summary>
        /// <returns></returns>
        public DataSet GetUsers()
        {
            var ds = new DataSet();
            
            try
            {
                using (SqlConnection conn = _connection.Connection)
                {
                    using (var cmd = new SqlCommand(UsersGetAllUsers, conn))
                    {
                        conn.Open();
                        using (var da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(ds);
                        }                      
                    }
                }

                return ds;
            }
            catch (Exception ex)
            {
                AppLogger.ErrorException("[CUsersDalcs][GetUsers]: ", ex);
                throw;
            }
        }

        /// <summary>
        /// Get username using the email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public string GetUserNamebyEmail(string email)
        {
            var userName = String.Empty;
            try
            {
                using (SqlConnection conn = _connection.Connection)
                {
                    using (var cmd = new SqlCommand(UsersGetUserbyEmail, conn))
                    {
                        cmd.Parameters.Add("@ID", SqlDbType.VarChar).Value = email;
                        conn.Open();
                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows)
                            {
                                dr.Read();
                                userName = dr["UserName"].ToString();  
                            }
                        }
                    }
                }

                return userName;
            }
            catch (Exception ex)
            {
                AppLogger.ErrorException(String.Format("[CUsersDalcs][GetUserNamebyEmail]: for Email : {0}", email), ex);
                throw;
            }
        }
    }
}
