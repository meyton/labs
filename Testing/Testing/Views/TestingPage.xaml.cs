﻿using System;
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
	public partial class TestingPage : ContentPage
	{
        private TestingViewModel _viewModel;

		public TestingPage ()
		{
			InitializeComponent ();
            _viewModel = new TestingViewModel();
            BindingContext = _viewModel;
		}
	}
}