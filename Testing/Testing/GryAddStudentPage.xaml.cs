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
	public partial class GryAddStudentPage : ContentPage
	{
        private Class _class;
		public GryAddStudentPage(Class passedClass)
		{
            _class = passedClass;
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var firstName = entryFirstName.Text;
            var lastName = entryLastName.Text;
            var grade = entryGrade.Text;
            
            var newStudent = new Student()
            {
                FirstName = firstName,
                LastName = lastName,
                Grade = int.Parse(grade),
                ClassID = _class.ID
            };

            await App.LocalDB.SaveGeneric(newStudent);
            await DisplayAlert("Sukces", "Zapisano w bazie", "OK");
        }
    }
}