using System.Web;
using System.Web.Optimization;

namespace WebApplication
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            var style = new StyleBundle("~/Content/bundles").Include(
                                                              "~/Content/Css/angular-block-ui.css",
                                                              "~/Content/Css/angular-growl.css",
                                                              "~/Content/Css/bootstrap.css",
                                                              "~/Content/Css/jquery.loader.css",
                                                              "~/Content/Css/ng-grid.css",
                                                              "~/Content/Css/slidebars.css",
                                                              "~/Content/Css/style.css",
                                                              "~/Content/Css/style-responsive.css",
                                                              "~/Content/Css/font-awesome.css",
                                                              "~/Content/Css/Animation.css",
                                                              "~/Content/Css/main.css",
                                                              "~/Content/Css/loading-bar.css"
                                                              
                                                          );
            bundles.Add(style);
            bundles.Add(new ScriptBundle("~/bundles/general").Include(

                                     "~/Scripts/General/jquery.js",
                                     "~/Scripts/General/angular.js",
                                     "~/Scripts/General/bootstrap.js",
                                     "~/Scripts/General/angular-animate.js",
                                     "~/Scripts/General/angular-aria.js",
                                     "~/Scripts/General/angular-cookies.js",
                                     "~/Scripts/General/angular-messages.js",
                                     "~/Scripts/General/angular-resource.js",
                                     "~/Scripts/General/angular-route.js",
                                     "~/Scripts/General/angular-sanitize.js",
                                     "~/Scripts/General/angular-touch.js",
                                     "~/Scripts/General/angular-growl.js",
                                     "~/Scripts/General/angular-block-ui.js",
                                     "~/Scripts/General/ui-bootstrap-tpls.js",
                                     "~/Scripts/General/ng-grid-2.0.14.min.js",
                                     "~/Scripts/General/exportCsv.js",
                                     "~/Scripts/General/mask_1.js",
                                     "~/Scripts/General/jquery.loader.js",
                                     "~/Scripts/General/angular-ui-router.js",
                                     "~/Scripts/General/angular-locale_es-es.js",
                                     "~/Scripts/General/angular-filter.js",

                                     "~/Scripts/General/jquery.dcjqaccordion.2.7.js",
                                     "~/Scripts/General/jquery.scrollTo.min.js",
                                     "~/Scripts/General/jquery.maskMoney.js",
                                     "~/Scripts/General/jquery.nicescroll.js",
                                     "~/Scripts/General/jquery.customSelect.min.js",
                                     "~/Scripts/General/respond.min.js",

                                     "~/Scripts/General/slidebars.min.js",
                                     "~/Scripts/General/common-scripts.js",
                                     "~/Scripts/General/count.js",
                                     "~/Scripts/General/loading-bar.js"

));
            bundles.Add(new ScriptBundle("~/bundles/angularApp").Include(
                                  "~/Scripts/Config/app.js",
                                  

                                   "~/Scripts/Controllers/abmTablasCtrl.js",


                                   "~/Scripts/Factories/abmTablasFactory.js",

                                   "~/Scripts/Services/abmTabla.js",


                                   "~/Scripts/Config/State/State_Abm.js",


));
        }
    }
}
