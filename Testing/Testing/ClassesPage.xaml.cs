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
		}

        private async void InitializeListView()
        {
            _classes = await App.LocalDB.GetItems<Class>();
            lvClasses.ItemsSource = _classes;
            lvClasses.ItemTapped -= LvClasses_ItemTapped;
            lvClasses.ItemTapped += LvClasses_ItemTapped;
        }

        private async void LvClasses_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedClass = (Class)e.Item;
            await Navigation.PushAsync(new StudentsPage(selectedClass));
        }

        internal async void btnAddNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddNewClassPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            InitializeListView();
        }
    }
}