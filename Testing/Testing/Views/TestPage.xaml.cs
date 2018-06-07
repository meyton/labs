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
	public partial class TestPage : ContentPage
	{
        private TestViewModel _viewModel;

		public TestPage ()
		{
			InitializeComponent ();
            _viewModel = new TestViewModel();
            BindingContext = _viewModel;
		}
	}
}