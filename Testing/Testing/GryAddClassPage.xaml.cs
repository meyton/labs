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
	public partial class GryAddClassPage : ContentPage
	{
		public GryAddClassPage ()
		{
			InitializeComponent ();
		}

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var className = entryName.Text;
            var teacher = entryTeacher.Text;

            if (string.IsNullOrWhiteSpace(className) || string.IsNullOrWhiteSpace(teacher))
            {
                await DisplayAlert("Błąd", "Dane nie zostały wypełnione", "OK");
                return;
            }

            var newClass = new Class()
            {
                Name = className,
                Teacher = teacher
            };

            await App.LocalDB.SaveGeneric(newClass);
            await DisplayAlert("Sukces", "Zapisano w bazie", "OK");
        }
    }
}