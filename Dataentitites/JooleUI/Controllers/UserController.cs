using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JooleUI.Models;
using Services;

namespace JooleUI.Controllers
{
    public class UserController : Controller
    {
        /*
         * 
         * This method will be called by the page when the user load the page at first. 
         */
        [HttpGet]
        public ActionResult LoginPage()
        {
            UserLogin temp = new UserLogin();
            return View(temp);
        }

        /*
         *
         * This method will retrive the login information from user and check if the login is accurate
         */
        [HttpPost]
        public ActionResult LoginPage(UserLogin temp)
        {
            Service serv = new Service();
            if (ModelState.IsValid)
            {
                    if (serv.authentication(temp.Login_Name, temp.User_Password))
                    {
                        Session["userID"] = serv.getSessionID(temp.Login_Name, temp.User_Password);
                        return RedirectToAction("GridView", "Home");
                    }
                    else
                    {
                        temp.LoginErrorMessage = "Incrrect username or password.";
                        return View("LoginPage", temp);
                    }
            }
            return View();
        }
    }
}