using Hublisher.Services.Establishment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hublisher.Tests
{
	[TestClass]
	public class EstablishmentServiceTests
	{
		IEstablishmentService _service;

		public EstablishmentServiceTests() {
			_service = new EstablishmentService();
		}

		[ClassInitialize]
		public static void Init( TestContext context ) {
			HublisherApp.UpdateGlobals();
		}

		[TestMethod]
		public void Get_Establishment_NotNull() {
			var e = _service.GetEstablishment( 807, 3 );

			Assert.IsNotNull( e.Establishment );
		}

		[TestMethod]
		public void Get_Establishment_Brands() {
			var e = _service.GetEstablishment( 807, 3 );

			Assert.IsTrue( e.GetEstablishmentBrands().Count == 3 );
		}

		[TestMethod]
		public void GetBeer_Null() {
			var e = _service.GetEstablishment( 918, 31 ); //remember to select bogus ids which does not exist in the DB

			Assert.IsNull( e.Brand );
		}
	}
}
