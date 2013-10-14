using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.Establishment
{
	public class EstablishmentModule : NinjectModule
	{
		public override void Load() {
			this.Bind<IEstablishmentService>().To<EstablishmentService>();
		}
	}
}