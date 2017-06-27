using System;
using GymApp.iOS;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace GymApp.iOS
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = System.IO.Path.Combine(documentsPath, "MySQLite.db3");

            return new SQLiteAsyncConnection(path);
        }
    }
}
