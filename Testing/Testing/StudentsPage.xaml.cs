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

		public StudentsPage(Class passedClass)
		{
			InitializeComponent();
            _class = passedClass;    
            
        }

        internal async void btnAddNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewStudentPage(_class.ID));
        }

        protected override async void OnAppearing()
        {
            var students = await App.LocalDB.GetStudentsByClassId(_class.ID);
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
            lvStudents.ItemTapped -= LvStudents_ItemTapped;
            lvStudents.ItemTapped += LvStudents_ItemTapped;
        }

        private async void LvStudents_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var student = (Models.UI.Student)e.Item;
            var dbStudent = await App.LocalDB.GetStudentByID(student.ID);
            await Navigation.PushAsync(new StudentDetailsPage(dbStudent));
        }
    }
}