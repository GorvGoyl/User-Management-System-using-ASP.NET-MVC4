using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using Newtonsoft.Json;
using System.Configuration;
namespace DataAccessLayer
{
    public class DataLayerCode
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static string RetrieveAllData()
        {
            Logger.Debug("Method Start");
            string JsonUser = "";
            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();

                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Comm = new MySqlCommand("udsp_User_Retrieve_All", Con);
                    Comm.CommandType = CommandType.StoredProcedure;

                    MySqlDataReader Reader = Comm.ExecuteReader();
                    Users UserData;// = new Users[Reader.FieldCount];
                    List<Users> UserList = new List<Users>();
                    while (Reader.Read())
                    {
                        UserData = new Users();
                        UserData.GUID = Reader["GUID"].ToString();
                        UserData.Name = Reader["NAME"].ToString();
                        UserData.Phone = Reader["PHONE"].ToString();
                        UserData.City = Reader["CITY"].ToString();
                        UserData.DOB = Reader["DOB"].ToString();
                        UserData.EMail = Reader["EMAIL"].ToString();
                        UserList.Add(UserData);

                    }


                    JsonUser = JsonConvert.SerializeObject(UserList);
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
            return JsonUser;
        }

        public static string RetrieveUser(string guid)
        {
            Logger.Debug("Method Start");
            string JsonUser = "";
            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();

                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Retrieve", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_GUIDparam", guid);

                    MySqlDataReader Reader = Cmd.ExecuteReader();

                    Users UserData = new Users();
                    while (Reader.Read())
                    {

                        UserData.GUID = Reader["GUID"].ToString();
                        UserData.Name = Reader["NAME"].ToString();
                        UserData.Phone = Reader["PHONE"].ToString();
                        UserData.City = Reader["CITY"].ToString();
                        UserData.DOB = Reader["DOB"].ToString();
                        UserData.EMail = Reader["EMAIL"].ToString();

                    }

                    JsonUser = JsonConvert.SerializeObject(UserData);
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
            return JsonUser;
        }

        public static void AddUserToDB(string jsonUserData)
        {
            Logger.Debug("Method Start");
            Users UserData;
            try
            {
                UserData = JsonConvert.DeserializeObject<Users>(jsonUserData);

            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();

                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Create", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;

                    Cmd.Parameters.AddWithValue("var_GUIDparam", UserData.GUID);
                    Cmd.Parameters.AddWithValue("var_Nameparam", UserData.Name);
                    Cmd.Parameters.AddWithValue("var_Phoneparam", UserData.Phone);
                    Cmd.Parameters.AddWithValue("var_Cityparam", UserData.City);
                    Cmd.Parameters.AddWithValue("var_DOBparam", UserData.DOB);
                    Cmd.Parameters.AddWithValue("var_EMailparam", UserData.EMail);
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

        public static void UpdateUser(string jsonUserData)
        {
            Logger.Debug("Method Start");
            Users UserData;
            try
            {
                UserData = JsonConvert.DeserializeObject<Users>(jsonUserData);

            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }

            try
            {
                string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();

                using (MySqlConnection Con = new MySqlConnection(ConnString))
                {
                    Con.Open();
                    MySqlCommand Cmd = new MySqlCommand("udsp_User_Update", Con);
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("var_GUIDparam", UserData.GUID);
                    Cmd.Parameters.AddWithValue("var_Nameparam", UserData.Name);
                    Cmd.Parameters.AddWithValue("var_Phoneparam", UserData.Phone);
                    Cmd.Parameters.AddWithValue("var_Cityparam", UserData.City);
                    Cmd.Parameters.AddWithValue("var_DOBparam", UserData.DOB);
                    Cmd.Parameters.AddWithValue("var_EMailparam", UserData.EMail);
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
                string ConnString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();

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
