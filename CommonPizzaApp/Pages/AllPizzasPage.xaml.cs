namespace CommonPizzaApp.Pages;

public partial class AllPizzasPage : ContentPage
{
	private readonly AllPizzasViewModel _vm;
	public AllPizzasPage(AllPizzasViewModel vm)
	{
		InitializeComponent();
		_vm = vm;
		BindingContext = _vm;
	}
    protected override async void OnAppearing()
    {
        base.OnAppearing();
		if (_vm.FromSearch)
		{
			await Task.Delay(200);
            searchBar.Focus();
		}
    }

    private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
		if(!String.IsNullOrEmpty(e.OldTextValue) && String.IsNullOrEmpty(e.NewTextValue))
		{
			_vm.SearchPizzasCommand.Execute(null);
		}
    }
}