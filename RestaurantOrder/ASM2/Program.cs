using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2
{
    internal class Program
    {
       
        
            static void Main(string[] args)
            {
                RestaurantOrderSystem orderSystem = new RestaurantOrderSystem();

                orderSystem.AddMenuItem(new FoodItem("Pizza", 10.99M));
                orderSystem.AddMenuItem(new FoodItem("Burger", 7.99M));
                orderSystem.AddMenuItem(new FoodItem("Pasta", 8.49M));
                orderSystem.AddMenuItem(new DrinkItem("Cola", 2.49M));
                orderSystem.AddMenuItem(new DrinkItem("Sprite", 2.49M));


                try
                {
                    while (true)
                    {
                        Console.WriteLine("===== Restaurant Order System =====");
                        Console.WriteLine("1. Place a table");
                        Console.WriteLine("2. Check Menu");
                        Console.WriteLine("3. Order Dish");
                        Console.WriteLine("4. Add New Item");
                        Console.WriteLine("5. Delete Item");
                        Console.WriteLine("6. Check Customer Order");
                        Console.WriteLine("7. Edit Price");
                        Console.WriteLine("8. Exit");
                        Console.WriteLine("====================================");


                        Console.Write("Enter your choice: ");
                        int choice;
                        if (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                            continue;
                        }

                        switch (choice)
                        {
                            case 1:
                                Console.Write("Enter customer name: ");
                                string customerName = Console.ReadLine();
                                Console.Write("Enter number of tables: ");
                                int numberOfTable;
                                if (!int.TryParse(Console.ReadLine(), out numberOfTable))
                                {
                                    Console.WriteLine("Invalid input. Please enter a number.");
                                    continue;
                                }
                                orderSystem.ReserveTable(customerName, numberOfTable);
                                //Console.WriteLine("Table is created successfully.");
                                break;
                            case 2:
                                Console.WriteLine("Menu:");
                                orderSystem.DisplayMenu();
                                break;
                            case 3:
                                Console.Write("Enter customer name: ");
                                string foodCustomer = Console.ReadLine();
                                Console.Write("Enter dish item: ");
                                string dishItem = Console.ReadLine().ToLower();
                                orderSystem.OrderItem(foodCustomer, dishItem);
                                break;
                            case 4:
                                Console.Write("Enter item name: ");
                                string newItemName = Console.ReadLine();
                                Console.Write("Enter price: ");
                                decimal itemPrice;
                                if (!decimal.TryParse(Console.ReadLine(), out itemPrice))
                                {
                                    Console.WriteLine("Invalid input. Please enter a valid price.");
                                    continue;
                                }
                                Console.Write("Enter item type (Food or Drink): ");
                                string itemType = Console.ReadLine().ToLower();
                                if (itemType == "food" || itemType == "drink")
                                {
                                    if (itemType == "food")
                                    {
                                        orderSystem.AddMenuItem(new FoodItem(newItemName, itemPrice));
                                    }
                                    else
                                    {
                                        orderSystem.AddMenuItem(new DrinkItem(newItemName, itemPrice));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid item type. Use 'food' or 'drink'.");
                                }
                                break;
                            case 5:
                                Console.Write("Enter item name to delete: ");
                                string itemToDeleteName = Console.ReadLine();
                                orderSystem.DeleteItem(itemToDeleteName);
                                break;
                            case 6:
                                Console.Write("Enter customer name to check order: ");
                                string customerToCheck = Console.ReadLine();
                                orderSystem.CheckCustomerOrder(customerToCheck);
                                break;
                            case 7:
                                Console.Write("Enter the name of the item you want to edit: ");
                                string itemToEdit = Console.ReadLine().ToLower();
                                MenuItem item = orderSystem.GetMenuItems().FirstOrDefault(i => i.Name.ToLower() == itemToEdit);

                                if (item != null)
                                {
                                    Console.Write("Enter the new price for the item: ");
                                    decimal newPrice;
                                    if (decimal.TryParse(Console.ReadLine(), out newPrice))
                                    {
                                        item.Price = newPrice;
                                        Console.WriteLine($"{item.Name}'s price updated to {newPrice:C}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid price. Please enter a valid price.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Item not found in the menu.");
                                }
                                break;
                            case 8:
                                Environment.Exit(0);
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }

