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
	public partial class AddNewClassPage : ContentPage
	{
		public AddNewClassPage()
		{
			InitializeComponent ();
		}

        internal async void btnAdd_Clicked(object sender, EventArgs e)
        {
            var name = entryName.Text;
            var teacher = entryTeacher.Text;

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(teacher))
            {
                await DisplayAlert("Błąd", "Wprowadzono niepełne dane", "OK");
                return;
            }

            var newClass = new Class()
            {
                Name = name,
                Teacher = teacher
            };

            await App.LocalDB.SaveItemAsync(newClass);

            await DisplayAlert("Sukces", "Dane zostały dodane", "OK");
        }

    }
}