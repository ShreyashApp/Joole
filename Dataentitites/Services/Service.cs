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

        

        public bool valueEmail(string uemail, string upass)
        {
            List<tblUser> fliteredList = filteredList(uemail, upass);
            if (fliteredList.Count > 0)
            {
                if (fliteredList.First().User_Email == uemail && fliteredList.First().User_Password == upass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }else
            {
                return false;
            }
            

        }

        public bool valueUser(string uname, string upass)
        {
            List<tblUser> fliteredList = filteredList(uname, upass);
            if (fliteredList.Count > 0)
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
            else
            {
                return false;
            }


        }

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

        public int getSessionID(string uname, string upass)
        {
            List<tblUser> fliteredList = filteredList(uname, upass);
            return fliteredList.First().User_ID;
        }
    }
}