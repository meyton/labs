using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Models.Sqlite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testing
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StudentsPage : ContentPage
	{
        private List<Models.UI.Student> _students;

		public StudentsPage(List<Student> students)
		{
			InitializeComponent();
            _students = new List<Models.UI.Student>();

            foreach (var s in students)
            {
                _students.Add(new Models.UI.Student()
                {
                    ID = s.ID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Grade = s.Grade
                });
            }

            lvStudents.ItemsSource = _students;
        }
    }
}