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
	public partial class AddNewStudentPage : ContentPage
	{
        private int _classID;

		public AddNewStudentPage(int classID)
		{
            _classID = classID;
			InitializeComponent ();
		}

        internal async void btnAdd_Clicked(object sender, EventArgs e)
        {
            var firstName = entryFirstName.Text;
            var lastName = entryLastName.Text;
            var grade = entryGrade.Text;

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(grade))
            {
                await DisplayAlert("Błąd", "Wprowadzono niepełne dane", "OK");
                return;
            }

            var newStudent = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Grade = int.Parse(grade),
                ClassID = _classID
            };

            await App.LocalDB.SaveItemAsync(newStudent);

            await DisplayAlert("Sukces", "Dane zostały dodane", "OK");
        }

    }
}