using Hublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.Search
{
	public class SearchService : ServiceBase, ISearchService
	{
		public BarSearchModel SearchBars( string city ) {
			if( string.IsNullOrEmpty( city ) ) {
				throw new ArgumentNullException( "city" );
			}

			BarSearchModel model = new BarSearchModel();
			model.Establishments = Database.establishments.Where( c => c.city == city ).ToList();

			return model;
		}
	}
}