using Warehouse;

var obj = new Warehouse.Warehouse();
var product1 = new Product("laptop", Product.Category.Electronics, 2345.3, 5);
var product2 = new Product("PC-Screen", Product.Category.Electronics, 45.3, 6);
var product3 = new Product("table", Product.Category.Furniture, 632, 66);
obj.ProductsList.Add(product1);
obj.ProductsList.Add(product2);
obj.ProductsList.Add(product3);
while (true)
{
    obj.DisplayWarehouseMenu();
    int userChoice = Convert.ToInt32(Console.ReadLine());
    if (userChoice == 1)
    {
        obj.RegisterProduct();
    }
    else if (userChoice == 2)
    {
        obj.ChangeProductPriceAndStock();
        Console.Clear();
    }
    else if (userChoice == 3)
    {
        obj.RemoveProduct();
        Console.Clear();
    }
    else if (userChoice == 4)
    {
        obj.SeeAllProducts();
        Console.Clear();
    }
    else if (userChoice == 5)
    {
        break;
    }
    else
    {
        Console.WriteLine("Wrong input");
        Console.Clear();
    }
}