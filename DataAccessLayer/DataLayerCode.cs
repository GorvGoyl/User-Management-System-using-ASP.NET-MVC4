using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Configuration;
using Models;
namespace DataAccessLayer
{
    public class DataLayerCode
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<User> RetrieveAllData()
        {
            Logger.Debug("Method Start");
            string JsonUser = "";
            List<User> UsersList = new List<User>();
            try
            {
                //string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString(); //for getting connection from web.config
                string ConnString = "server=localhost;user id=root;Password=leadsquared;database=mvc_database;persist security info=False";
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
                        UserData.Name = Reader["NAME"].ToString();
                        UserData.Phone = Reader["PHONE"].ToString();
                        UserData.City = Reader["CITY"].ToString();
                        UserData.DOB = Reader["DOB"].ToString();
                        UserData.EMail = Reader["EMAIL"].ToString();
                        UsersList.Add(UserData);

                    }


                    JsonUser = JsonConvert.SerializeObject(UsersList);
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

            Logger.Debug(JsonUser);
            Logger.Debug("Method End");
            return UsersList;
        }

        public static User RetrieveUser(string guid)
        {
            Logger.Debug("Method Start");
           // string JsonUser = "";
            User UserData = new User();
            try
            {
                // string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
                string ConnString = "server=localhost;user id=root;Password=leadsquared;database=mvc_database;persist security info=False";
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Retrieve", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    //string guid = "4";
                    Cmd.Parameters.AddWithValue("var_GUIDparam", guid);
                    MySqlDataReader Reader = Cmd.ExecuteReader();
                    if (Reader.Read())
                    {
                        UserData.GUID = Reader["GUID"].ToString();
                        UserData.Name = Reader["NAME"].ToString();
                        UserData.Phone = Reader["PHONE"].ToString();
                        UserData.City = Reader["CITY"].ToString();
                        UserData.DOB = Reader["DOB"].ToString();
                        UserData.EMail = Reader["EMAIL"].ToString();
                    }
                    string JsonUser = JsonConvert.SerializeObject(UserData);
                    return UserData;
                    
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
            //JsonUser = JsonConvert.SerializeObject(UserData);
            //Logger.Debug(JsonUser);
            //Logger.Debug("Method End");
            //return JsonUser;
            
        }

        public static void AddUserToDB(List<string> userData)
        {
            Logger.Debug("Method Start");

            try
            {
                //string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
                string ConnString = "server=localhost;user id=root;Password=leadsquared;database=mvc_database;persist security info=False";
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Create", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("var_GUIDparam", userData[0]);
                    Cmd.Parameters.AddWithValue("var_Nameparam", userData[1]);
                    Cmd.Parameters.AddWithValue("var_Phoneparam", userData[2]);
                    Cmd.Parameters.AddWithValue("var_Cityparam", userData[3]);
                    Cmd.Parameters.AddWithValue("var_DOBparam", userData[4]);
                    Cmd.Parameters.AddWithValue("var_EMailparam", userData[5]);
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

        public static void UpdateUser(List<string> userData)
        {
            Logger.Debug("Method Start");

            try
            {
                // string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
                string ConnString = "server=localhost;user id=root;Password=leadsquared;database=mvc_database;persist security info=False";
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Update", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_GUIDparam", userData[0]);
                    Cmd.Parameters.AddWithValue("var_Nameparam", userData[1]);
                    Cmd.Parameters.AddWithValue("var_Phoneparam", userData[2]);
                    Cmd.Parameters.AddWithValue("var_Cityparam", userData[3]);
                    Cmd.Parameters.AddWithValue("var_DOBparam", userData[4]);
                    Cmd.Parameters.AddWithValue("var_EMailparam", userData[5]);
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
            try
            {
                // string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
                string ConnString = "server=localhost;user id=root;Password=leadsquared;database=mvc_database;persist security info=False";
                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Delete", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_GUIDparam", guid);
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
