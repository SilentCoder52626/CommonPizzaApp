
namespace CommonPizzaApp.Pages;

public partial class CartPage : ContentPage
{
	private readonly CartViewModel _vm;
    public CartPage(CartViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }
}