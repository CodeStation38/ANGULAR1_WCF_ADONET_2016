using System.Web.Mvc;

namespace WebApplication.Areas.PagoAutomatico
{
    public class PagoAutomaticoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "PagoAutomatico";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "PagoAutomatico_default",
                "PagoAutomatico/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}