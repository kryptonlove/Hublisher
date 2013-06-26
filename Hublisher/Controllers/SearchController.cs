using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hublisher.Controllers
{
	public class SearchController : BaseController
	{
		[HttpGet]
		public JsonResult Places( [Bind( Prefix = "id" )] string city, [Bind( Prefix = "eid" )] string place ) {
			var json = HublisherApp._allEstablishments.Where( e => e.city.Equals( city, StringComparison.OrdinalIgnoreCase ) ).Where( e => e.name.StartsWith( place, StringComparison.OrdinalIgnoreCase ) ).Select( e => e ).ToList();

			return new JsonResult { Data = json.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		[HttpGet]
		public JsonResult Brands( [Bind( Prefix = "id" )] string brand) {
			var json = HublisherApp._allBrands.Where( e => e.name.StartsWith( brand, StringComparison.OrdinalIgnoreCase ) ).Select( e => e ).ToList();

			return new JsonResult { Data = json.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}


		[HttpPost]
		public ActionResult Places( FormCollection form ) {
			var id = form["hidden_id"];

			if (string.IsNullOrWhiteSpace( id )) {
				return RedirectToAction( "add", "home", new { nothingFound = true } );
			}

			return RedirectToAction( "addbeers", "beer", new { id = id } );
		}
	}
}
