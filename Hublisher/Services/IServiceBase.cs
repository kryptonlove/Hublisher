using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hublisher.Services
{
	public interface IServiceBase
	{
		HubStoreDataContext Database { get; set; }
	}
}
