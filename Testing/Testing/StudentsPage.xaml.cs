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
        private Class _class;

		public StudentsPage(List<Student> students, Class passedClass)
		{
			InitializeComponent();
            _students = new List<Models.UI.Student>();
            _class = passedClass;

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

        internal async void btnAddNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewStudentPage(_class.ID));
        }
    }
}