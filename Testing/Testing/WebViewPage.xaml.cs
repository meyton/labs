using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Testing
{
	public partial class WebViewPage : ContentPage
	{
        private string _url;

		public WebViewPage(string url)
		{
			InitializeComponent();
            _url = url;
            wvWeb.Source = _url;
        }
    }
}
