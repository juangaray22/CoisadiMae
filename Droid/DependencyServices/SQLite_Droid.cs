using System;
using System.IO;
using CoisadiMae.DependencyServices;
using CoisadiMae.Droid.DependencyServices;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace CoisadiMae.Droid.DependencyServices
{
	public class SQLite_Droid : ISQLite
	{
		public SQLiteConnection GetConn()
		{
			var sqliteFilename = "coisadimae.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var path = Path.Combine(documentsPath, sqliteFilename);
			var conn = new SQLiteConnection(path);

			return conn;
		}
	}
}