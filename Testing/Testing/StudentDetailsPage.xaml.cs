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
	public partial class StudentDetailsPage : ContentPage
	{
        private Student _student;

		public StudentDetailsPage(Student student)
		{
            _student = student;
			InitializeComponent ();
            entryGrade.Text = student.Grade.ToString();
            lblName.Text = $"Edytujesz {student.FirstName} {student.LastName}";
		}

        internal async void btnSave_Clicked(object sender, EventArgs e)
        {
            var grade = entryGrade.Text;

            if (string.IsNullOrWhiteSpace(grade))
            {
                await DisplayAlert("Błąd", "Wprowadzono niepełne dane", "OK");
                return;
            }

            _student.Grade = int.Parse(grade);

            await App.LocalDB.SaveItemAsync(_student);

            await DisplayAlert("Sukces", "Zmiany zostały naniesione", "OK");
        }

        internal async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Czy na pewno?", "Czy na pewno chcesz usunąć tego studenta?", "TAK", "NIE"))
            {
                await App.LocalDB.DeleteItemAsync(_student);
                await DisplayAlert("Sukces", "Student został usunięty", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}