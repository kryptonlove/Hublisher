using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hublisher.Controllers;
using System.Web.Mvc;
using System.Data.Linq;
using System.Linq;

namespace Hublisher.Tests
{
	[TestClass]
	public class HomeControllerTests
	{
		HomeController controller = new HomeController();

		[TestInitialize()]
		public void Init()
		{
			HublisherApp.UpdateGlobals();
		}


		[TestMethod]
		public void Add()
		{
			var est = new establishment();
			est.address = "";
			est.name = "Fairbar";
			est.city = "Aarhus";
			est.borough = "";
			est.maplink = "";
			est.type = "";

			var res = (RedirectToRouteResult)controller.Add(est);
			Assert.IsTrue(res.RouteValues.Count == 3);

			est = new establishment();
			est.address = "";
			est.name = "Fairbar2";
			est.city = "Aarhus";
			est.borough = "";
			est.maplink = "";
			est.country = "";
			est.type = "";

			controller.Add(est);
			Assert.IsTrue(res.RouteValues.Count == 3);

			Assert.IsTrue(controller.database.establishments.Where(e => e.name == est.name).FirstOrDefault() != null);

			controller.database.establishments.DeleteOnSubmit(est);
			controller.database.SubmitChanges();
		}
	}
}
