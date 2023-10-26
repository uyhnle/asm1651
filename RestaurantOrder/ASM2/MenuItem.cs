using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    public class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public MenuItem(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual void Describe()
        {
            Console.WriteLine($"{Name} - ${Price}");
        }
    }

    public class FoodItem : MenuItem
    {
        public FoodItem(string name, decimal price) : base(name, price) { }

        public override void Describe()
        {
            Console.WriteLine($"{Name} - ${Price} (Food)");
        }
    }

    public class DrinkItem : MenuItem
    {
        public DrinkItem(string name, decimal price) : base(name, price) { }

        public override void Describe()
        {
            Console.WriteLine($"{Name} - ${Price} (Drink)");
        }
    }
}


