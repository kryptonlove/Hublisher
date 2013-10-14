using Hublisher.Controllers;
using Hublisher.Services.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hublisher.Tests
{
	[TestClass]
	public class SearchControllerTests
	{
		SearchController controller;
		public SearchControllerTests() {
			controller = new SearchController( new SearchService() );
		}

		[ClassInitialize]
		public static void Init( TestContext context ) {
			HublisherApp.UpdateGlobals();
		}

		[TestMethod]
		public void Given_City_Return_Bars() {
			var city = "Randers";
			var ret = controller._service.SearchBars( city ).Establishments;
			
			Assert.IsTrue( ret.Count > 0 );
			Console.WriteLine( ret.Count );

			city = "GUGGI";
			ret = controller._service.SearchBars( city ).Establishments;
			Assert.IsTrue( ret.Count == 0 );
			Console.WriteLine( ret.Count );

			city = "købenHavn";
			ret = controller._service.SearchBars( city ).Establishments;
			Assert.IsTrue( ret.Count > 0 );
			Console.WriteLine( ret.Count );

		}
	}
}
