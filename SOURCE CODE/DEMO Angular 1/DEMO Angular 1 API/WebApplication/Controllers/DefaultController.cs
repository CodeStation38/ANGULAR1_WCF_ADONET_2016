using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Layout()
        {
            return View();
        }

        public ActionResult AlertModal()
        {
            return PartialView();
        }

        public ActionResult ModalConfirm()
        {
            return PartialView();
        }
    }
}