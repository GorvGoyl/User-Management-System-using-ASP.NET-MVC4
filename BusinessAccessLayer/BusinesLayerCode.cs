using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccessLayer;
using Models;
using System.Net;
namespace BusinessAccessLayer
{
    public class BusinesLayerCode
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static List<User> Retrieve()
        {
            Logger.Debug("Method Start");
            Logger.Debug("Method End");
            List<User> UserData= DataLayerCode.RetrieveAllData();
            return UserData;

        }

        public static User Edit(string guid)
        {
            Logger.Debug("Method Start");
            User UserData = DataLayerCode.RetrieveUser(guid);
            Logger.Debug("Method End");
            return UserData;

        }

        public static void AddUser(List<string> userData)
        {
            Logger.Debug("Method Start");
            Logger.Debug(userData);
            try
            {
                DataLayerCode.AddUserToDB(userData);
            }
            catch (WebException exception)
            {
                throw exception;
            }
            Logger.Debug("Method End");

        }
        public static void Update(List<string> userData)
        {
            Logger.Debug("Method Start");
            Logger.Debug(userData);
            DataLayerCode.UpdateUser(userData);

            Logger.Debug("Method End");

            //return DataLayerCode.RetrieveData();

        }

        public static void DeleteUser(string guid)
        {
            Logger.Debug("Method Start");
            DataLayerCode.DeleteUser(guid);
            Logger.Debug("Method End");
        }

    }
}
//public static string ValidateUser(string username, string password)
//{
//   // Logger.Debug("Method Start");
//    //Will write code for validate user from our own database 
//    using (MySqlConnection Con = DataAccessLayer.DataAccessLayer.GetConnection())
//    {
//        try
//        {
//            Con.Open();
//            MySqlCommand Comm = Con.CreateCommand();
//            Comm.CommandText = "Select * from user_data  WHERE UserName = @UserName and Passwords = @Password";
//            Comm.Parameters.AddWithValue("@UserName", username);
//            Comm.Parameters.AddWithValue("@Password", password);
//            string JsonUser = "";
//            MySqlDataReader Reader = Comm.ExecuteReader();

//            while (Reader.Read())
//            {
//                List<string> UserData = new List<string>();
//                UserData.Add(Reader["UserName"].ToString());
//                UserData.Add(Reader["Passwords"].ToString());
//                UserData.Add(Reader["Phone"].ToString());
//                UserData.Add(Reader["City"].ToString());
//                JsonUser = JsonConvert.SerializeObject(UserData, Formatting.Indented);
//            }
//        //    Logger.Debug("Method End");
//            return JsonUser;
//        }
//        catch (Exception exception)
//        {

//            //Logger.Debug(exception);
//            throw exception;
//        }


//    }

//}


