using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using umaCollabApp.Droid.Data;
using Xamarin.Forms;
using umaCollabApp.Data.DataService;

[assembly: Xamarin.Forms.Dependency(typeof(AndroidSQLite))]
namespace umaCollabApp.Droid.Data
{
    public class AndroidSQLite : ISQLite
    {   
        public SQLiteConnection GetConnection()
        {
            var databaseName = "DBAPP.db3";
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var combinePath = Path.Combine(documentsPath, databaseName);

            var connection = new SQLiteConnection(new SQLitePlatformAndroid(), combinePath);

            return connection;
        }
    }
}