#if IOS
using UIKit;
#endif
namespace CommonPizzaApp.Pages;

public partial class DetailsPage : ContentPage
{
    private readonly DetailsViewModel _vm;
    public DetailsPage(DetailsViewModel vm)
    {
        _vm = vm;
        InitializeComponent();
        BindingContext = _vm;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if IOS
        var bottom = UIApplication.SharedApplication.Delegate.GetWindow().SafeAreaInsets.Bottom;
        BottomBox.Margin = new Thickness(-1, 0, -1, bottom);
#endif
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
    protected override void OnNavigatingFrom(NavigatingFromEventArgs args)
    {
        base.OnNavigatingFrom(args);
        Behaviors.Add(new CommunityToolkit.Maui.Behaviors.StatusBarBehavior
        {
            StatusBarColor = Colors.DarkGoldenrod,
            StatusBarStyle = CommunityToolkit.Maui.Core.StatusBarStyle.DarkContent
        });
    }
}