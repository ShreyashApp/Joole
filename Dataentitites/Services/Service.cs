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

        public string value()
        {

            var a =  uow.users.find(1);
            if (a.User_ID!=0)
                return a.User_Name;
            else
                return null;

        }

        public tblProduct value(int c)
        {

            var a = uow.prods.find(c);
           
            return a;
        }

        public tblManufacturer manudetails(int c)
        {
            var a = uow.manu.find(c);

            return a;
        }

        public tblType typedetails(int c)
        {
            var a = uow.prodtype.find(c);

            return a;
        }


    }
}