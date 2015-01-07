using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Camiher.Libs.DataProviders;
using Camiher.Libs.Server.DAL.CamiherDAL;
using UnitOfWork = WEBCAMIHER.Models.UnitOfWork;

namespace WEBCAMIHER.Controllers
{

    public class ProductsController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult ListProducts()
        {

            ViewBag.ProductList = DataProvidersFactory.GetBusinessOperationProvider().GetProductsToSale(GetCulture());
            
            return View();
        }

        public ActionResult ProductDescription(string productId)
        {
            IEnumerable<ProductsSet> products = (IEnumerable<ProductsSet>) DataProvidersFactory.GetBusinessOperationProvider()
                .GetProductsToSale(GetCulture());
            ViewBag.Product = products.First(s => s.Id == productId);
                DataProvidersFactory.GetBusinessOperationProvider()
                    .GetProductsToSale(GetCulture());
                ViewBag.ProductImages = DataProvidersFactory.GetBusinessOperationProvider().GetProductImages(productId).ProductsImages.Select(s=>s.Data).ToArray();
            return View();
        }

        private string GetCulture()
        {
            var langCookie = System.Web.HttpContext.Current.Request.Cookies["lang"];
            string language;
            if (langCookie != null)
            {
                return  langCookie.Value;
            }
            else
            {
                return "es";
            }
        }

    }
}
