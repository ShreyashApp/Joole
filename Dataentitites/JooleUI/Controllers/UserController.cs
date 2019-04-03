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
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult LoginPage()
        {
            UserLogin temp = new UserLogin();
            return View(temp);
        }

        [HttpPost]
        public ActionResult LoginPage(UserLogin temp)
        {
            Service serv = new Service();

            if (ModelState.IsValid)
            {
                if (loginUser(temp) == "email")
                {
                    if (serv.valueEmail(temp.Login_Name, temp.User_Password))
                    {
                        Session["userID"] = serv.getSessionID(temp.Login_Name, temp.User_Password);
                        return RedirectToAction("Index", "Search");
                    }
                    else
                    {
                        //RedirectToAction()
                        temp.LoginErrorMessage = "Incrrect username or password.";
                        return View("LoginPage", temp);
                    }
                }
                else
                {
                    if (serv.valueUser(temp.Login_Name, temp.User_Password))
                    {
                        Session["userID"] = serv.getSessionID(temp.Login_Name, temp.User_Password);
                        return RedirectToAction("Index", "Search");
                    }
                    else
                    {
                        temp.LoginErrorMessage = "Incrrect username or password.";
                        return View("LoginPage", temp);
                    }
                }
            }
            

            return View();
        }


        public string loginUser(UserLogin temp)
        {
            if (temp.Login_Name.Contains("@"))
            {
                return "email";
            }
            else
            {
                return "username";
            }
        }
    }
}