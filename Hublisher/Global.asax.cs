using Hublisher.App_Start;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject.Activation;
using Ninject.Web.Common;
using System.Configuration;

namespace Hublisher
{
	// Note: For instructions on enabling IIS6 or IIS7 classic mode, 
	// visit http://go.microsoft.com/?LinkId=9394801
	public class HublisherApp : NinjectHttpApplication
	{
		protected override void OnApplicationStarted() {
			base.OnApplicationStarted();

			AreaRegistration.RegisterAllAreas();

			WebApiConfig.Register( GlobalConfiguration.Configuration );
			FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
			RouteConfig.RegisterRoutes( RouteTable.Routes );
			BundleConfig.RegisterBundles( BundleTable.Bundles );

			UpdateGlobals();
		}

		protected override IKernel CreateKernel() {
			var kernel = new StandardKernel();
			kernel.Load( Assembly.GetExecutingAssembly() );
			return kernel;
		}



		private static string _connection;
		public static void UpdateGlobals() {
			if (string.IsNullOrEmpty( _connection )) {
				_connection = ConfigurationManager.ConnectionStrings["hublisherConnectionString"].ConnectionString;
			}
			
			HubStoreDataContext database = new HubStoreDataContext( _connection );

			_allBrands = database.brands.ToList();
			_allEstablishments = database.establishments.ToList();
		}

		public static List<establishment> _allEstablishments;
		public static List<brand> _allBrands;
	}
}