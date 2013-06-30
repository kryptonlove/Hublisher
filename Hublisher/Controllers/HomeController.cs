using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hublisher.Controllers
{
    public class HomeController : BaseController
    {
		[HttpGet()]
        public ActionResult Add(string id)
        {
			return View();
        }

		[HttpPost()]
		[ValidateAntiForgeryToken()]
		public ActionResult Add(establishment est) {
			if (HublisherApp._allEstablishments.Where(e => e.name == est.name && e.city == est.city).Count() == 0)
			{
				database.establishments.InsertOnSubmit(est);
				database.SubmitChanges();

				HublisherApp.UpdateGlobals();
			}

			est = HublisherApp._allEstablishments.Where(e => e.name.Equals(est.name, StringComparison.OrdinalIgnoreCase) && e.city.Equals(est.city, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

			return RedirectToAction("addbeers", "beer", new { id = est.id });
		}


    }
}
