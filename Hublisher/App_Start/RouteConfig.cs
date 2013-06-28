using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hublisher
{
	public class CityConstraint : IRouteConstraint
	{
		public bool Match( HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection ) {
			var q = values[parameterName];

			if (!q.ToString().Contains( "/" )) {
				var vals = q.ToString();

				if (HublisherApp._allEstablishments.Where( x => x.name.Equals( vals, StringComparison.InvariantCultureIgnoreCase ) ).Count() > 0) {
					values.Add( "placename", vals );
					return true;
				}
			}

			return false;
		}
	}

	public class RouteConfig
	{
		public static void RegisterRoutes( RouteCollection routes ) {
			routes.IgnoreRoute( "{resource}.axd/{*pathInfo}" );

			routes.MapRoute(
				name: "FriendlyUrl",
				url: "{*query}",
				defaults: new { controller = "Beer", action = "GetEstablishment", query = UrlParameter.Optional },
				constraints: new { query = new CityConstraint() }
			);


			routes.MapRoute(
				name: "Default2",
				url: "{controller}/{action}/{id}/{eid}",
				defaults: new { controller = "Home", action = "Add", id = UrlParameter.Optional }
			);

			routes.MapRoute(
				name: "Default",
				url: "{controller}/{action}/{id}",
				defaults: new { controller = "Home", action = "Add", id = UrlParameter.Optional }
			);
		}
	}
}