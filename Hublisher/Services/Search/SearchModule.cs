using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.Search
{
	public class SearchModule : NinjectModule
	{
		public override void Load() {
			this.Bind<ISearchService>().To<SearchService>();
		}
	}
}