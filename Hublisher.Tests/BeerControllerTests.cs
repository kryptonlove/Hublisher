using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hublisher.Controllers;
using System.Web.Mvc;
using Hublisher.Services.Beer;
using System.Threading.Tasks;
using Hublisher.Models;


namespace Hublisher.Tests
{
	[TestClass]
	public class BeerControllerTests
	{
		BeerController controller;
		public BeerControllerTests() {
			controller = new BeerController( new BeerService(), connection );
		}

		static string connection = DatabaseConnection.GetTestConnection( false );

		[ClassInitialize]
		public static void Init( TestContext context ) {
			HublisherApp.UpdateGlobals( connection );
		}

		[TestMethod]
		public void Beer_Name_Exists_True() {
			var e = controller._beerService.Exists( "AlE nr 16" );
			Assert.IsTrue( e );

			e = controller._beerService.Exists( "ale NR 16" );
			Assert.IsTrue( e );

			e = controller._beerService.Exists( "aLe nr 16" );
			Assert.IsTrue( e );
		}

		[TestMethod]
		public void Beer_Exists_On_Establishment_True() {
			var e = controller._beerService.Exists( 2, 1 ); //remember to change values that match something existing in the DB

			Assert.IsTrue( e );
		}

		[TestMethod]
		public void Add_New_Beer_True() {
			var beer = new brand();
			beer.country = "TEST country";
			beer.description = "TEST descripion";
			beer.maker = "Refsvindinge";
			beer.name = "Ale nr 167";
			beer.type = "TEST type";
			beer.volume = "TEST 22";

			var result = controller._beerService.AddBeer( beer, 807 ); //remember to change values that match something existing in the DB

			Assert.IsTrue( result.id > 0 );
		}

		[TestMethod]
		public void GetPrices_NotNull() {
			var e = controller._beerService.GetPrices( 807, 3 ); //remember to change values that match something existing in the DB

			Assert.IsNotNull( e.EstablishmentBrands );
			Assert.IsNotNull( e.Brand );
			Assert.IsNotNull( e.Establishment );
		}

		[TestMethod]
		public void GetBeer_NotNull() {
			var e = controller._beerService.GetEstablishment( 807, 3 );

			Assert.IsNotNull( e.Brand.country );
		}

		[TestMethod]
		public void GetBeer_Null() {
			var e = controller._beerService.GetEstablishment( 918, 31 ); //remember to select bogus ids which does not exist in the DB

			Assert.IsNull( e.Brand );
		}


		[TestMethod]
		public void AddPrices_And_Delete_NULL_price() {
			var beer = new brand();
			beer.country = "TEST country";
			beer.description = "TEST descripion";
			beer.maker = "Refsvindinge";
			beer.name = "Ale nr 167";
			beer.type = "TEST type";
			beer.volume = "TEST 22";

			var result = controller._beerService.AddBeer( beer, 807 ); //remember to change values that match something existing in the DB

			var priceRecordId = controller._beerService.AddPrices(
				new establishment_brand { brand_id = result.id, establishment_id = 1, price = "22", size = "med" },
				807,
				result.id ); //remember to change values that match something existing in the DB

			controller._beerService.AddPrices(
				new establishment_brand { brand_id = result.id, establishment_id = 1, price = "25", size = "med" },
				807,
				result.id ); //remember to change values that match something existing in the DB

			Assert.IsNotNull( priceRecordId );

			var record = controller._beerService.Database.establishment_brands.Where( x => x.price == null ).FirstOrDefault();
			Assert.IsNull( record );
		}

		[TestMethod]
		public void GetPlace_By_Name() {
			var establishment = controller._beerService.GetEstablishment( 807, 5 );

			ViewResult result = controller.GetEstablishment( establishment.Establishment.name ) as ViewResult;

			var model = result.Model as AddBeersModel;

			Assert.IsTrue( model.Establishment.name == "Mikkeller Bar (Viktoriagade)" );
		}
	}
}
