using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Testing
{
	public partial class SecondPage : ContentPage
	{
        private string _url;

		public SecondPage(string url)
		{
			InitializeComponent();
            _url = url;
            //wvWeb.Source = url;
        }

        internal async void btnClicked(object sender, EventArgs e)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(_url);
                var status = response.StatusCode;
            }
        }
    }
}
