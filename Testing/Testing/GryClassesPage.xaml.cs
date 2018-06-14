using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Testing.Models.Sqlite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testing
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GryClassesPage : ContentPage
    {
        public GryClassesPage()
        {
            InitializeComponent();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var selectedClass = (Class)e.Item;

            await Navigation.PushAsync(new GryStudentsPage(selectedClass));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GryAddClassPage());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();           
            var classes = await App.LocalDB.GetAllGeneric<Class>();
            MyListView.ItemsSource = classes;
            MyListView.ItemTapped -= Handle_ItemTapped;
            MyListView.ItemTapped += Handle_ItemTapped;
        }

    }
}
