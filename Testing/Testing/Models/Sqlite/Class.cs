using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Models.Sqlite
{
    class Class
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
    }
}
