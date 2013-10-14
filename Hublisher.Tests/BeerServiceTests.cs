using Hublisher.Services.Beer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hublisher.Tests
{
	[TestClass]
	public class BeerServiceTests
	{
		IBeerService _service;

		public BeerServiceTests() {
			_service = new BeerService();
		}

		[ClassInitialize]
		public static void Init( TestContext context ) {
			HublisherApp.UpdateGlobals();
		}

		[TestMethod]
		public void Add_New_Beer_Return_New_Id() {
			var beer = new brand();
			beer.country = "TEST country";
			beer.description = "TEST descripion";
			beer.maker = "Refsvindinge";
			beer.name = "Ale nr 1673";
			beer.type = "TEST type";
			beer.volume = "TEST 22";
			beer.deleted = false;

			var result = _service.AddBeer( beer, 807 ); //remember to change values that match something existing in the DB

			var b = _service.Database.brands.OrderByDescending( e => e.id ).First();

			Assert.IsTrue( result.id == b.id );

			Console.WriteLine( b.id );
			Console.WriteLine( result.id );
		}

		[TestMethod]
		public void Beer_Exists_On_Establishment_True() {
			var e = _service.Exists( 3, 807 ); //remember to change values that match something existing in the DB

			Assert.IsTrue( e );
		}

		[TestMethod]
		public void Beer_Name_Exists_True() {
			var e = _service.Exists( "Ale nr 1673" );
			Assert.IsTrue( e );

			e = _service.Exists( "alE nR 1673" );
			Assert.IsTrue( e );

			e = _service.Exists( "AlE NR 1673" );
			Assert.IsTrue( e );
		}

		/// <summary>
		/// Besides the establishment, you need to make sure the values you are testing for is not already existing in the database.
		/// </summary>
		[TestMethod]
		public void AddPrices_And_Delete_NULL_price() {
			var beer = new brand();
			beer.country = "TEST country";
			beer.description = "TEST descripion";
			beer.maker = "Refsvindinge";
			beer.name = "Ale nr 1673";
			beer.type = "TEST type";
			beer.volume = "TEST 22";
			beer.deleted = false;

			var result = _service.AddBeer( beer, 807 ); //remember to change values that match something existing in the DB

			var priceRecordId = _service.AddPrices(
				new establishment_brand { brand_id = result.id, establishment_id = 807, price = "22", size = "med", deleted = false },
				807,
				result.id ); //remember to change values that match something existing in the DB

			_service.AddPrices(
				new establishment_brand { brand_id = result.id, establishment_id = 807, price = "25", size = "med", deleted = false },
				807, 
				result.id ); //remember to change values that match something existing in the DB

			Assert.IsNotNull( priceRecordId );

			var record = _service.Database.establishment_brands.Where( x => x.price == null && x.id == priceRecordId ).FirstOrDefault();
			Assert.IsNull( record );
		}

		[TestMethod]
		public void Update_Beer_Return_Updated() {
			var beer = new brand();
			beer.country = "TEST country";
			beer.description = "TEST descripion";
			beer.maker = "Refsvindinge";
			beer.name = "Ale nr 167111";
			beer.type = "TEST type";
			beer.volume = "TEST 22";
			beer.id = 11;
			beer.deleted = false;

			_service.AddBeer( beer, 807 );
			beer = _service.GetBeer( 11 );

			Assert.IsNotNull( beer.updated );
		}

		[TestMethod]
		public void GetPrices_NotNull() {
			var e = _service.GetPrices( 807, 3 ); //remember to change values that match something existing in the DB

			Assert.IsTrue( e.EstablishmentBrands.Count() == 3 );
			Assert.IsNotNull( e.Brand );
			Assert.IsNotNull( e.Establishment );
		}

		[TestMethod]
		public void Add_A_New_Price() {
			var estId = 807;
			var brandId = 3;

			var model = new establishment_brand();
			model.brand_id = brandId;
			model.deleted = false;
			model.establishment_id = estId;
			model.price = "60";
			model.size = "large";

			var e = _service.AddPrices( model, estId, brandId ); //remember to change values that match something existing in the DB
			Assert.IsTrue( _service.GetPrices( estId, brandId ).EstablishmentBrands.Count == 3 );
		}
	}
}
