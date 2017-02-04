using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

using umaCollabApp.iOS.Data;
using Xamarin.Forms;
using umaCollabApp.Data.DataService;

[assembly: Dependency(typeof(iOSSQLite))]
namespace umaCollabApp.iOS.Data
{
    public class iOSSQLite : ISQLite
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var databaseName = "DBAPP.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var combinePath = Path.Combine(documentsPath, "..", "Library");
            var resultPath = Path.Combine(combinePath, databaseName);

            var connection = new SQLiteConnection(new SQLitePlatformIOS(), resultPath);

            return connection;
        }
    }
}
