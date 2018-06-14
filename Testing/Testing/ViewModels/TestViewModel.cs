using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Testing.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        public ObservableCollection<string> Items { get; set; }
        public ImageSource Icon { get; set; }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                if (value != _message)
                {
                    _message = value;
                    RaisePropertyChanged(nameof(Message));
                }
            }
        }

        public TestViewModel()
        {
            Message = "To jest message";
            Items = new ObservableCollection<string>();
            Init();
            Icon = ImageSource.FromFile("trash.png");
        }

        private async void Init()
        {
            await Task.Delay(5000);
            Message = "Timeout upłynął";
            Items.Add("String 1");
            await Task.Delay(3000);
            Items.Add("String 2");
            await Task.Delay(3000);
            Items.Add("String 3");
            await Task.Delay(3000);
            Items.Add("String 4");
        }
    }
}
