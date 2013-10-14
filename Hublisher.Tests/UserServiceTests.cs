using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hublisher.Services.User;

namespace Hublisher.Tests
{
	[TestClass]
	public class UserServiceTests
	{
		IUserService _service;

		public UserServiceTests() {
			_service = new UserService();
		}

		[ClassInitialize]
		public static void Init( TestContext context ) {
			HublisherApp.UpdateGlobals();
		}

		[TestMethod]
		public void Get_User() {
			var u = _service.Get( "danielovich" );

			Assert.IsNotNull( u );
		}

		[TestMethod]
		public void Create_User() {
			var u = new user();
			u.administrator = false;
			u.alias = "danielovich";
			u.email = "danielfrostdk@outlook.com";
			u.logins = 1;
			u.password = "CykelMyg!1";

			var en = _service.Create( u );

			Assert.IsTrue( en == UserCreationStatus.email_exists );
			Assert.IsNotNull( _service.Get( u.alias ) );
		}

		[TestMethod]
		public void Login_User() {
			var u = _service.Login( "danielfrostdk@outlook.com", "CykelMyg!2" );

			Assert.IsNotNull( u );
		}

		[TestMethod]
		public void Login_User_Fail() {
			var u = _service.Login( "danielfsrostdk@outlook.com", "CykelMyg!2" );

			Assert.IsNull( u );
		}



		[TestMethod]
		public void Update_User() {
			var user = _service.Get( "danielovich" );

			user.alias = "danielovich";
			user.password = "CykelMyg!2";
			user.updated = DateTime.Now;

			var en = _service.Update( user );

			Assert.IsTrue( en == UserCreationStatus.updated );
		}
	}
}
