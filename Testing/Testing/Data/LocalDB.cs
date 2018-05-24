using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Data
{
    public class LocalDB
    {
        readonly SQLiteAsyncConnection database;

        public LocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
        }
    }
}