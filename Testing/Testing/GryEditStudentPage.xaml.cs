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
	public partial class GryEditStudentPage : ContentPage
	{
        private Student _student;
		public GryEditStudentPage(Student passedStudent)
		{
            _student = passedStudent;
			InitializeComponent ();
            entryFirstName.Text = _student.FirstName;
            entryLastName.Text = _student.LastName;
            entryGrade.Text = _student.Grade.ToString();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var firstName = entryFirstName.Text;
            var lastName = entryLastName.Text;
            var grade = entryGrade.Text;

            _student.FirstName = firstName;
            _student.LastName = lastName;
            _student.Grade = int.Parse(grade);

            await App.LocalDB.SaveGeneric(_student);
            await DisplayAlert("Sukces", "Zapisano w bazie", "OK");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (await DisplayAlert("Czy na pewno?", "Czy na pewno chcesz usunąć studenta z bazy?", "TAK", "NIE"))
            {
                await App.LocalDB.DeleteGeneric(_student);
                await DisplayAlert("Sukces", "Student został usunięty", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}