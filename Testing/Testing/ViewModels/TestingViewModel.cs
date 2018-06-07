using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testing.Models.Sqlite;
using Xamarin.Forms;

namespace Testing.ViewModels
{
    public class TestingViewModel : BaseViewModel
    {
        public Command NavigateCommand { get; private set; }
        public Command<string> CategoryCommand { get; private set; }

        public ObservableCollection<Category> Items { get; set; }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                if (_message != value)
                {
                    _message = value;
                    RaisePropertyChanged(nameof(Message));
                }
            }
        }

        private string _btnText;

        public string BtnText
        {
            get => _btnText;
            set
            {
                if (_btnText != value)
                {
                    _btnText = value;
                    RaisePropertyChanged(nameof(BtnText));
                }
            }
        }

        public TestingViewModel()
        {
            Message = "To jest message.";
            BtnText = "Testuj command";
            Items = new ObservableCollection<Category>();
            NavigateCommand = new Command(async () => await Navigate());
            CategoryCommand = new Command<string>(async (c) => await AddCategory(c));
            Init();
        }

        public async Task Navigate()
        {
            await NavigationService.NavigateTo(new Views.TestPage());
        }

        public async Task AddCategory(string category)
        {
            var cat = new Category() { Range = category };
            await App.LocalDB.SaveItemAsync(cat);
            var categories = await App.LocalDB.GetItems<Category>();
            Items.Add(categories.LastOrDefault());
        }
        
        private async void Init()
        {
            await Task.Delay(3000);
            Message = "Finalne ostrzeżenie";
            var categories = await App.LocalDB.GetItems<Category>();
            foreach (var c in categories)
            {
                Items.Add(c);
            }
        }
    }
}
