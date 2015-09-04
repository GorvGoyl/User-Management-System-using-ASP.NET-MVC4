using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Configuration;
using DataObjects;
using log4net;
using Utilities;
namespace DataAccessLayer
{
    public class User_MySQL
    {
        private static readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected static string ConnString  = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        #region Create
        public static void Create(User user)
        {
            Logger.Debug("Method Start");
            MySqlConnection Con = null;
            MySqlDataReader Reader = null;
            try
            {
                LogHelper.LogMaker(user);
                Con = new MySqlConnection(ConnString);
                Con.Open();
                MySqlCommand Cmd = new MySqlCommand("udsp_User_Create", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("var_UserId", user.UserId);
                Cmd.Parameters.AddWithValue("var_UserName", user.UserName);
                Cmd.Parameters.AddWithValue("var_FullName", user.FullName);
                Cmd.Parameters.AddWithValue("var_Phone", user.Phone);
                Cmd.Parameters.AddWithValue("var_Email", user.Email);
                Cmd.Parameters.AddWithValue("var_City", user.City);
                Cmd.Parameters.AddWithValue("var_Dob", user.Dob);
                Cmd.Parameters.AddWithValue("var_Password", user.Password);
                Cmd.ExecuteNonQuery();
            }
            catch (MySqlException exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                if (Reader != null)
                {
                    Reader.Close();
                }
                Logger.Debug("Method End");
            }

        }
        #endregion

        #region Retrieve
        public static List<User> Retrieve()
        {
            Logger.Debug("Method Start");
            List<User> UsersList = new List<User>();
            MySqlConnection Con = null;
            MySqlDataReader Reader = null;
            try
            {
                //string ConnString = "server=localhost;user id=root;Password=leadsquared;database=mvc_database;persist security info=False";
                Con = new MySqlConnection(ConnString);
                Con.Open();
                MySqlCommand Cmd = new MySqlCommand("udsp_User_Retrieve", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("var_UserId", "");
                Cmd.Parameters.AddWithValue("var_UserName", "");
                Cmd.Parameters.AddWithValue("var_Password", "");
                Reader = Cmd.ExecuteReader();
                User UserData;
                while (Reader.Read())
                {
                    UserData = new User();
                    UserData.UserId = Reader["UserId"].ToString();
                    UserData.UserName = Reader["UserName"].ToString();
                    UserData.FullName = Reader["FullName"].ToString();
                    UserData.Phone = Reader["Phone"].ToString();
                    UserData.Email = Reader["Email"].ToString();
                    UserData.City = Reader["City"].ToString();
                    UserData.Dob = Reader["Dob"].ToString();
                    UserData.Password = Reader["Password"].ToString();
                    UsersList.Add(UserData);
                }
                LogHelper.LogMaker(UsersList);
            }
            catch (MySqlException exception)
            {

                Logger.Error(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {

                Logger.Error(exception.Message, exception);
                throw exception;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                if (Reader != null)
                {
                    Reader.Close();
                }
                Logger.Debug("Method End");
            }

            return UsersList;
        }
        #endregion

        #region RetrieveUser
        public static User RetrieveUser(User user)
        {
            Logger.Debug("Method Start");
            User UserData = new User();
            MySqlConnection Con = null;
            MySqlDataReader Reader = null;
            try
            {
                Con = new MySqlConnection(ConnString);
                Con.Open();
                MySqlCommand Cmd = new MySqlCommand("udsp_User_Retrieve", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("var_UserId", user.UserId);  //guid is for editing user data
                Cmd.Parameters.AddWithValue("var_UserName", user.UserName); //username and passoword is for login part
                Cmd.Parameters.AddWithValue("var_Password", user.Password);
                Reader = Cmd.ExecuteReader();
                if (Reader.Read())
                {
                    UserData.UserId = Reader["UserId"].ToString();
                    UserData.UserName = Reader["UserName"].ToString();
                    UserData.FullName = Reader["FullName"].ToString();
                    UserData.Phone = Reader["Phone"].ToString();
                    UserData.Email = Reader["Email"].ToString();
                    UserData.City = Reader["City"].ToString();
                    UserData.Dob = Reader["Dob"].ToString();
                    UserData.Password = Reader["Password"].ToString();
                }
            }
            catch (MySqlException exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                if (Reader != null)
                {
                    Reader.Close();
                }
                Logger.Debug("Method End");
            }

            return UserData;

        }
        #endregion

        #region Update
        public static void Update(User user)
        {
            Logger.Debug("Method Start");
            MySqlConnection Con = null;
            //MySqlDataReader Reader = null;
            try
            {
                Con = new MySqlConnection(ConnString);
                Con.Open();
                MySqlCommand Cmd = new MySqlCommand("udsp_User_Update", Con);
                Cmd.CommandType  = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("var_UserId", user.UserId);
                Cmd.Parameters.AddWithValue("var_UserName", user.UserName);
                Cmd.Parameters.AddWithValue("var_FullName", user.FullName);
                Cmd.Parameters.AddWithValue("var_Phone", user.Phone);
                Cmd.Parameters.AddWithValue("var_Email", user.Email);
                Cmd.Parameters.AddWithValue("var_City", user.City);
                Cmd.Parameters.AddWithValue("var_Dob", user.Dob);
                Cmd.Parameters.AddWithValue("var_Password", "");
                Cmd.ExecuteNonQuery();

                LogHelper.LogMaker(user);
            }
            catch (MySqlException exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {
                Logger.Error(exception.Message, exception);
                throw exception;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                //if (Reader != null)
                //{
                //    Reader.Close();
                //}
                Logger.Debug("Method End");
            }
        }
        #endregion

        #region Delete
        public static void Delete(User user)
        {
            Logger.Debug("Method Start");
            MySqlConnection Con = null;
            // MySqlDataReader Reader = null;
            try
            {
                Con = new MySqlConnection(ConnString);

                Con.Open();
                MySqlCommand Cmd = new MySqlCommand("udsp_User_Delete", Con);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("var_UserId", user.UserId);
                Cmd.ExecuteNonQuery();

            }
            catch (MySqlException exception)
            {

                Logger.Error(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {

                Logger.Error(exception.Message, exception);
                throw exception;
            }
            finally
            {
                if (Con.State == ConnectionState.Open)
                {
                    Con.Close();
                }
                //if (Reader != null)
                //{
                //    Reader.Close();
                //}
                Logger.Debug("Method End");
            }
        }
        #endregion
    }
}
