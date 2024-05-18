namespace CommonPizzaApp.Pages;

public partial class HomePage : ContentPage
{
	private readonly HomeViewModel _vm;
    public HomePage(HomeViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }
}