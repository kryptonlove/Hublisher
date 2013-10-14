using Hublisher.Models;
using Hublisher.Services.Beer;
using Hublisher.Services.Establishment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hublisher.Controllers
{
	/// <summary>
	/// Est for Establishment
	/// </summary>
	public class EstController : BaseController
	{
		public IBeerService _beerService;
		public IEstablishmentService _establishmentService;

		public EstController( IBeerService beerService, IEstablishmentService establishmentService ) {
			_beerService = beerService;
			_establishmentService = establishmentService;
		}

		public ActionResult Menu( [Bind( Prefix = "id" )] string establishmentId, [Bind( Prefix = "eid" )] int? beerId ) {
			var beerIdValue = 0;
			if (beerId != null)
				beerIdValue = beerId.Value;

			var model = _establishmentService.GetEstablishment( int.Parse( establishmentId ), beerIdValue );

			return View( model );
		}

		public ActionResult GetEstablishment( string placeName ) {
			var model = _establishmentService.GetEstablishment( placeName );

			return View( "Menu", model );
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Menu( [Bind( Prefix = "id" )] string establishmentId, brand beer ) {
			if (Request != null) {
				if (Request.Form["brand_id"] != String.Empty) {
					beer.id = int.Parse( Request.Form["brand_id"] );
				}
			}

			_beerService.AddBeer( beer, int.Parse( establishmentId ) );

			return RedirectToAction( "addprices", "est", new { id = establishmentId, eid = beer.id } );
		}

		[HttpGet()]
		public ActionResult AddPrices( int id, int eid ) {
			var model = _beerService.GetPrices( id, eid );

			return View( model );
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult AddPrices( establishment_brand model ) {
			model.deleted = false;
			_beerService.AddPrices( model, int.Parse( RouteData.Values["id"].ToString() ), int.Parse( RouteData.Values["eid"].ToString() ) );

			return RedirectToAction( "addprices", "est", new { id = model.establishment_id, eid = model.brand_id } );
		}
	}
}
