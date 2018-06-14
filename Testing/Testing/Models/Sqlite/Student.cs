using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Models.Sqlite
{
    public class Student : ISqliteModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public int ClassID { get; set; }
    }
}