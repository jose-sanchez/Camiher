using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBCAMIHER.Models;
using WEBCAMIHER.Views.Shared;

namespace WEBCAMIHER.Controllers
{
    public class HomeController : Controller
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public ActionResult Index()
        {
            ViewBag.Message = "Camiher";

            return View();
        }

        public ActionResult OurServices()
        {
            ViewBag.Message = SharedStrings.OurServices;
            ViewBag.OurServicesList = unitOfWork.ContentRepository.Get(S => S.Section.Contains("Nuestros Servicios")).OrderBy(S => S.Order);
            return View();
        }
        public ActionResult Housing()
        {
            ViewBag.Message = SharedStrings.Housing;
            ViewBag.HousingList = unitOfWork.ContentRepository.Get(S=>S.Section.Contains("Viviendas")).OrderBy(S=>S.Order);
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = SharedStrings.Contact;

            ViewBag.ContactList = unitOfWork.ContentRepository.Get(S => S.Section.Contains("Contacto")).OrderBy(S => S.Order);
            return View();
        }
        public ActionResult Products()
        {
            ViewBag.Message = SharedStrings.Machinery_for_sale;

            ViewBag.ProductList = unitOfWork.ContentRepository.Get(S => S.Section.Contains("Maquinaria")).OrderBy(S => S.Order);
            return View();
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            var langCookie = new HttpCookie("lang", lang)
            {
                HttpOnly = true
            };
            Response.AppendCookie(langCookie);
            return Redirect(returnUrl);
        }

    }
}
