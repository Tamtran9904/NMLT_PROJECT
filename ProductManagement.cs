using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMLT_PROJECT

    
{
    public struct Date
    {
        public int day;
        public int month;
        public int year;
    }

    public struct Product
    {
        public string code;
        public string name;
        public string expriedDate;
        public string companyName;
        public int manufacturingYear;
        public Category category;
    }
    internal class ProductManagement
    {
        public static Product enterInformation(Category[] categories)
        {
            Product product;
            int select;
            Boolean status = true;

            Console.WriteLine("Please enter Product information:");
            Console.Write("Product name: ");
            product.name = Console.ReadLine();
            Console.Write("Product expiredDate: ");
            product.expriedDate = Console.ReadLine();
            Console.Write("Product companyName: ");
            product.companyName = Console.ReadLine();
            Console.Write("Product manufacturingYear: ");
            product.manufacturingYear = int.Parse(Console.ReadLine());
            do
            {
                Console.WriteLine("Please choose category");
                select = int.Parse(Console.ReadLine());
                if (select <= categories.Length && select > 0)
                {
                    status = false;
                }
            } while (status);
            product.category = categories[select - 1];
            //Handle code product
            product.code = $"{product.category.name}{product.expriedDate}";
            return product;
        }

        public static void addProduct(Product[] products, Product product)
        {
            products[products.Length] = product;
        }

        public static void displayProducts(Product[] products)
        {
            for (int i = 0; i < products.Length; i++)
            {
                string product = $"{products[i].code} - {products[i].name} - {products[i].expriedDate} - {products[i].companyName} - {products[i].manufacturingYear} - {products[i].category.name}";
                Console.WriteLine(product);
            }
        }

        public static void getProduct(Product[] products)
        {
            int select;
            Console.Write("Please choose the number of product want to GET: ");
            select = int.Parse(Console.ReadLine());
            if (select <= products.Length)
            {
                Console.WriteLine("Your product");
                int i = select - 1;
                string product = $"{products[i].code} - {products[i].name} - {products[i].expriedDate} - {products[i].companyName} - {products[i].manufacturingYear} - {products[i].category.name}";
                Console.WriteLine(product);
            } else Console.WriteLine("This product doesn't exist");
        }

        public static Product[] deleteProduct(Product[] products)
        {
            Product[] newProducts = new Product[100];
            int select;
            int j = 0;

            Console.Write("Please choose the number of product want to DELETE: ");
            select = int.Parse(Console.ReadLine());
            if (select <= products.Length)
            {
                for (int i = 0; i < products.Length; i++)
                {
                    if (i != select - 1)
                    {
                        newProducts[j] = products[i];
                        j++;
                    }
                }
                return newProducts;
            }
            else return products;
        }
    }
}
