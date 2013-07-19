using Hublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.Beer
{
	public class BeerService : ServiceBase, IBeerService
	{
		public AddBeersModel GetEstablishment( string name ) {
			var model = new AddBeersModel();

			var place = Database.establishments.Where( x => x.name == name ).FirstOrDefault();

			return GetEstablishment( place.id );
		}

		public AddPricesModel GetPrices( int establishmentId, int beerId ) {
			var model = new AddPricesModel();

			model.Establishment = Database.establishments.Where( x => x.id == establishmentId ).FirstOrDefault();
			model.Brand = Database.brands.Where( x => x.id == beerId ).FirstOrDefault();
			model.EstablishmentBrands = Database.establishment_brands.Where( x => x.establishment_id == establishmentId ).Where( x => x.brand_id == beerId ).ToList();

			return model;
		}

		public int AddPrices( establishment_brand model, int establishmentId, int beerId ) {
			model.brand_id = beerId;
			model.establishment_id = establishmentId;

			if (Database.establishment_brands.Where( x => x.size == model.size && x.establishment_id == establishmentId && x.brand_id == beerId ).Count() == 0) {
				Database.establishment_brands.InsertOnSubmit( model );
				Database.SubmitChanges();
			}

			DeleteNullPriceRecord( beerId, establishmentId );

			return model.id;
		}

		private void DeleteNullPriceRecord( int beerId, int establishmentiId ) {
			var nullRecord = Database.establishment_brands.Where( x => x.establishment_id == establishmentiId && x.brand_id == beerId && x.price == null ).FirstOrDefault();
			if (nullRecord != null) {
				Database.establishment_brands.DeleteOnSubmit( nullRecord );
				Database.SubmitChanges();
			}
		}

		public AddBeersModel GetEstablishment( int establistmentId, int beerId = 0) {
			var model = new AddBeersModel();

			model.Establishment = Database.establishments.Where( x => x.id == establistmentId ).FirstOrDefault();
			model.EstablishmentBrands = Database.establishment_brands.Where( x => x.establishment_id == establistmentId ).ToList();

			if (beerId > 0) {
				model.Brand = Database.brands.Where( x => x.id == beerId ).FirstOrDefault();
			} else {
				model.Brand = new brand();
			}

			return model;
		}


		public brand AddBeer( brand beer, int establishmentId ) {
			if (!Exists( beer.name )) {
				Database.brands.InsertOnSubmit( beer );
				Database.SubmitChanges();

				HublisherApp.UpdateGlobals();
			} else {
				var update = Database.brands.Where( b => b.name == beer.name && b.id == beer.id ).FirstOrDefault();

				if (update != null) {
					update.name = beer.name;
					update.maker = beer.maker;
					update.country = beer.country;
					update.description = beer.description;
					update.type = beer.type;
					update.volume = beer.volume;

					Database.SubmitChanges();
				}
			}

			beer = HublisherApp._allBrands.Where( x => x.name.Equals( beer.name ) ).FirstOrDefault();

			if (!Exists( beer.id, establishmentId )) {
				this.Database.establishment_brands.InsertOnSubmit( new establishment_brand { brand_id = beer.id, establishment_id = establishmentId } );
				this.Database.SubmitChanges();
			}

			return beer;
		}

		public bool Exists( int beerId, int establishmentId ) {
			var exists = this.Database.establishment_brands.Where( x => x.brand_id == beerId && x.establishment_id == establishmentId ).FirstOrDefault();
			if (exists != null)
				return true;
			else
				return false;
		}

		public bool Exists( string beerName ) {
			var exists = HublisherApp._allBrands.Exists( z => z.name.ToLower() == beerName.ToLower() );

			if (exists) {
				return true;
			}

			return false;
		}
	}
}