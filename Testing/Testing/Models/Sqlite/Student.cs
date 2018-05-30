using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Models.Sqlite
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
    }
}