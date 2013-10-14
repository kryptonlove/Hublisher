using Hublisher.Services.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hublisher.Controllers
{
	public class SearchController : BaseController
	{
		public readonly ISearchService _service;
		public SearchController(ISearchService service) {
			_service = service;
		}

		[HttpGet]
		public JsonResult Places( [Bind( Prefix = "id" )] string city, [Bind( Prefix = "eid" )] string place ) {
			var json = HublisherApp._allEstablishments.Where( e => e.city.Equals( city, StringComparison.OrdinalIgnoreCase ) ).Where( e => e.name.StartsWith( place, StringComparison.OrdinalIgnoreCase ) ).Select( e => e ).ToList();

			return new JsonResult { Data = json.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		[HttpGet]
		public JsonResult Brands( [Bind( Prefix = "id" )] string brand ) {
			var json = HublisherApp._allBrands.Where( e => e.name.StartsWith( brand, StringComparison.OrdinalIgnoreCase ) ).Select( e => e ).ToList();

			return new JsonResult { Data = json.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		[HttpGet]
		public JsonResult Cities( [Bind( Prefix = "id" )] string city ) {
			var cities = HublisherApp._allEstablishments.Select( e => e.city ).Distinct();
			var json = cities.Where( e => e.StartsWith( city, StringComparison.OrdinalIgnoreCase ) ).Distinct().Select( e => e ).ToList();

			return new JsonResult { Data = json.ToArray(), JsonRequestBehavior = JsonRequestBehavior.AllowGet };
		}

		public ActionResult BarSearch( [Bind( Prefix = "id" )] string city ) {
			var model = _service.SearchBars( city );

			return View( model );
		}

		[HttpPost]
		public ActionResult Places( FormCollection form ) {
			var id = form[ "hidden_id" ];

			if( string.IsNullOrWhiteSpace( id ) && string.IsNullOrWhiteSpace( form[ "placename" ] ) ) {
				//city search
				return RedirectToAction( "barsearch", "search", new { id = form[ "searchcity" ] } );
			} else if( string.IsNullOrWhiteSpace( id ) && !string.IsNullOrWhiteSpace( form[ "placename" ] ) ) {
				//nothing found based on the id pushed into the controller
				return RedirectToAction( "add", "home", new { nothingFound = true } );
			}

			return RedirectToAction( "menu", "est", new { id = id } );
		}
	}
}
