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
	public partial class PropertiesPage : ContentPage
	{
		public PropertiesPage ()
		{
			InitializeComponent ();
            if (Properties.AppProperties.ContainsKey("isButtonClicked"))
            {
                var keyValue = Properties.AppProperties["isButtonClicked"].ToString();
                lblproperty.Text = keyValue;
            }            
        }
	}
}