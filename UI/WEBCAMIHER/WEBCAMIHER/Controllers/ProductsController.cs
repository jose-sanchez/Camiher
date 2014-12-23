using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            this.Session["Culture"] = "Spanish";
            ViewBag.ProductList = DataProvidersFactory.GetBusinessOperationProvider().GetProductsToSale(this.Session["Culture"].ToString());
            
            return View();
        }

        public ActionResult ProductDescription(ProductsSet product)
        {
            ViewBag.Product = product;
            ViewBag.ProductImages = DataProvidersFactory.GetBusinessOperationProvider().GetProductImages(product.Id);
            return View();
        }

    }
}
