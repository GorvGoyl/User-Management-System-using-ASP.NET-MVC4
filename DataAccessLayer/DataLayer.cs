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
    public class DataLayer
    {
        private static readonly ILog Logger=log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected static string ConnString= ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        

        public static List<User> RetrieveAllData()
        {
            Logger.Debug("Method Start");
            List<User> UsersList = new List<User>();
            try
            {
                //string ConnString = "server=localhost;user id=root;Password=leadsquared;database=mvc_database;persist security info=False";
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Comm = new MySqlCommand("udsp_User_Retrieve_All", Con);
                    Comm.CommandType = CommandType.StoredProcedure;
                    MySqlDataReader Reader = Comm.ExecuteReader();
                    User UserData;
                    while (Reader.Read())
                    {
                        UserData = new User();
                        UserData.GUID = Reader["GUID"].ToString();
                        UserData.UserName = Reader["UserName"].ToString();
                        UserData.FullName = Reader["FullName"].ToString();
                        UserData.Phone = Reader["Phone"].ToString();
                        UserData.Email = Reader["Email"].ToString();
                        UserData.City = Reader["City"].ToString();
                        UserData.Dob = Reader["Dob"].ToString();
                        UserData.Password = Reader["Password"].ToString();
                        UsersList.Add(UserData);
                    }

                }
            }
            catch (MySqlException exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            try
            {
                CustomJson.JsonAndLog(UsersList);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
            return UsersList;
        }

        public static User RetrieveUser(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            User UserData = new User();
            try
            {
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Retrieve", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_GUID", guid);
                    MySqlDataReader Reader = Cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        UserData.GUID = Reader["GUID"].ToString();
                        UserData.UserName = Reader["UserName"].ToString();
                        UserData.FullName = Reader["FullName"].ToString();
                        UserData.Phone = Reader["Phone"].ToString();
                        UserData.Email = Reader["Email"].ToString();
                        UserData.City = Reader["City"].ToString();
                        UserData.Dob = Reader["Dob"].ToString();
                        UserData.Password = Reader["Password"].ToString();
                    }

                }
            }
            catch (MySqlException exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            try
            {
                CustomJson.JsonAndLog(UserData);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }

            Logger.Debug("Method End");
            return UserData;

        }

        public static User RetrieveUser(User user)
        {
            Logger.Debug("Method Start");
           // Logger.Debug(guid);
            User UserData = new User();
            try
            {
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Validate", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_UserName", user.UserName);
                    Cmd.Parameters.AddWithValue("var_Password", user.Password);
                    MySqlDataReader Reader = Cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        UserData.GUID = Reader["GUID"].ToString();
                        UserData.UserName = Reader["UserName"].ToString();
                        UserData.FullName = Reader["FullName"].ToString();
                        UserData.Phone = Reader["Phone"].ToString();
                        UserData.Email = Reader["Email"].ToString();
                        UserData.City = Reader["City"].ToString();
                        UserData.Dob = Reader["Dob"].ToString();
                        UserData.Password = Reader["Password"].ToString();
                    }

                }
            }
            catch (MySqlException exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            try
            {
                CustomJson.JsonAndLog(UserData);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }

            Logger.Debug("Method End");
            return UserData;

        }

        public static void AddUserToDB(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                CustomJson.JsonAndLog(user);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }

            try
            {
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Create", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_GUID", user.GUID);
                    Cmd.Parameters.AddWithValue("var_UserName", user.UserName);
                    Cmd.Parameters.AddWithValue("var_FullName", user.FullName);
                    Cmd.Parameters.AddWithValue("var_Phone", user.Phone);
                    Cmd.Parameters.AddWithValue("var_Email", user.Email);
                    Cmd.Parameters.AddWithValue("var_City", user.City);
                    Cmd.Parameters.AddWithValue("var_Dob", user.Dob);
                    Cmd.Parameters.AddWithValue("var_Password", user.Password);
                    Cmd.ExecuteNonQuery();
                }

            }
            catch (MySqlException exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
        }

        public static void UpdateUser(User user)
        {
            Logger.Debug("Method Start");
            try
            {
                CustomJson.JsonAndLog(user);
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            try
            {
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Update", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_GUID", user.GUID);
                    Cmd.Parameters.AddWithValue("var_UserName", user.UserName);
                    Cmd.Parameters.AddWithValue("var_FullName", user.FullName);
                    Cmd.Parameters.AddWithValue("var_Phone", user.Phone);
                    Cmd.Parameters.AddWithValue("var_Email", user.Email);
                    Cmd.Parameters.AddWithValue("var_City", user.City);
                    Cmd.Parameters.AddWithValue("var_Dob", user.Dob);
                   // Cmd.Parameters.AddWithValue("var_Password", user.Password);
                    Cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
        }

        public static void DeleteUser(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            try
            {
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Delete", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_GUID", guid);
                    Cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            catch (Exception exception)
            {

                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
        }
    }
}
