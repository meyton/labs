using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Testing.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GryPage : ContentPage
	{
        private GryViewModel _viewModel;
		public GryPage ()
		{
			InitializeComponent ();
            _viewModel = new GryViewModel();
            BindingContext = _viewModel;
		}
	}
}