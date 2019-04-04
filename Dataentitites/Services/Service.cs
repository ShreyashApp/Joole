using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoBLL;
using System.Data;
using System.Data.Entity;
using Dataentitites;

namespace Services
{
    public class Service
    {
        static string vals = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string='Data Source=localhost;User ID=SHREYASH_APPIKA\\SVP;initial catalog=Joole;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;'";
        static DbContext context = new DbContext(vals);

        UnitofWork uow = new UnitofWork(context);

        /*
         * This method will authenticate user information and check if they are valid or not
         * return: true if the user existed, false otherwise
         * args: uname - will take the login username
         *       upass - will take the user password.
         */
        public bool authentication(string uname, string upass)
        {
            List<tblUser> fliteredList = filteredList(uname, upass);
            if (fliteredList.Count > 0)
            {
                if (checker(uname) == "email")
                {
                    if (fliteredList.First().User_Email == uname && fliteredList.First().User_Password == upass)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (fliteredList.First().User_Name == uname && fliteredList.First().User_Password == upass)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                
            }else
            {
                return false;
            }


        }
        
        /*
         * This method will take username and email to perform the query and
         * return filtered list based on the given paramenter
         * return List<tblUser>
         * args: uname - username or email
         *       upass - password
         */
        private List<tblUser> filteredList(string uname, string upass)
        {
            tblUser temp = new tblUser();
            if (checker(uname) == "email")
            {
                temp.User_Email = uname;
                
            }
            else
            {
                temp.User_Name = uname;
            }
            temp.User_Password = upass;
            return uow.users.find(temp).ToList();
        }

        /*
         * This method will check if a given login name is email or username
         * return: email - if it was an email
         *         username - otherwise
         * args: take a login name
         */
        private string checker(string loginName)
        {
            if (loginName.Contains("@"))
            {
                return "email";
            }
            else
            {
                return "username";
            }
        }

        /*
         * this method will return a userID based on the login name and the password given
         * return: userID
         */
        public int getSessionID(string uname, string upass)
        {
            List<tblUser> fliteredList = filteredList(uname, upass);
            return fliteredList.First().User_ID;
        }
    }
}