using StomatologyMVC.App_Start;
using System.Web;
using System.Web.Hosting;
using System.Web.Optimization;

namespace StomatologyMVC
{
    public class BundleConfig
    {
        //Дополнительные сведения об объединении см. по адресу: http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            
            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // используйте средство сборки на сайте http://modernizr.com, чтобы выбрать только нужные тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/bundles/320").Include(
                      "~/Content/320andup.css"));

            bundles.Add(new ScriptBundle("~/bundles/myAjax.js").Include(
                        "~/Scripts/myAjax.js"));

            bundles.Add(new ScriptBundle("~/bundles/JavaScript.js").Include(
                        "~/Scripts/JavaScript.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular.js").Include(
                        "~/Scripts/angular.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular-route.js").Include(
                        "~/Scripts/angular-route.min.js"));

            bundles.Add(new StyleBundle("~/bundles/piker.css").Include(
                        "~/Content/datepicker.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/piker.js").Include(
                        "~/Scripts/datepicker.min.js"));

            bundles.Add(new Bundle("~/bundles/partials").Include("~/Partials/HtmlAppPage1.html"));


            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/module.js",
                        "~/Scripts/config.js",
                        "~/Scripts/property.js",                        
                        "~/Scripts/appControl.js",
                        "~/Scripts/allControl.js",
                        
                        "~/Scripts/DirectiveShow.js"));
        }
    }
}
