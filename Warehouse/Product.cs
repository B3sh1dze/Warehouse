using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse
{
    public class Product
    {
        public enum Category
        {
            Electronics,
            Appliances,
            Furniture,
            Sports,
            BeautyAndPesronalCare
        }
        public string Name { get; set; }
        public Category ProductCategory { get; set; }
        public double Price { get; set; }
        public int StockAmount { get; set; }
        public Product()
        {

        }
        public Product(string name, Category productCategory, double price, int stockAmount)
        {
            Name = name;
            ProductCategory = productCategory;
            Price = price;
            StockAmount = stockAmount;
        }
        public string ShowInformation()
        {
            return $"Product name: {Name} \n" +
                   $"Product category: {ProductCategory} \n" +
                   $"Product price: {Price} \n" +
                   $"Product stock: {StockAmount}.";
        }
    }
}
