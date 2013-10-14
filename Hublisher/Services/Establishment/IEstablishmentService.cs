using Hublisher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hublisher.Services.Establishment
{
	public interface IEstablishmentService : IServiceBase
	{
		void AddEstablishment( establishment est );
		establishment GetByName( string name );
		establishment GetById( int id );
		MenuModel GetEstablishment( int establistmentId, int beerId = 0 );
		MenuModel GetEstablishment( string establishmentName );
	}
}
