using System;
using System.Collections.Generic;
using System.Text;

namespace Testing.Models.UI
{
    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Grade { get; set; }
        public string Name
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
    }
}
