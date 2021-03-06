﻿using SQLite;
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
            database.CreateTableAsync<Student>().Wait();
            database.CreateTableAsync<Class>().Wait();
            database.CreateTableAsync<Category>().Wait();
        }

        private async void Init()
        {
            await database.CreateTableAsync<Student>();
        }

        public async Task<List<T>> GetAllGeneric<T>() where T : class, ISqliteModel, new()
        {
            return await database.Table<T>().ToListAsync();
        }

        public async Task<int> SaveGeneric<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);

            return result;
        }

        public async Task<int> DeleteGeneric<T>(T item)
        {
            var result = await database.DeleteAsync(item);
            return result;
        }
        
        public async Task<List<Student>> GetAllStudents()
        {
            return await database.Table<Student>().ToListAsync();
        }

        internal async Task<List<T>> GetItems<T>() where T : class, new()
        {
            return await database.Table<T>().ToListAsync();
        }

        internal async Task<List<Student>> GetStudentsByName(string name)
        {
            return await database.Table<Student>().Where(x => x.FirstName == name).ToListAsync();
        }

        internal async Task<Student> GetStudentByID(int id)
        {
            return await database.Table<Student>().Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        internal async Task<List<Student>> GetStudentsByClassId(int id)
        {
            return await database.Table<Student>().Where(x => x.ClassID == id).ToListAsync();
        }

        public async Task<int> SaveItemAsync<T>(T item)
        {
            var result = await database.UpdateAsync(item);

            if (result == 0)
                result = await database.InsertAsync(item);

            return result;
        }

        public async Task<int> DeleteItemAsync<T>(T item)
        {
            return await database.DeleteAsync(item);
        }

    }
}
