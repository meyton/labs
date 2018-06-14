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
    public partial class GryStudentsPage : ContentPage
    {
        private Class _class;
        public GryStudentsPage(Class passedClass)
        {
            _class = passedClass;
            InitializeComponent();
            lblClass.Text = "Studenci: " + _class.Name;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            var selectedStudent = (Student)e.Item;
            await Navigation.PushAsync(new GryEditStudentPage(selectedStudent));

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GryAddStudentPage(_class));
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();           
            var students = await App.LocalDB.GetAllGeneric<Student>();
            students.RemoveAll(x => x.ClassID != _class.ID);
            MyListView.ItemsSource = students;
            MyListView.ItemTapped -= Handle_ItemTapped;
            MyListView.ItemTapped += Handle_ItemTapped;
        }
    }
}
