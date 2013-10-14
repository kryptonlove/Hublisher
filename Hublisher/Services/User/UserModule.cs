using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.User
{
	public class UserModule : NinjectModule
	{
		public override void Load() {
			this.Bind<IUserService>().To<UserService>();
		}
	}
}