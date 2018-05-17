using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Testing
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
        }

        internal async void btnNext_Clicked(object sender, EventArgs e)
        {
           var url = entryUrl.Text;
           await Navigation.PushAsync(new NavigationPage(new SecondPage(url)));
        }

    }
}
