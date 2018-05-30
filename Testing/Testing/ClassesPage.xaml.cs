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
	public partial class ClassesPage : ContentPage
	{
        private List<Class> _classes;
		public ClassesPage ()
		{
			InitializeComponent();
            InitializeListView();
		}

        private async void InitializeListView()
        {
            _classes = await App.LocalDB.GetItems<Class>();
            lvClasses.ItemsSource = _classes;
            lvClasses.ItemTapped += LvClasses_ItemTapped;
        }

        private async void LvClasses_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedClass = (Class)e.Item;
            var students = await App.LocalDB.GetStudentsByClassId(selectedClass.ID);
            await Navigation.PushAsync(new StudentsPage(students));
        }
    }
}