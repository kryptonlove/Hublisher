using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hublisher.Services.User
{
	public enum UserCreationStatus { created = 1, alias_exists = 2, email_exists = 3, updated = 4 };
	
	public class UserService : ServiceBase, IUserService
	{
		public user Get( string alias ) {
			if( string.IsNullOrEmpty( alias ) )
				throw new ArgumentNullException( "name" );

			return base.Database.users.Where( x => x.alias == alias ).FirstOrDefault();
		}


		public UserCreationStatus Create( user newUser ) {
			var exists = base.Database.users.Where(x=>x.email == newUser.email ).Count();
			if( exists > 0 )
				return UserCreationStatus.email_exists;

			exists = base.Database.users.Where( x => x.alias == newUser.alias ).Count();
			if( exists > 0 )
				return UserCreationStatus.alias_exists;

			var password = PasswordHash.CreateHash( newUser.password );

			newUser.password = password;

			base.Database.users.InsertOnSubmit( newUser );
			base.Database.SubmitChanges();

			return UserCreationStatus.created;
		}

		public UserCreationStatus Update( user updateUser ) {
			updateUser = Get( updateUser.alias );
			
			var exists = base.Database.users.Where( x => x.email == updateUser.email && x.id != updateUser.id ).Count();
			if( exists > 0 )
				return UserCreationStatus.email_exists;

			exists = base.Database.users.Where( x => x.alias == updateUser.alias && x.id != updateUser.id ).Count();
			if( exists > 0 )
				return UserCreationStatus.alias_exists;

			var password = PasswordHash.CreateHash( updateUser.password );

			updateUser.password = password;

			base.Database.SubmitChanges();

			return UserCreationStatus.updated;
		}


		public bool ResetPassword( string email, string password ) {
			if( string.IsNullOrEmpty( email ) )
				throw new ArgumentNullException( "email" );

			if( string.IsNullOrEmpty( password ) )
				throw new ArgumentNullException( "password" );

			var u = base.Database.users.Where( x => x.email == email ).First();
			u.password = password;
			base.Database.SubmitChanges();

			return true;
		}

		public user Login( string email, string password ) {
			if( string.IsNullOrEmpty( email ) )
				throw new ArgumentNullException( "email" );

			if( string.IsNullOrEmpty( "password" ) )
				throw new ArgumentNullException( "password" );

			var loggedIn = base.Database.users.Where( x => x.email == email ).FirstOrDefault();

			if( loggedIn != null ) {
				if( PasswordHash.ValidatePassword( password, loggedIn.password ) ) {
					loggedIn.password = password;
					loggedIn.logins++;
					Update( loggedIn );
					
					return loggedIn;
				} 
			}
			
			return null;
		}
	}
}