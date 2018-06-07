using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Models.Sqlite
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Range { get; set; }
    }
}
