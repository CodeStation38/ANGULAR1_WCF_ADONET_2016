using System;
using System.Web.Mvc;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Castle.Facilities.Logging;


namespace WebApplication.Installers
{
    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<WcfFacility>(f => f.CloseTimeout = TimeSpan.Zero);
            

           /* container.Register(Classes.FromThisAssembly()
                .BasedOn<IController>()
                .LifestyleTransient(),
                        Component.For<LoggingInterceptor>().LifeStyle.PerWebRequest,
                 Component.For<AdhesionService.IBusqueda>().AsWcfClient(
                            new DefaultClientModel { Endpoint = WcfEndpoint.FromConfiguration("epBusqueda") }
                        ).LifestylePerWebRequest()
            
                        
                         
               );*/
        }
    }
}