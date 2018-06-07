using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Testing
{
    public class NavigationService
    {
        public static async Task NavigateTo(Page page)
        {
            await Application.Current.MainPage.FadeTo(0.3, 800);
            await Application.Current.MainPage.Navigation.PushAsync(page);
            await Application.Current.MainPage.FadeTo(1.0, 800);
        }
    }
}
