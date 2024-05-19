namespace CommonPizzaApp.ViewModels
{
    [QueryProperty(nameof(FromSearch), nameof(FromSearch))]
    public partial class AllPizzasViewModel : ObservableObject
    {
        private readonly PizzaService _pizzaService;

        public AllPizzasViewModel(PizzaService pizzaService)
        {
            _pizzaService = pizzaService;
            Pizzas = new(_pizzaService.GetAllPizzas());
        }
        public ObservableCollection<Pizza> Pizzas { get; set; }

        [ObservableProperty]
        private bool _fromSearch;

        [ObservableProperty]
        private bool _searching;
        
        [RelayCommand]
        private async Task SearchPizzas(string search)
        {
            Pizzas.Clear();
            Searching = true;
            var pizzas = _pizzaService.GetPizzas(search);
            await Task.Delay(500);
            foreach (var pizza in pizzas)
            {
                Pizzas.Add(pizza);
            }
            Searching = false;
        }


    }
}
