using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPizzaApp.ViewModels
{
    public partial class CheckoutViewModel: ObservableObject
    {
        [RelayCommand]
        private async void GotToHomePage()
        {
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}",true);
        }
    }
}
