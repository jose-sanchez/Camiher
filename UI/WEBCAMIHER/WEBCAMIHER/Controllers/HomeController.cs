using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBCAMIHER.Models;

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
            ViewBag.Message = "Nuestros Servicios.";
            ViewBag.OurServicesList = unitOfWork.ContentRepository.Get(S => S.Section.Contains("Nuestros Servicios")).OrderBy(S => S.Order);
            return View();
        }
        public ActionResult Housing()
        {
            ViewBag.Message = "Viviendas.";

            ViewBag.HousingList = unitOfWork.ContentRepository.Get(S=>S.Section.Contains("Viviendas")).OrderBy(S=>S.Order);
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Contacto.";

            ViewBag.ContactList = unitOfWork.ContentRepository.Get(S => S.Section.Contains("Contacto")).OrderBy(S => S.Order);
            return View();
        }
        public ActionResult Products()
        {
            ViewBag.Message = "Maquinas";

            ViewBag.ProductList = unitOfWork.ContentRepository.Get(S => S.Section.Contains("Maquinaria")).OrderBy(S => S.Order);
            return View();
        }

    }
}
