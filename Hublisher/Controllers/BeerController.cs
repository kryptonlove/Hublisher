using Hublisher.Models;
using Hublisher.Services.Beer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hublisher.Controllers
{
	public class BeerController : BaseController
	{
		public BeerController( IBeerService beerService ) {
			beerService.Database = base.database;
			_beerService = beerService;
		}

		public IBeerService _beerService;

		public ActionResult AddBeers( int id, [Bind( Prefix = "eid" )] int? beerId ) {
			var beerIdValue = 0;
			if (beerId != null)
				beerIdValue = beerId.Value;

			var model = _beerService.GetBeer( id, beerIdValue );

			return View( model );
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult AddBeers( string id, brand beer ) {
			if (Request != null) {
				if (Request.Form["brand_id"] != String.Empty) {
					beer.id = int.Parse( Request.Form["brand_id"] );
				}
			}

			_beerService.AddBeer( beer, int.Parse( id ) );

			return RedirectToAction( "addprices", "beer", new { id = id, eid = beer.id } );
		}

		[HttpGet()]
		public ActionResult AddPrices( int id, int eid ) {
			var model = _beerService.GetPrices( id, eid );

			return View( model );
		}

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult AddPrices( establishment_brand model ) {
			_beerService.AddPrices( model, int.Parse( RouteData.Values["id"].ToString() ), int.Parse( RouteData.Values["eid"].ToString() ) );

			return RedirectToAction( "addprices", "beer", new { id = model.establishment_id, eid = model.brand_id } );
		}
	}
}
