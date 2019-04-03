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
                        //load a search method in search controller
                        //return Redirect("some action", "some controller");
                    }
                    else
                    {
                        //RedirectToAction()
                    }
                }
                else
                {
                    if (serv.valueUser(temp.Login_Name, temp.User_Password))
                    {

                    }
                    else
                    {

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