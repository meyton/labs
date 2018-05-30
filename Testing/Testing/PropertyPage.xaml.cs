using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testing
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PropertyPage : ContentPage
	{
		public PropertyPage ()
		{
			InitializeComponent ();

            if (Properties.AppProperties.ContainsKey("isButtonClicked"))
            {
                var keyValue = Properties.AppProperties["isButtonClicked"].ToString();
                lblProperty.Text = keyValue;
            }
		}
	}
}