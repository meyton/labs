using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Data;
using Testing.Models.Sqlite;
using Xamarin.Forms;

namespace Testing
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }
        
        internal async void btnCheckUrl_Clicked(object sender, EventArgs e)
        {
            Properties.AppProperties["isButtonClicked"] = "Tak, button został kliknięty";
            await Application.Current.SavePropertiesAsync();

            var url = entryUrl.Text;
            await Navigation.PushAsync(new HttpClientPage(url));
        }

        internal async void btnOpenUrl_Clicked(object sender, EventArgs e)
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await DisplayAlert("Nie masz połączenia", "Brak połączenia z internetem.", "OK");
                return;
            }

            var url = entryUrl.Text;
            if (await DisplayAlert("Czy na pewno?", "Czy na pewno chcesz otworzyć stronę? " + url, "TAK", "NIE"))
            {
                await Navigation.PushAsync(new WebViewPage(url));
            }
            else
            {
                await DisplayAlert("Dobrze", "Nie otwieram strony", "OK");
            }
        }

        internal async void btnProp_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new PropertiesPage());
            //await Navigation.PushAsync(new ListingPage());
            //await Navigation.PushAsync(new ListViewPage1());
            await Navigation.PushAsync(new Views.TestPage());
        }

        internal async void btnCheckDB_Clicked(object sender, EventArgs e)
        {
            if (!CrossShare.IsSupported)
                return;

            await CrossShare.Current.Share(new Plugin.Share.Abstractions.ShareMessage()
            {
                Title = "Wyniki meczów",
                Text = "Wynik Rosja vs. Arabia Saudyjska 2:0"
            });

            //await CrossMedia.Current.Initialize();

            //if (!CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    return;
            //}

            //var file = await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions()
            //{
            //    CompressionQuality = 50,
            //    MaxWidthHeight = 800,
            //    RotateImage = true,
            //    PhotoSize = Plugin.Media.Abstractions.PhotoSize.MaxWidthHeight
            //});

            //if (file == null)
            //    return;

            //imgTest.Source = ImageSource.FromStream(() => file.GetStream());

            //await Navigation.PushAsync(new Views.GryPage());
            //await Navigation.PushAsync(new GryClassesPage());


            //await CrossMedia.Current.Initialize();

            //if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //{
            //    return;
            //}

            //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //{
            //    Name = "picture.jpg",
            //    Directory = "Imports",
            //    SaveToAlbum = true
            //});

            //if (file == null)
            //    return;

            //imgTest.Source = ImageSource.FromFile(file.Path);


            //if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            //{
            //    return;
            //}

            //var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            //{
            //    Directory = "Sample",
            //    Name = "test.jpg",
            //    SaveToAlbum = true
            //});

            //imgTest.Source = ImageSource.FromStream(() => file.GetStream());
        }

        internal async void btnCountDB_Clicked(object sender, EventArgs e)
        {
            var studentList = await App.LocalDB.GetAllStudents();
            await DisplayAlert("Studenci", "Liczba studentów w bazie: " + studentList.Count, "OK");

            var student = studentList.LastOrDefault();

            if (student != null)
            {
                if (await DisplayAlert("Czy chcesz usunąć?", student.FirstName + " " + student.LastName, "TAK", "NIE"))
                {
                    await App.LocalDB.DeleteItemAsync(student);
                }
            }
        }

        internal async void btnCreateOld_Clicked(object sender, EventArgs e)
        {
            var classes = new List<Class>()
            {
                new Class() { Name = "Inf 1A", Teacher = "Marcin Wesel" }
            };

            await App.LocalDB.SaveItemAsync(classes.First());

            var team = new List<Student>()
            {
                new Student() { FirstName = "Janusz", LastName = "Testowy", Grade = 2, ClassID = 1 },
                new Student() { FirstName = "Leszek", LastName = "Tester", Grade = 3, ClassID = 1 },
                new Student() { FirstName = "Dagmara", LastName = "Kowalska", Grade = 5, ClassID = 1 },
                new Student() { FirstName = "Agata", LastName = "Nowak", Grade = 4, ClassID = 1 },
            };
            
            foreach(var t in team)
            {
                await App.LocalDB.SaveItemAsync(t);
            }

            await DisplayAlert("OK", "Dane zostały dodane", "OK");
        }

        internal async void btnCreate_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ClassesPage());
        }
    }
}
