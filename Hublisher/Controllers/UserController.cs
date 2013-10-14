using Hublisher.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hublisher.Controllers
{
    public class UserController : BaseController
    {
		private IUserService userService;

		public UserController(IUserService _service) {
			userService = _service;
		}

		[HttpGet]
        public ActionResult Login()
        {
            return View();
        }


		[HttpPost()]
		[ValidateAntiForgeryToken]
		public ActionResult Login(FormCollection coll) {
			var email = coll[ "email" ];
			var password = coll[ "password" ];

			var loggedIn = userService.Login( email, password );

			if( loggedIn != null ) {
				Session[ "alias" ] = loggedIn.alias;

				return RedirectToAction( "add", "home" );
			}

			return View();
		}

    }
}
