namespace CommonPizzaApp.Pages;

public partial class CheckoutPage : ContentPage
{
	private readonly CheckoutViewModel _vm;
    public CheckoutPage(CheckoutViewModel vm)
    {
        InitializeComponent();
        _vm = vm;
        BindingContext = _vm;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        SuccessBtn.ScaleTo(1.5);
        SuccessMessage.ScaleTo(1);

        await SuccessBtn.ScaleTo(0.5);
        await SuccessBtn.ScaleTo(1.5);
        await SuccessBtn.ScaleTo(0.5);
        await SuccessBtn.ScaleTo(1.5);
        await SuccessBtn.ScaleTo(0.5);
        await SuccessBtn.ScaleTo(1.5);
        await SuccessBtn.ScaleTo(1);

        HomtBtn.FadeTo(1);
        await HomtBtn.ScaleTo(1);
    }
}