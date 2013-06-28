using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hublisher.Controllers
{
    public class BaseController : Controller
    {
		public BaseController() {
			SetConnection();
		}

		public BaseController(string connection) {
			_connection = connection;
			SetConnection();
		}

		private string _connection;

		private void SetConnection() {
			if (string.IsNullOrEmpty( _connection )) {
				_connection = ConfigurationManager.ConnectionStrings["hublisherConnectionString"].ConnectionString;
			}

			database = new HubStoreDataContext( _connection );
		}

		public HubStoreDataContext database;
	}
}
