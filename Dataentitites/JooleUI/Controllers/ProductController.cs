using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Services;
using JooleUI.Models;
using System.Data;
using System.Net;

namespace JooleUI.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Summary(string searchString, string beginningYear, string endingYear, int[] compare)
        {
            Service serv = new Service();
            string vals = "";

            //if (String.IsNullOrEmpty(searchString))
            //{
            //    vals = "Available products: " + serv.ProductValue();
            //}
            //else
            //{
            //    vals = "Products found: " + serv.ProductSearch(searchString);
            //}
            ViewBag.Message = vals;

            List <ProductVM> productList = new List<ProductVM>();
            var de = serv.GetDataSet(null).AsEnumerable();
            var tde = serv.GetTypeDataSet(null).AsEnumerable();
            if (compare != null && compare.Length > 0)
            {
                de = de.Where(id => compare.Contains(id.Product_ID));
                foreach (var product in de)
                {
                    productList.Add(new ProductVM(product.Product_ID, product.Manufacturer_ID, product.SubCategory_ID,
                        product.Product_Name, product.Series, product.Model, product.ProductTypeID, product.Characteristics));
                }
                return View("Compare", productList);
                //return RedirectToAction("Compare", new {compare});
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                de = de.Where(product => product.Product_Name.Contains(searchString));
                //de = serv.GetDataSet(searchString);
            }

            if (!String.IsNullOrEmpty(beginningYear) && !String.IsNullOrEmpty(endingYear))
            {
                de = from p in de
                     join t in tde on p.ProductTypeID equals t.ProductTypeID
                     where Convert.ToInt32(t.ModelYear) >= Convert.ToInt32(beginningYear)
                     && Convert.ToInt32(t.ModelYear) <= Convert.ToInt32(endingYear)
                     select p;
            }

            else if (!String.IsNullOrEmpty(beginningYear))
            {
                de = from p in de
                     join t in tde on p.ProductTypeID equals t.ProductTypeID
                     where Convert.ToInt32(t.ModelYear) >= Convert.ToInt32(beginningYear)
                     select p;
            }

            else if (!String.IsNullOrEmpty(endingYear))
            {
                de = from p in de
                     join t in tde on p.ProductTypeID equals t.ProductTypeID
                     where Convert.ToInt32(t.ModelYear) <= Convert.ToInt32(endingYear)
                     select p;
            }

            foreach (var product in de)
            {
                productList.Add(new ProductVM(product.Product_ID, product.Manufacturer_ID, product.SubCategory_ID,
                    product.Product_Name, product.Series, product.Model, product.ProductTypeID, product.Characteristics));
            }
            return View(productList);
        }

        public ActionResult Compare()
        {
            return View();
        }

        public ActionResult Compare(int[] compare)
        {
            Service serv = new Service();
            List<ProductVM> productList = new List<ProductVM>();
            var de = serv.GetDataSet(null).AsEnumerable();
            de = de.Where(id => compare.Contains(id.Product_ID));
            foreach (var product in de)
            {
                productList.Add(new ProductVM(product.Product_ID, product.Manufacturer_ID, product.SubCategory_ID,
                    product.Product_Name, product.Series, product.Model, product.ProductTypeID, product.Characteristics));
            }
            return View(productList);
        }


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Summary(string searchString)
        //{
        //    Service serv = new Service();

        //    string vals = "Products found: " + serv.ProductSearch(searchString);
        //    ViewBag.Message = vals;

        //    return View(searchString);
        //}
    }
}