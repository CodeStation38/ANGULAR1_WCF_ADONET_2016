using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.ParametriaService;

namespace WebApplication.Areas.PagoAutomatico.Controllers
{
    public class ParametriaController : Controller
    {
        #region Singleton Repositorio

        ParametriaServiceClient repositorio = null;

        public ParametriaServiceClient Repositorio
        {
            get
            {
                if (repositorio == null)
                {
                    repositorio = new ParametriaServiceClient();
                }
                return repositorio;
            }
        }
        #endregion
        
        [HttpGet]
        public JsonResult BuscarTiposDocumento()
        {
            List<TipoDocumentoDto> oDocumentos = Repositorio.buscarTiposDocumento();
            return Json(oDocumentos, JsonRequestBehavior.AllowGet);
        }
        
        
        [HttpGet]
        [ActionName("BuscarTiposAdhesion")]
        public JsonResult BuscarTiposAdhesion()
        {
            List<TipoAdhesionDto> ObjTiposAdhesion = new List<TipoAdhesionDto>();
            ObjTiposAdhesion = Repositorio.buscarTiposAdhesion();
            return Json(ObjTiposAdhesion, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        [ActionName("BuscarTiposMonto")]
        public JsonResult BuscarTiposMonto()
        {
            List<TipoMontoDto> ObjTiposMonto = new List<TipoMontoDto>();
            ObjTiposMonto = Repositorio.buscarTiposMonto();
            return Json(ObjTiposMonto, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        [ActionName("BuscarTiposCuenta")]
        public JsonResult BuscarTiposCuenta()
        {
            List<TipoCuentaDto> ObjTiposCuenta = new List<TipoCuentaDto>();
            ObjTiposCuenta = Repositorio.buscarTiposCuenta();
            return Json(ObjTiposCuenta, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        [ActionName("BuscarBancos")]
        public JsonResult BuscarBancos()
        {
            List<BancoDto> ObjBancos = new List<BancoDto>();
            ObjBancos = Repositorio.buscarBancos();
            return Json(ObjBancos, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("ObtenerTabla")]
        public JsonResult ObtenerTabla(string nameTabla)
        {
            List<Dictionary<string, object>> ObjTabla;
            ObjTabla = Repositorio.obtenerTablaDatos(nameTabla);
            return Json(ObjTabla, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("BuscarTablas")]
        public JsonResult BuscarTablas(string modulo)
        {
            List<atb_abm_tablaDto> ObjTablas;
            ObjTablas = Repositorio.buscarTablas(modulo);
            return Json(ObjTablas, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [ActionName("BuscarModulos")]
        public JsonResult BuscarModulos()
        {
            List<ModuloDto> ObjModulos;
            ObjModulos = Repositorio.buscarModulos();
            return Json(ObjModulos, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        [ActionName("ObtenerTablaCompleta")]
        public JsonResult ObtenerTablaCompleta(string nameTabla)
        {
            AbmTablaDto ObjTabla;
            ObjTabla = Repositorio.obtenerTabla(nameTabla);
            return Json(ObjTabla, JsonRequestBehavior.AllowGet);
        }



    }
}