using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    internal class RestaurantOrderSystem
    {


        private List<Customer> customers = new List<Customer>();
        private List<MenuItem> menuItems = new List<MenuItem>();
        private int availableTables = 10;

        public void CreateAccount(string customerName)
        {
            customers.Add(new Customer(customerName));
        }
        public void DisplayMenu()
        {
            foreach (var item in menuItems)
            {
                if (item is FoodItem)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow; // Đặt màu xanh cho món ăn
                }
                else if (item is DrinkItem)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                item.Describe(); // Sử dụng tính đa hình để hiển thị mô tả
                Console.ResetColor();
            }
        }

        public void AddMenuItem(MenuItem item)
        {
            try
            {
                if (menuItems.Any(existingItem => existingItem.Name == item.Name))
                {
                    throw new Exception("Item with the same name already exists in the menu.");

                }

                menuItems.Add(item);
                //Console.WriteLine("Item added to the menu.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void DeleteItem(string itemName)
        {
            try
            {
                MenuItem itemToDelete = menuItems.First(item => item.Name == itemName);
                menuItems.Remove(itemToDelete);
                Console.WriteLine("Item deleted from the menu.");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Item not found in the menu.");
            }
        }

        public void ReserveTable(string customerName, int numberOfTable)
        {
            try
            {
                if (availableTables <= 0)
                {
                    Console.WriteLine("No tables available.");
                    return;
                }

                if (numberOfTable < 1 || numberOfTable > 10)
                {
                    Console.WriteLine("Invalid table number. Please choose a table between 1 and 10.");
                    return;
                }


                if (customers.Any(c => c.CustomerName == customerName))
                {
                    throw new Exception("Customer with the same name already exists.");
                }


                if (customers.Any(c => c.ReservedTable == numberOfTable))
                {
                    Console.WriteLine("This table is already reserved.");
                    return;
                }

                Customer customer = new Customer(customerName);
                customer.ReserveTable(numberOfTable);
                customers.Add(customer);
                availableTables--;
                Console.WriteLine("Table reserved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void OrderItem(string customerName, string itemName)
        {
            try
            {
                Customer customer = GetCustomerName(customerName);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                MenuItem menuItem = menuItems.FirstOrDefault(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
                if (menuItem == null)
                {
                    Console.WriteLine("Item not found in the menu.");
                    return;
                }

                customer.OrderItem(menuItem);
                Console.WriteLine($"{itemName} ordered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        public void CheckCustomerOrder(string customerName)
        {
            try
            {
                Customer customer = GetCustomerName(customerName);
                if (customer == null)
                {
                    Console.WriteLine("Customer not found.");
                    return;
                }

                customer.CheckOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private Customer GetCustomerName(string customerName)
        {
            return customers.Find(c => c.CustomerName == customerName);
        }

        public List<MenuItem> GetMenuItems()
        {
            return menuItems;
        }
    }
}


    

