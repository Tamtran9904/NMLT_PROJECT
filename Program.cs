using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMLT_PROJECT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[100];
            Category[] categories = new Category[10];

            Category category1;
            category1.name = "Laptop";
            category1.description = "High Class";
            category1.discount = 25.0F;
            categories[0] = category1;

            Category category2;
            category2.name = "Tablet";
            category2.description = "Common Class";
            category2.discount = 30.0F;
            categories[1] = category2;

            Product product1, product2, product3;
            product1.code = "TEST1";
            product1.name = "TUF GAMING";
            product1.companyName = "ASUS";
            product1.expriedDate = "10/10/2025";
            product1.manufacturingYear = 2023;
            product1.category = categories[0];
            products[0] = product1;

            product2.code = "TEST2";
            product2.name = "LEGION";
            product2.companyName = "LENOVE";
            product2.expriedDate = "10/10/2025";
            product2.manufacturingYear = 2023;
            product2.category = categories[0];
            products[1] = product2;

            product3.code = "TEST3";
            product3.name = "PAD 6";
            product3.companyName = "XIAOMI";
            product3.expriedDate = "10/10/2025";
            product3.manufacturingYear = 2023;
            product3.category = categories[1];
            products[2] = product3;

            runApplication(products, categories);
        }

        public static void runApplication(Product[] products, Category[] categories)
        {
            int select;
            Boolean status = true;

            do
            {
                Console.WriteLine("Welcome to my Store Application");
                Console.WriteLine("SELECT OPTION");
                Console.WriteLine("1. Product");
                Console.WriteLine("2. Category");
                Console.WriteLine("3. Exit");
                select = int.Parse(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        displayOption(products, categories);
                        break;
                    case 2:
                       
                        break;
                    case 3:
                        status = false;
                        break;
                }
            } while (status);
        }

        public static void displayOption(Product[] products, Category[] categories)
        {
            int select;
            Boolean status = true;
            Product product;

            do
            {
                Console.WriteLine("List of products:");
                Console.WriteLine("SELECT OPTION");
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Display list products");
                Console.WriteLine("3. Get product");
                Console.WriteLine("4. Remove roduct");
                select = Convert.ToInt32(Console.ReadLine());
                switch (select)
                {
                    case 1:
                        product = ProductManagement.enterInformation(categories);
                        ProductManagement.addProduct(products, product);
                        break;
                    case 2:
                        ProductManagement.displayProducts(products);
                        break;
                    case 3:
                        ProductManagement.getProduct(products);
                        break;
                    case 4:
                        products = ProductManagement.deleteProduct(products);
                        break;
                    case 5:
                        status = false;
                        break;
                }
            } while (status);
            
        }
    }
}
