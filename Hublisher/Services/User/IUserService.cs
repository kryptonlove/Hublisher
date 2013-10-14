using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hublisher.Services.User
{
	public interface IUserService
	{
		user Get( string alias );
		bool ResetPassword( string email, string password );
		user Login( string email, string password );
		UserCreationStatus Create( user newUser );
		UserCreationStatus Update( user updateUser );

	}
}
