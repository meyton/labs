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
	public partial class SecondPage : ContentPage
	{
		public SecondPage()
		{
			InitializeComponent();
            btnBack.Clicked += BtnBack_Clicked;
		}

        private async void BtnBack_Clicked(object sender, EventArgs e)
        {
            if (Navigation.ModalStack.Any())
                await Navigation.PopModalAsync();
        }
    }
}