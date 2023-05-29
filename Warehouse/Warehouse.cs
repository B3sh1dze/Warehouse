using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Warehouse
{
    public class Warehouse
    {
        public List<Product> ProductsList { get; set; } = new List<Product>();
        public void RegisterProduct()
        {
            while (true)
            {
                Console.Write("Enter product name: ");
                string name = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(name) && !Regex.IsMatch(name, @"^\d") && !Regex.IsMatch(name, @"^\s|\s$") && name.Length <= 50)
                {
                    int categoryNumber = 1;
                    foreach (var category in Enum.GetValues(typeof(Product.Category)))
                    {
                        Console.WriteLine($"{categoryNumber}. {category}");
                        categoryNumber++;
                    }
                    Console.Write("Enter the category number: ");
                    int selectedCategoryNumber = int.Parse(Console.ReadLine()!);
                    Product.Category selectedCategory = (Product.Category)(selectedCategoryNumber - 1);
                    Console.Write("Enter product price: ");
                    double price = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter product amount: ");
                    int amount = Convert.ToInt32(Console.ReadLine());
                    var newProduct = new Product()
                    {
                        Name = name,
                        ProductCategory = selectedCategory,
                        Price = price,
                        StockAmount = amount
                    };
                    ProductsList.Add(newProduct);
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("There must be some mistakes in the entered name.");
                    Console.WriteLine("Make sure that entered name isn't empty, begins or lasts with free space, doesn't starts with numbers and is no longer than 50 characters.");
                    continue;
                }
            }
        }
        public void ChangeProductPriceAndStock()
        {
            Console.WriteLine("Choose which one product you want to make changes: ");
            Console.WriteLine();
            int iterator = 1;
            foreach (var product in ProductsList)
            {
                Console.WriteLine(iterator + ". " + product.ShowInformation());
                Console.WriteLine();
                iterator++;
            }
            int userChoice = Convert.ToInt32(Console.ReadLine());
            var ChosenProduct = ProductsList[userChoice - 1];
            Console.WriteLine();
            Console.WriteLine("Choose which one you want to change: ");
            Console.WriteLine("1. price");
            Console.WriteLine("2. amount");
            Console.WriteLine("3 both of them");
            int userInput = Convert.ToInt32(Console.ReadLine());
            if (userInput == 1)
            {
                Console.WriteLine();
                Console.Write("Enter the new price: ");
                double newPrice = Convert.ToDouble(Console.ReadLine());
                ChosenProduct.Price = newPrice;
                Console.WriteLine(ChosenProduct.ShowInformation());
                Console.WriteLine("Price changed sucessfully");
                Console.WriteLine("press any key to go to main menu.");
                Console.ReadKey();
            }
            else if (userInput == 2)
            {
                Console.WriteLine();
                Console.Write("Enter the new amount: ");
                int newAmount = Convert.ToInt32(Console.ReadLine());
                ChosenProduct.StockAmount = newAmount;
                Console.WriteLine(ChosenProduct.ShowInformation());
                Console.WriteLine("amount changed sucessfully");
                Console.WriteLine("press any key to go to main menu.");
                Console.ReadKey();
            }
            else if (userInput == 3)
            {
                Console.WriteLine();
                Console.Write("Enter the new price: ");
                double newPrice = Convert.ToDouble(Console.ReadLine());
                ChosenProduct.Price = newPrice;
                Console.WriteLine();
                Console.Write("Enter the new amount: ");
                int newAmount = Convert.ToInt32(Console.ReadLine());
                ChosenProduct.StockAmount = newAmount;
                Console.WriteLine(ChosenProduct.ShowInformation());
                Console.WriteLine("price and amount changed sucessfully");
                Console.WriteLine("press any key to go to main menu.");
                Console.ReadKey();
            }
        }
        public void RemoveProduct()
        {
            Console.WriteLine("Choose which one product you want to remove: ");
            Console.WriteLine();
            int iterator = 1;
            foreach (var product in ProductsList)
            {
                Console.WriteLine(iterator + ". " + product.ShowInformation());
                Console.WriteLine();
                iterator++;
            }
            int userChoice;
            while (!int.TryParse(Console.ReadLine(), out userChoice) || userChoice < 1 || userChoice > ProductsList.Count)
            {
                Console.WriteLine("Invalid product number. Please try again.");
            }
            var ChosenProduct = ProductsList[userChoice - 1];
            ProductsList.Remove(ChosenProduct);
            Console.WriteLine("product removed successfully");
            Console.WriteLine("press any key to go to main menu.");
            Console.ReadKey();
        }
        public void SeeAllProducts()
        {
            Console.WriteLine("There is all proucts stored in our warehouse");
            int iterator = 1;
            foreach (var product in ProductsList)
            {
                Console.WriteLine(iterator + ". " + product.ShowInformation());
                Console.WriteLine();
                iterator++;
            }
            Console.WriteLine("press any key to go to main menu.");
            Console.ReadKey();
        }
        public void DisplayWarehouseMenu()
        {
            Console.WriteLine("1. register product");
            Console.WriteLine("2. Change product price and amount");
            Console.WriteLine("3. remove product");
            Console.WriteLine("4. see all products");
            Console.WriteLine("5. exit");
        }
    }
}
