using Hublisher.Services.Establishment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hublisher.Controllers
{
    public class HomeController : BaseController
    {
		private readonly IEstablishmentService _establishment;
		public HomeController(IEstablishmentService establishment) {
			_establishment = establishment;
		}
		
		[HttpGet()]
        public ActionResult Add(string id)
        {
			return View();
        }

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Add(establishment est) {
			if (HublisherApp._allEstablishments.Where(e => e.name == est.name && e.city == est.city && e.deleted == false).Count() == 0)
			{
				est.deleted = false;
				//est.userid = need one
				_establishment.AddEstablishment( est );
			}

			est = HublisherApp._allEstablishments.Where(e => e.name.Equals(est.name, StringComparison.OrdinalIgnoreCase) && e.city.Equals(est.city, StringComparison.OrdinalIgnoreCase) && e.deleted == false).FirstOrDefault();

			return RedirectToAction("menu", "est", new { id = est.id });
		}

		public ActionResult Get( string identifier ) {
			int p;
			if( int.TryParse( identifier, out p ) ) {
				return View( _establishment.GetById( p ) );
			} else {
				return View( _establishment.GetByName( identifier ) );
			}
		}
	}
}
