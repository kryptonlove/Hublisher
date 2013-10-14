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
using Hublisher.Services.Establishment;


namespace Hublisher.Tests
{
	[TestClass]
	public class EstControllerTests
	{
		EstController controller;
		public EstControllerTests() {
			controller = new EstController( new BeerService(), new EstablishmentService() );
		}

		[ClassInitialize]
		public static void Init( TestContext context ) {
			HublisherApp.UpdateGlobals();
		}

		[TestMethod]
		public void Menu() {
			ViewResult result = controller.Menu("807", 0) as ViewResult;

			var model = result.Model as MenuModel;

			Assert.IsTrue( model.Establishment.name == "Mikkeller Bar (Viktoriagade)" );
		}
	}
}
