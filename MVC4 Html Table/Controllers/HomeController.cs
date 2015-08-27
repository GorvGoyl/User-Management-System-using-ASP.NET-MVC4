using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC4_Html_Table.Models;
using BusinessAccessLayer;
using Newtonsoft.Json;
using log4net;
namespace MVC4_Html_Table.Controllers
{
    public class HomeController : Controller
    {
        private static readonly ILog Logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ActionResult Index()
        {
            Logger.Debug("Method Start");
            string JsonUserData = BusinesLayerCode.Retrieve();
            try
            {
                List<User> UserData = JsonConvert.DeserializeObject<List<User>>(JsonUserData);
                ViewData["UserData"] = UserData;
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
            return View();
        }

        public ActionResult Create()
        {
            Logger.Debug("Method Start");

            Logger.Debug("Method End");
            return RedirectToAction("Edit", "Home", new { guid = 0 });

        }

        //[HttpPost]
        //public ActionResult Create(User user)
        //{

        //Logger.Debug("Method Start");
        //if (ModelState.IsValid)
        //{

        //Guid NewGUID = Guid.NewGuid();
        //user.GUID = NewGUID.ToString();
        ////    string JsonUser = JsonConvert.SerializeObject(user);
        //    Logger.Debug(JsonUser);
        //    BusinesLayerCode.AddUser(JsonUser);
        //    ViewBag.Message = "Successfully Registration Done";
        //    return RedirectToAction("Index", "Home");
        //}

        //Logger.Debug("Method End");
        //return View();

        //    }

        public ActionResult Edit(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);
            if (guid != "0")
            {
                string JsonUser = BusinesLayerCode.Edit(guid);
                User user = JsonConvert.DeserializeObject<User>(JsonUser);
                Logger.Debug("Method End");
                return View(user);
            }
            Logger.Debug("Method End");
            
            return View(new User());
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            Logger.Debug("Method Start");
            if (ModelState.IsValid)
            {
                if (user.GUID == "0")    //If it's a new User
                {
                    Guid NewGUID = Guid.NewGuid();
                    user.GUID = NewGUID.ToString();
                    string JsonUser = JsonConvert.SerializeObject(user);
                    BusinesLayerCode.AddUser(JsonUser);
                    Logger.Debug(JsonUser);
                }
                else    //update the existing user
                {

                    string JsonUser = JsonConvert.SerializeObject(user);
                    BusinesLayerCode.Update(JsonUser);
                    Logger.Debug(JsonUser);
                    
                }
                Logger.Debug("Method End");
                return RedirectToAction("Index", "Home");
            }
            return View(user);

        }

        public ActionResult Delete(string guid)
        {
            Logger.Debug("Method Start");
            Logger.Debug(guid);


            BusinesLayerCode.DeleteUser(guid);

            Logger.Debug("Method End");
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Demo()
        {
            Logger.Debug("Method Start");
            string JsonUserData = BusinesLayerCode.Retrieve();
            try
            {
                List<User> UserData = JsonConvert.DeserializeObject<List<User>>(JsonUserData);
                ViewData["UserData"] = UserData;
            }
            catch (Exception exception)
            {
                Logger.Debug(exception.Message, exception);
                throw exception;
            }
            Logger.Debug("Method End");
            return View();
        }
    }
}
