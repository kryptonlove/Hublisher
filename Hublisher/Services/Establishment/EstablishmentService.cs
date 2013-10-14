using Hublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.Establishment
{
	public class EstablishmentService : ServiceBase, IEstablishmentService
	{
		public MenuModel GetEstablishment( string name ) {
			var model = new MenuModel();

			var place = base.Database.establishments.Where( x => x.name == name ).FirstOrDefault();

			return GetEstablishment( place.id );
		}

		public MenuModel GetEstablishment( int establistmentId, int beerId = 0 ) {
			var model = new MenuModel();

			model.Establishment = Database.establishments.Where( x => x.id == establistmentId && x.deleted == false ).FirstOrDefault();
			model.EstablishmentBrands = Database.establishment_brands.Where( x => x.establishment_id == establistmentId && x.deleted == false ).ToList();

			if( beerId > 0 ) {
				model.Brand = Database.brands.Where( x => x.id == beerId && x.deleted == false ).FirstOrDefault();
			} else {
				model.Brand = new brand();
			}

			return model;
		}


		public void AddEstablishment( establishment est ) {
			base.Database.establishments.InsertOnSubmit( est );
			base.Database.SubmitChanges();

			base.UpdateApp();
		}

		public establishment GetByName( string name ) {
			return base.Database.establishments.Where( n => n.name == name && n.deleted == false).FirstOrDefault();
		}

		public establishment GetById( int id ) {
			return base.Database.establishments.Where( n => n.id == id && n.deleted == false).FirstOrDefault();
		}
	}
}