using Hublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.Search
{
	public interface ISearchService : IServiceBase
	{
		BarSearchModel SearchBars( string city );
	}
}