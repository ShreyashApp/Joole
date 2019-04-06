using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using JooleUI.Models;
using Newtonsoft.Json;

namespace JooleUI.Controllers
{
    public class SearchController : Controller
    {
        // GET: CategoryAndSub
        [HttpGet]
        public ActionResult Index()
        {
            //List<Category> listObj = new List<Category>();
            Dictionary<string, List<string>> cateAndSubCate = new Dictionary<string, List<string>>();
            foreach (var tempCatego in new Services.Service().getCategories())
            {

                //Category tempCategory = new Category();
                //SubCategory tempSubCategory = new SubCategory();
                //tempCategory.Category_Name = tempCatego.Category_Name;
                string categoryVal = tempCatego.Category_Name;
                
                List<string> subCategoList = new List<string>();

                foreach (var temp in new Services.Service().GetSubCategories(tempCatego.Category_ID))
                {
                    subCategoList.Add(temp.SubCategory_Name);
                }
                //tempSubCategory.SubCategory_Name = subCategoList;
                //listObj.Add(tempSearchObj);
                cateAndSubCate.Add(categoryVal, subCategoList);

            }
            //var asdfw = cateAndSubCate.Values;
            //var asdf = cateAndSubCate.Keys;
            ViewBag.Category = new SelectList(cateAndSubCate.Keys, "Category_Name", "Category_Name");
            var asdf = JsonConvert.SerializeObject(cateAndSubCate);
            return Json(asdf, JsonRequestBehavior.AllowGet);
        }

    }
}