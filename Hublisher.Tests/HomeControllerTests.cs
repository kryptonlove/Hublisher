using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hublisher.Controllers;
using System.Web.Mvc;
using System.Data.Linq;
using System.Linq;
using Hublisher.Services.Establishment;

namespace Hublisher.Tests
{
	[TestClass]
	public class HomeControllerTests
	{
		HomeController controller;

		public HomeControllerTests() {
			controller = new HomeController( new EstablishmentService() );
		}

		[TestInitialize()]
		public void Init()
		{
			HublisherApp.UpdateGlobals();
		}


		[TestMethod]
		public void Add_New_Establishments()
		{
			var est = new establishment();
			est.address = "";
			est.name = "Fairbar";
			est.city = "Århus";
			est.borough = "";
			est.maplink = "";
			est.type = "";

			var res = (RedirectToRouteResult)controller.Add(est);
			Assert.IsTrue(res.RouteValues.Count == 3);

			est = new establishment();
			est.address = "";
			est.name = "Fairbar2";
			est.city = "Århus";
			est.borough = "";
			est.maplink = "";
			est.country = "";
			est.type = "bar";

			controller.Add(est);
			Assert.IsTrue(res.RouteValues.Count == 3);
		}

		[TestMethod]
		public void GetById_Establishment_Exists() {
			var v = controller.Get( "13222" ) as ViewResult;
			var m = v.Model as establishment;

			Assert.IsNotNull( m.name );
			Assert.IsTrue( m.id == 13222 );
		}

		[TestMethod]
		public void GetById_Establishment_Does_Not_Exist() {
			var v = controller.Get( "1991119919191" ) as ViewResult;
			var m = v.Model as establishment;

			Assert.IsNull( m );
		}
	}
}
