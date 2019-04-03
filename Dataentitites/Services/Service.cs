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

            tblUser us = new tblUser();
            us.User_Email = uemail;
            us.User_Password = upass;
            List<tblUser> a = uow.users.find(us).ToList();
            if (a.Count > 0)
            {
                if (a.First().User_Email == uemail && a.First().User_Password == upass)
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

            tblUser us = new tblUser();
            us.User_Name = uname;
            us.User_Password = upass;
            List<tblUser> a = uow.users.find(us).ToList();
            if (a.Count > 0)
            {
                if (a.First().User_Name == uname && a.First().User_Password == upass)
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
    }
}