using System.Web;
using System.Web.Optimization;

namespace FarmTradeApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                        "~/Scripts/app/features/months.js",
                        "~/Scripts/app/datatables/datatablesOptions.js",
                        "~/Scripts/app/services/marketEntryService.js",
                        "~/Scripts/app/services/auctionService.js",
                        "~/Scripts/app/services/auctionSettleService.js",
                        "~/Scripts/app/services/storageService.js",
                        "~/Scripts/app/services/tradeMatchService.js",
                        "~/Scripts/app/controllers/storageController.js",
                        "~/Scripts/app/controllers/marketController.js",
                        "~/Scripts/app/controllers/marketEntryDetailsController.js",
                        "~/Scripts/app/controllers/marketEntriesController.js",
                        "~/Scripts/app/controllers/myMarketEntriesController.js",
                        "~/Scripts/app/controllers/auctionManageController.js",
                        "~/Scripts/app/controllers/myTradeMatchesController.js",
                        "~/Scripts/app/features/countdownTimer.js",
                        "~/Scripts/app/features/months.js",
                        "~/Scripts/app/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                         "~/Scripts/moment.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/underscore.min.js",
                        "~/Scripts/DataTables/jquery.datatables.js",
                        "~/Scripts/DataTables/jquery.datatables.min.js",
                        "~/Scripts/DataTables/dataTables.select.min.js",
                        "~/Scripts/DataTables/dataTables.buttons.min.js",
                        "~/Scripts/DataTables/datatables.bootstrap.js",
                        "~/Scripts/DataTables/dataTables.bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      //"~/Content/bootstrap.min.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/animate.css",
                      "~/Content/site.css"));
        }
    }
}
