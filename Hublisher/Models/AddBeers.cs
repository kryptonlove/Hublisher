﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Models
{
	public class MenuModel
	{
		public establishment Establishment { get; set; }
		public List<establishment_brand> EstablishmentBrands { get; set; }
		public brand Brand { get; set; }

		public List<brand> GetEstablishmentBrands() {
			HubStoreDataContext db = new HubStoreDataContext();

			List<brand> list = new List<brand>();

			foreach (var item in db.establishment_brands.Where( x => x.establishment_id == Establishment.id && x.deleted == false ).ToList()) {
				list.Add( HublisherApp._allBrands.Where( x => x.id == item.brand_id && x.deleted == false ).FirstOrDefault() );
			}

			return list.Distinct().ToList();
		}
	}
}