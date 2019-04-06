using System.Collections.Generic;
using System.Web.Mvc;
using Services;
using JooleUI.Models;
using Json;
using Newtonsoft.Json.Linq;

namespace JooleUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            Service serv = new Service();

            string vals = "Your application description page." + serv.Value();
            ViewBag.Message = vals; 

            return View();
        }

        public ActionResult Contact()
        {
           
            string vals = "Your application description page." ;

            ViewBag.Message = vals;

            return View();
        }

        public ActionResult GridView()
        {
            Service serv = new Service();
            List<Products> va = new List<Products>();
            //List<JObject> ls = new List<JObject>();
            for(int i = 1; i < 3; i++) {
                Products val = new Products();
                var a = serv.value(i);
                val.Product_Name = a.Product_Name;
                val.Model = a.Model;
                val.Series = a.Series;
                val.Product_Image = a.Product_Image;
                val.Charecteristics = a.Characteristics;
                //JObject json = JObject.Parse(a.Characteristics);
                //val.Object = json;
                //foreach(var key in json)
                //Response.Write(key.Value);
                var b = serv.manudetails(a.Manufacturer_ID);
                val.Manufacturer_Name = b.Manufacturer_Name;
                var c = serv.typedetails(a.ProductTypeID);
                val.UseType = c.UseType;
                val.Application = c.Application;
                val.ModelYear = c.ModelYear;
                val.MountingLocation = c.MountingLocation;
                va.Add(val);
            }

            return View(va);
        }

    }
}