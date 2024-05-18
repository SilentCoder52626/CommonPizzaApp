using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonPizzaApp.Models
{
    public partial class Pizza : ObservableObject
    {
        public int Id{ get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(Amount))]
        private int _cardQuantity;

        public double Amount => CardQuantity * Price;

        public Pizza Clone() => MemberwiseClone() as Pizza;

    }
}
