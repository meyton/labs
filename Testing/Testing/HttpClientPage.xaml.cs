using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Testing
{
	public partial class HttpClientPage : ContentPage
	{
        private string _url;

		public HttpClientPage(string url)
		{
			InitializeComponent();
            _url = url;
        }

        internal async void btnClicked(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_url);
                var status = response.StatusCode;
                await DisplayAlert("Status Code", "Strona odpowiedziała statusem: " + status, "OK");
            }
        }
    }
}
