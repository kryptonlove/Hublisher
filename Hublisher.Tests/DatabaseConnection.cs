using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Hublisher.Tests
{
	public static class DatabaseConnection
	{
		private static string fileDir = @"C:\Users\Administrator\Desktop\Backup\Code\Hublisher\Hublisher\";

		public static string GetConnection(bool release) {
			if (release) { fileDir = fileDir + "Web.Release.config"; } 
			else { fileDir = fileDir + "Web.Debug.config"; }

			using (StreamReader reader = new StreamReader( fileDir )) {
				XDocument doc = XDocument.Load( reader, LoadOptions.None );

				var connectionString = doc.Element( "configuration" )
					.Element( "connectionStrings" )
					.Element( "add" )
					.Attribute( "connectionString" );

				return connectionString.Value;			
			}
		}
	}
}
