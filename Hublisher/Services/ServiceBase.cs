using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Hublisher.Services
{
	public class ServiceBase
	{
		public ServiceBase() {
			SetConnection();
		}

		public ServiceBase(string connection) {
			_connection = connection;
			
			SetConnection();
		}

		private string _connection;

		private void SetConnection() {
			if( string.IsNullOrEmpty( _connection ) ) {
				_connection = ConfigurationManager.ConnectionStrings[ "hublisherConnectionString" ].ConnectionString;
			}

			Database = new HubStoreDataContext( _connection );
		}

		public HubStoreDataContext Database { get; set; }

		protected void UpdateApp() {
			HublisherApp.UpdateGlobals();
		}
	}
}