using Hublisher.Services.User;
using Ninject.Modules;
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
		private IUserService userService;

		public BaseController() {
			if( userService == null )
				userService = new UserService();

			if( System.Web.HttpContext.Current.Session[ "alias" ] != null )
				ViewBag.User = LoggedInUser;
		}

		public user LoggedInUser {
			get {
				return userService.Get( System.Web.HttpContext.Current.Session[ "alias" ].ToString() );
			}
		}
	}
}
