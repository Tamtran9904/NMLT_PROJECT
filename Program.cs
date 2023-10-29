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
            Product[] products = new Product[3];
            Category[] categories = new Category[10];

            categories = initDataCategory(categories);
            products = initDataProduct(products, categories);

            runApplication(products, categories);
        }

        public static Category[] initDataCategory(Category[] categories)
        {
            Category category1;
            category1.name = "Laptop";
            category1.description = "High Class";
            category1.discount = 25.0F;

            Category category2;
            category2.name = "Tablet";
            category2.description = "Common Class";
            category2.discount = 30.0F;

            CategoryManagement.addCategory(categories, category1);
            CategoryManagement.addCategory(categories, category2);

            return categories;
        }

        public static Product[] initDataProduct(Product[] products, Category[] categories)
        {
            Product product1, product2, product3;
            product1.name = "TUF GAMING";
            product1.companyName = "ASUS";
            product1.expriedDate = "10/10/2025";
            product1.manufacturingYear = 2023;
            product1.category = categories[0];
            product1.code = $"{product1.category.name}{product1.manufacturingYear}";

            product2.name = "LEGION";
            product2.companyName = "LENOVO";
            product2.expriedDate = "10/10/2025";
            product2.manufacturingYear = 2023;
            product2.category = categories[0];
            product2.code = $"{product2.category.name}{product2.manufacturingYear}";

            product3.name = "PAD 6";
            product3.companyName = "XIAOMI";
            product3.expriedDate = "10/10/2025";
            product3.manufacturingYear = 2023;
            product3.category = categories[1];
            product3.code = $"{product3.category.name}{product3.manufacturingYear}";

            ProductManagement.addProduct(products, product1);
            ProductManagement.addProduct(products, product2);
            ProductManagement.addProduct(products, product3);
            return products;
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
                Console.WriteLine();
                switch (select)
                {
                    case 1:
                        displayOptionProduct(products, categories);
                        break;
                    case 2:
                        displayOptionCategory(categories);
                        break;
                    case 3:
                        status = false;
                        break;
                }
            } while (status);
            
        }

        public static void displayOptionProduct(Product[] products, Category[] categories)
        {
            int select;
            Boolean status = true;
            Product product;

            do
            {
                Console.WriteLine();
                Console.WriteLine("SELECT OPTION");
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Display list products");
                Console.WriteLine("3. Get product by any keyword");
                Console.WriteLine("4. Remove roduct");
                Console.WriteLine("5. Back");
                select = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (select)
                {
                    case 1:
                        product = ProductManagement.enterInformation(categories);
                        products = ProductManagement.addProduct(products, product);
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
                        return;
                }
            } while (status);
            
        }

        public static void displayOptionCategory(Category[] categories)
        {
            int select;
            Boolean status = true;
            Category category;

            do
            {
                Console.WriteLine();
                Console.WriteLine("SELECT OPTION");
                Console.WriteLine("1. Add new category");
                Console.WriteLine("2. Display list category");
                Console.WriteLine("3. Get category by any keyword");
                Console.WriteLine("4. Remove category");
                Console.WriteLine("5. Back");
                select = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (select)
                {
                    case 1:
                        category = CategoryManagement.enterInformation(categories);
                        categories = CategoryManagement.addCategory(categories, category);
                        break;
                    case 2:
                        CategoryManagement.displayCategory(categories);
                        break;
                    case 3:
                        CategoryManagement.getCategory(categories);
                        break;
                    case 4:
                        categories = CategoryManagement.deleteCategory(categories);
                        break;
                    case 5:
                        return;
                }
            } while (status);
            
        }
    }
}
