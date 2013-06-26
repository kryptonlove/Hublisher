using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.Beer
{
	public class BeerModule : NinjectModule
	{
		public override void Load() {
			this.Bind<IBeerService>().To<BeerService>();
		}
	}
}