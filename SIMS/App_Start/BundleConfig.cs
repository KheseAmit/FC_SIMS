using System.Web;
using System.Web.Optimization;

namespace UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*",                       
                           "~/bower_components/jquery/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      //"~/Scripts/bootstrap.js",
                      //"~/Scripts/respond.js",
                      "~/bower_components/bootstrap/dist/js/bootstrap.min.js",
                        "~/Scripts/BootstrapJS/jquery.cookie.js",
                        "~/bower_components/moment/min/moment.min.js",
                        "~/bower_components/fullcalendar/dist/fullcalendar.min.js",
                        "~/Scripts/BootstrapJS/jquery.dataTables.min.js",
                        "~/bower_components/chosen/chosen.jquery.min.js",
                        "~/bower_components/colorbox/jquery.colorbox-min.js",
                        "~/Scripts/BootstrapJS/jquery.noty.js",
                        "~/bower_components/responsive-tables/responsive-tables.js",
                        "~/bower_components/bootstrap-tour/build/js/bootstrap-tour.min.js",
                        "~/Scripts/BootstrapJS/jquery.raty.min.js",
                        "~/Scripts/BootstrapJS/jquery.iphone.toggle.js",
                        "~/Scripts/BootstrapJS/jquery.autogrow-textarea.js",
                        "~/Scripts/BootstrapJS/jquery.uploadify-3.1.min.js",
                        "~/Scripts/BootstrapJS/jquery.history.js",
                        "~/Scripts/BootstrapJS/charisma.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      //"~/Content/bootstrap.css",
                      //"~/Content/site.css",
                      // "~/Content/bootstrap-united.min.css",
                       "~/Content/charisma-app.css",
                       "~/bower_components/fullcalendar/dist/fullcalendar.css",
                       "~/bower_components/fullcalendar/dist/fullcalendar.print.css",
                       "~/bower_components/chosen/chosen.min.css",
                       "~/bower_components/colorbox/example3/colorbox.css",
                       "~/bower_components/responsive-tables/responsive-tables.css",
                       "~/bower_components/bootstrap-tour/build/css/bootstrap-tour.min.css",
                       "~/Content/jquery.noty.css",
                       "~/Content/noty_theme_default.css",
                       "~/Content/elfinder.min.css",
                       "~/Content/elfinder.theme.css",
                       "~/Content/jquery.iphone.toggle.css",
                       "~/Content/uploadify.css",
                       "~/Content/animate.min.css"));

        }
    }
}
