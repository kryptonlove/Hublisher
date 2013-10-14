using System.Web.Optimization;
using System.Web;

namespace Hublisher.App_Start
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles( BundleCollection bundles ) {
			bundles.IgnoreList.Clear();
			
			//bundles.Add( new ScriptBundle( "~/bundles/bootstrap" ).Include(
			//			"~/Scripts/bootstrap.min.js" ) );

			//bundles.Add( new ScriptBundle( "~/bundles/jquery" ).Include(
			//			"~/Scripts/jquery-{version}.js" ) );

			//bundles.Add( new ScriptBundle( "~/bundles/jqueryui" ).Include(
			//			"~/Scripts/jquery-ui.js",
			//			"~/Scripts/jquery.ui.autocomplete.js" ) );

			//bundles.Add( new ScriptBundle( "~/bundles/jqueryval" ).Include(
			//			"~/Scripts/jquery.formvalidator.min.js*" ) );

			bundles.Add( new StyleBundle( "~/Content/css" ).Include(
					"~/Content/bootstrap.css",
					"~/Content/bootstrap-responsive.min.css",
					"~/content/jquery-ui.css",
					"~/content/validestyle.css" ) );
		}
	}
}