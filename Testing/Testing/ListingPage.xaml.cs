using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testing
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListingPage : ContentPage
	{
		public ListingPage ()
		{
			InitializeComponent ();
            lvItems.ItemsSource = new List<object>()
            {
                new { Id = "123", Name = "siema" },
                new { Id = "234", Name = "siema 2" },
                new { Id = "345", Name = "siema 3" }
            };
            lvItems.ItemTapped += LvItems_ItemTapped;
		}

        private void LvItems_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = e.Item;
        }
    }
}