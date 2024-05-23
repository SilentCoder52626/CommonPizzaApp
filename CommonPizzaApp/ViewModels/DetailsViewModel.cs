

namespace CommonPizzaApp.ViewModels
{
    [QueryProperty(nameof(Pizza),nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject
    {
        private readonly CartViewModel _cart;

        public DetailsViewModel(CartViewModel cart)
        {
            _cart = cart;
        }

        [ObservableProperty]
        private Pizza _pizza;
        [RelayCommand]
        public async Task AddQuantity()
        {
            Pizza.CardQuantity++;
            _cart.UpdateCartItemCommand.Execute(Pizza);
        }
        [RelayCommand]
        public async Task DecreaseQuantity()
        {
            if(Pizza.CardQuantity > 0)
            {
                Pizza.CardQuantity--;
                _cart.UpdateCartItemCommand.Execute(Pizza);
            }

        }
        [RelayCommand]
        public async Task ViewCart()
        {
            if(Pizza.CardQuantity > 0)
            {
                await Shell.Current.GoToAsync(nameof(CartPage), true);
            }
            else
            {
                await Toast.Make("Please select quantity using plus (+) icon", ToastDuration.Short).Show();
            }
        }
    }
}
