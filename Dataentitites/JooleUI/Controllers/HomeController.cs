using System.Collections.Generic;
using System.Web.Mvc;
using Services;
using JooleUI.Models;
using Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace JooleUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Summa(int id)
        {
            TempData["ids"] = id;
            return View();
        }

        public JsonResult Summ()
        {
            int vag = (int)TempData["ids"];
            Service serv = new Service();
            List<Products> va = new List<Products>();
            {
                Products val = new Products();
                var a = serv.value(vag);
                val.Product_Name = a.Product_Name;
                val.Model = a.Model;
                val.Series = a.Series;
                val.Product_Image = a.Product_Image;
                //JObject json = JObject.Parse(a.Characteristics);
                val.Object = a.Characteristics;
                //Response.Write(val.Object);
                var b = serv.manudetails(a.Manufacturer_ID);
                val.Manufacturer_Name = b.Manufacturer_Name;
                var c = serv.typedetails(a.ProductTypeID);
                val.UseType = c.UseType;
                val.Application = c.Application;
                val.ModelYear = c.ModelYear;
                val.MountingLocation = c.MountingLocation;
                va.Add(val);
            }
            var cha = JsonConvert.SerializeObject(va);
            return Json(cha, JsonRequestBehavior.AllowGet);

        }

        public ActionResult GridView()
        {
            return View();
        }

        public ActionResult Black()
        {
            return View();
        }

        public JsonResult Blacks()
        {
            int[] comp = (int[])TempData["camp"];
            Service serv = new Service();
            List<Products> va = new List<Products>();
            for (int i = 0; i < comp.Length; i++)
            {
                Products val = new Products();
                var a = serv.value(comp[i]);
                val.Product_Name = a.Product_Name;
                val.Model = a.Model;
                val.Series = a.Series;
                val.Product_Image = a.Product_Image;
                //JObject json = JObject.Parse(a.Characteristics);
                val.Object = a.Characteristics;
                //Response.Write(val.Object);
                var b = serv.manudetails(a.Manufacturer_ID);
                val.Manufacturer_Name = b.Manufacturer_Name;
                var c = serv.typedetails(a.ProductTypeID);
                val.UseType = c.UseType;
                val.Application = c.Application;
                val.ModelYear = c.ModelYear;
                val.MountingLocation = c.MountingLocation;
                va.Add(val);
            }
            var outs = JsonConvert.SerializeObject(va);
            return Json(outs, JsonRequestBehavior.AllowGet);
        }

    }
}