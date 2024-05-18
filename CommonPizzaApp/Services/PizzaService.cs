using CommonPizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPizzaApp.Services
{
    public class PizzaService
    {
        private readonly static IEnumerable<Pizza> _pizzas = new List<Pizza>()
        {
            new Pizza
            {
                Id = 1,
                Name = "Pizza One",
                Image = "pizza_one.png",
                Price = 200,
                Rating=4.1
            },new Pizza
            {
                Id = 2,
                Name = "Pizza Two",
                Image = "pizza_two.png",
                Price = 220,
                Rating=4.1
            },new Pizza
            {
                Id = 3,
                Name = "Pizza Three",
                Image = "pizza_three.png",
                Price = 230,
                Rating=4.1
            },new Pizza
            {
                Id = 4,
                Name = "Pizza Four",
                Image = "pizza_four.png",
                Price = 190,
                Rating=4.1
            },new Pizza
            {
                Id = 5,
                Name = "Pizza Five",
                Image = "pizza_five.png",
                Price = 200,
                Rating=4.1
            },new Pizza
            {
                Id = 6,
                Name = "Pizza Six",
                Image = "pizza_six.png",
                Price = 240,
                Rating=4.1
            },new Pizza
            {
                Id = 7,
                Name = "Pizza Seven",
                Image = "pizza_seven.png",
                Price = 210,
                Rating=4.1
            },new Pizza
            {
                Id = 8,
                Name = "Pizza Eight",
                Image = "pizza_eight.png",
                Price = 195,
                Rating=4.1
            },new Pizza
            {
                Id = 9,
                Name = "Pizza Nine",
                Image = "pizza_nine.png",
                Price = 220,
                Rating=4.1
            },new Pizza
            {
                Id = 10,
                Name = "Pizza Ten",
                Image = "pizza_ten.png",
                Price = 200,
                Rating=4.1
            }
        };


        public IEnumerable<Pizza> GetAllPizzas() => _pizzas;

        public IEnumerable<Pizza> GetPopularPizzas(int count = 6)
        {
            return _pizzas.OrderBy(a => Guid.NewGuid()).Take(count);
        }
        public IEnumerable<Pizza> GetPizzas(string search)
        {
            if(String.IsNullOrEmpty(search))
                return _pizzas;
            return _pizzas.Where(a => a.Name.Contains(search,StringComparison.OrdinalIgnoreCase));
        }
    }
}
