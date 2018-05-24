using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Testing.Models.Sqlite;

namespace Testing.Data
{
    public class LocalDB
    {
        readonly SQLiteAsyncConnection database;

        public LocalDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            Init();
        }

        private async void Init()
        {
            await database.CreateTableAsync<Student>();
        }

        private async Task<bool> IsItOK()
        {
            return await Task.FromResult<bool>(true);
        }
    }
}