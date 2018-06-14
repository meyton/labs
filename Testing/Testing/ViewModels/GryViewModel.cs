using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Testing.ViewModels
{
    public class GryViewModel : BaseViewModel
    {
        public Command<string> TestCommand { get; set; }
        public ObservableCollection<string> Items { get; set; }
        private string _labelValue;

        public string LabelValue
        {
            get => _labelValue;
            set
            {
                if (value != _labelValue)
                {
                    _labelValue = value;
                    RaisePropertyChanged(nameof(LabelValue));
                }
            }
        }

        public GryViewModel()
        {
            LabelValue = "Wartość Labelki";
            Items = new ObservableCollection<string>();
            TestCommand = new Command<string>(async (x) => await TestFunction(x));
            Init();
        }

        private async Task<bool> TestFunction(string x)
        {
            var index = int.Parse(x);
            await Task.Delay(4000);
            Items.RemoveAt(index);
            return true;
        }

        private async void Init()
        {
            await Task.Delay(2000);
            LabelValue = "Nowa wartość inna niż wcześniej";
            Items.Add("string 123");
            Items.Add("string 234");
            Items.Add("string 564");
            await Task.Delay(2000);
            Items.Add("string testowy");
            LabelValue = "Wartość LabelkiWartość LabelkiWartość LabelkiWartość LabelkiWartość Labelki";
            await Task.Delay(2000);
            Items.RemoveAt(2);
            LabelValue = "Wartość";
            await Task.Delay(2000);
            LabelValue = "Labelka 1234";
            Items.Add("string 234");
            Items.Add("string 564");
        }
    }
}
