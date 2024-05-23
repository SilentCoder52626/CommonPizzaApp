

using System.Runtime.InteropServices;

namespace CommonPizzaApp.ViewModels
{
    [QueryProperty(nameof(Pizza),nameof(Pizza))]
    public partial class DetailsViewModel : ObservableObject,IDisposable
    {
        private readonly CartViewModel _cart;

        public DetailsViewModel(CartViewModel cart)
        {
            _cart = cart;
            _cart.CartCleared += OnCartCleared;
            _cart.CartItemUpdated += OnCartItemUpdated;
            _cart.CartItemRemoved += OnCartItemRemoved;
        }
        private void OnCartCleared(object? _, EventArgs e) => Pizza.CardQuantity = 0;
        private void OnCartItemRemoved(object? _, Pizza p) => OnCartItemChanged(p, 0);
        private void OnCartItemUpdated(object? _, Pizza p) => OnCartItemChanged(p, p.CardQuantity);
        private void OnCartItemChanged(Pizza p, int quatity)
        {
            if(p.Id == Pizza.Id)
            {
                Pizza.CardQuantity = quatity;
            }
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

        public void Dispose()
        {
            _cart.CartCleared -= OnCartCleared;
            _cart.CartItemUpdated -= OnCartItemUpdated;
            _cart.CartItemRemoved -= OnCartItemRemoved;
        }
    }
}
