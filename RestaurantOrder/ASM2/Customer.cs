using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    internal class Customer
    {
        private string customerName;
        public List<MenuItem> OrderedItems { get; private set; }
        public int ReservedTable { get; private set; }

        public Customer(string customerName)
        {
            this.customerName = customerName;
            OrderedItems = new List<MenuItem>();
        }


        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public void OrderItem(MenuItem item)
        {
            OrderedItems.Add(item);
        }

        public void ReserveTable(int numberOfTable)
        {
            ReservedTable = numberOfTable;
        }

        public void CheckOrder()
        {
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Reserved Table : {ReservedTable}");
            Console.WriteLine("Ordered Items:");

            List<MenuItem> foodItems = OrderedItems.Where(item => item is FoodItem).ToList();
            List<MenuItem> drinkItems = OrderedItems.Where(item => item is DrinkItem).ToList();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Food :");
            foreach (var item in foodItems)
            {
                Console.WriteLine($"{item.Name} - {item.Price:C}");
            }
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Drink :");
            foreach (var item in drinkItems)
            {
                Console.WriteLine($"{item.Name} - {item.Price:C}");
            }
            Console.ResetColor();
        }
    }
}
    

