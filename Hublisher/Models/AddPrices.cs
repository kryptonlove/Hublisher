using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Models
{
	public class AddPricesModel
	{
		public establishment Establishment { get; set; }
		public brand Brand { get; set; }
		public List<establishment_brand> EstablishmentBrands { get; set; }
	}
}