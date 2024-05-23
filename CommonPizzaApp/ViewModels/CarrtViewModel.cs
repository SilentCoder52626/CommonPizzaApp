using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPizzaApp.ViewModels
{
    public partial class CartViewModel : ObservableObject
    {


        public EventHandler<Pizza> CartItemRemoved;
        public EventHandler<Pizza> CartItemUpdated;
        public EventHandler CartCleared;
        public ObservableCollection<Pizza> Items { get; set; } = new();

        [ObservableProperty]
        private double _totalAmount;
        private void ReCalculateTotalAmount() => TotalAmount = Items.Sum(c => c.Amount);
        [RelayCommand]
        private void UpdateCartItem(Pizza pizza)
        {
            var item = Items.FirstOrDefault(a => a.Id == pizza.Id);
            if (item is not null)
            {
                item.CardQuantity = pizza.CardQuantity;
            }
            else
            {
                Items.Add(pizza.Clone());
            }
            ReCalculateTotalAmount();
        }
        [RelayCommand]
        private async void RemoveCartItem(int Id)
        {
            var item = Items.FirstOrDefault(a => a.Id == Id);
            if (item is not null)
            {
                Items.Remove(item);
                ReCalculateTotalAmount();
                CartItemRemoved?.Invoke(this,item);
                var snackBar = Snackbar.Make($"'{item.Name}' removed from cart.", () =>
                {
                    Items.Add(item);
                    CartItemUpdated?.Invoke(this,item);

                }, "Undo",TimeSpan.FromSeconds(5),new SnackbarOptions() { CornerRadius=10, BackgroundColor=Colors.PaleGoldenrod});
                await snackBar.Show();
                
            }

        }
        [RelayCommand]
        private async void ClearCart()
        {
            if (await Shell.Current.DisplayAlert("Confirm Clear Cart?", "Do you really want to clear cart.", "Yes", "No"))
            {
                Items.Clear();
                ReCalculateTotalAmount();
                CartCleared?.Invoke(this,EventArgs.Empty);
                await Toast.Make("Cart Cleared.",ToastDuration.Short).Show();
            }

        }
        [RelayCommand]
        private async Task PlaceOrder()
        {
            Items.Clear();
            ReCalculateTotalAmount();
            CartCleared?.Invoke(this, EventArgs.Empty);
            await Shell.Current.GoToAsync(nameof(CheckoutPage));
        }
    }
}
