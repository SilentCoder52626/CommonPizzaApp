

namespace CommonPizzaApp.ViewModels
{
    [QueryProperty(nameof(Pizza),nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject
    {
        [ObservableProperty]
        private Pizza _pizza;
        [RelayCommand]
        public async Task AddQuantity()
        {
            Pizza.CardQuantity++;
        }
        [RelayCommand]
        public async Task DecreaseQuantity()
        {
            if(Pizza.CardQuantity > 0)
                Pizza.CardQuantity--;
        }
        [RelayCommand]
        public async Task ViewCart()
        {
            if(Pizza.CardQuantity > 0)
            {

            }
            else
            {
                await Toast.Make("Please select quantity using plus (+) icon", ToastDuration.Short).Show();
            }
        }
    }
}
