﻿using Hublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hublisher.Services.Beer
{
	public interface IBeerService
	{
		HubStoreDataContext Database { get; set; }
		bool Exists( string name );
		bool Exists( int beerId, int establishmentId );
		brand AddBeer( brand beer, int establishmentId );
		AddBeersModel GetEstablishment( int establistmentId, int beerId = 0);
		AddBeersModel GetEstablishment( string establishmentName );
		AddPricesModel GetPrices( int establistmentId, int beerId );
		int AddPrices( establishment_brand model, int establistmentId, int beerId );
	}
}
