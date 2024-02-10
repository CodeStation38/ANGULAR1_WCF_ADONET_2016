using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Areas.PagoAutomatico.Controllers
{
    public class AmbTablasController : Controller
    {
        //
        // GET: /PagoAutomatico/AmbTablas/
        public ActionResult Index()
        {
            return PartialView();
        }

        public ActionResult ModalDelete()
        {
            return PartialView();
        }

        public ActionResult ModalAM()
        {
            return PartialView();
        }



	}
}