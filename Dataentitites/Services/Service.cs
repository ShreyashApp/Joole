using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RepoBLL;
using System.Data;
using Dataentitites;
using System.Data.Entity;

namespace Services
{
    public class Service
    {
        static string vals = "metadata=res://*/Model1.csdl|res://*/Model1.ssdl|res://*/Model1.msl;provider=System.Data.SqlClient;provider connection string='Data Source=localhost;User ID=SHREYASH_APPIKA\\SVP;initial catalog=Joole;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;'";
        static DbContext context = new DbContext(vals);

        UnitofWork uow = new UnitofWork(context);

        public string Value()
        {
            var a = uow.users.Find(1);
            if (a.User_ID != 0)
                return a.User_Name;
            else
                return null;
        }

        public string ProductValue()
        {
            string s = "";
            var a = uow.products.Find(1);
            var b = uow.products.Find(2);
            var c = uow.products.Find(3);
            var d = uow.products.Find(4);
            var e = uow.products.Find(5);
            if (a.Product_ID != 0)
                s += a.Product_Name + " ";
            if (b.Product_ID != 0)
                s += b.Product_Name + " ";
            if (c.Product_ID != 0)
                s += c.Product_Name + " ";
            if (d.Product_ID != 0)
                s += d.Product_Name + " ";
            if (e.Product_ID != 0)
                s += e.Product_Name + " ";
            return s;
        }

        public string ProductSearch(string s)
        {
            string result = uow.products.Search(s);
            return result;
        }

        public IQueryable<tblProduct> GetDataSet(string filter)
        {
            return uow.products.DataSet(filter);
        }
    }
}