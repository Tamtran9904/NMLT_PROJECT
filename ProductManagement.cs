using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMLT_PROJECT

    
{
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
            Console.Write("Product expiredDate: dd/MM/yyyy");
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
            product.code = $"{product.category.name}{product.manufacturingYear}";
            return product;
        }

        public static Product[] addProduct(Product[] products, Product product)
        {
            if (products[products.Length -1].code != null)
            {
                products = reSizeArray(products);
            }
            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].code == null)
                {
                    products[i] = product;
                    return products;
                }
            }
            return products;
        }

        public static void displayProducts(Product[] products)
        {
            string header = "Code".PadRight(15) + "Name".PadRight(18) + "Expired Date".PadRight(15) + "Company Name".PadRight(15) + "Manufacturing Year".PadRight(20) + "Category".PadRight(10);
            Console.WriteLine(header);

            for (int i = 0; i < products.Length; i++)
            {
                if (products[i].name != null)
                {
                    string product = $"{products[i].code.PadRight(15)}{products[i].name.PadRight(18)}{products[i].expriedDate.PadRight(15)}{products[i].companyName.PadRight(15)}{products[i].manufacturingYear.ToString().PadRight(20)}{products[i].category.name.PadRight(10)}";
                    Console.WriteLine(product);
                }
                
            }
        }

        public static void  getProduct(Product[] products)
        {
            string key;
            Console.Write("Please enter any keywords want to GET: ");
            key = Console.ReadLine();
            /*
            if (select <= products.Length)
            {
                Console.WriteLine("Your product");
                int i = select - 1;
                string product = $"{products[i].code} - {products[i].name} - {products[i].expriedDate} - {products[i].companyName} - {products[i].manufacturingYear} - {products[i].category.name}";
                Console.WriteLine(product);
            } else Console.WriteLine("This product doesn't exist");
            */
            Product[] result = compare(key, products);
            displayProducts(result);
        }

        public static Product[] deleteProduct(Product[] products)
        {
            Product[] newProducts = new Product[10];
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

        public static Product[] reSizeArray(Product[] products)
        {
            Product[] newProducts = new Product[products.Length + 10];
            for (int i = 0; i < products.Length; i++)
            {
                newProducts[i] = products[i];
            }
            return newProducts;
        }

        public static Product[] compare(string a, Product[] products)
        {
            Product[] result = new Product[10];
            int count = 0;
            int legth = a.Length;
            for (int i = 0; i < products.Length; i++) {
                Boolean status = false;
                if (products[i].name != null)
                {
                    if (a.Length <= products[i].code.Length)
                    {
                        for (int j = 0; j < products[i].code.Length; j++)
                        {
                            if (a[0] == products[i].code[j])
                            {
                                if (a.Length  == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != products[i].code[j + k])
                                    {
                                        status = false;
                                        break;
                                    }
                                    status = true;
                                }
                                if (status)
                                {
                                    break;
                                }
                            }
                        }
                        if (status == true)
                        {
                            result[count] = products[i];
                            count++;
                            continue;
                        }
                    }
                    status = false;
                    if (a.Length <= products[i].name.Length)
                    {
                        for (int j = 0; j < products[i].name.Length; j++)
                        {
                            if (a[0] == products[i].name[j])
                            {
                                if (a.Length == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != products[i].name[j + k])
                                    {
                                        status = false;
                                        break;
                                    }
                                    status = true;
                                }
                                if (status)
                                {
                                    break;
                                }
                            }
                        }
                        if (status == true)
                        {
                            result[count] = products[i];
                            count++;
                            continue;
                        }
                    }
                    status = false;
                    if (a.Length <= products[i].expriedDate.Length)
                    {
                        for (int j = 0; j < products[i].expriedDate.Length; j++)
                        {
                            if (a[0] == products[i].expriedDate[j])
                            {
                                if (a.Length == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != products[i].expriedDate[j + k])
                                    {
                                        status = false;
                                        break;
                                    }
                                    status = true;
                                }
                                if (status)
                                {
                                    break;
                                }
                            }
                        }
                        if (status == true)
                        {
                            result[count] = products[i];
                            count++;
                            continue;
                        }
                    }  
                    status = false;
                    if (a.Length <= products[i].companyName.Length)
                    {
                        for (int j = 0; j < products[i].companyName.Length; j++)
                        {
                            if (a[0] == products[i].companyName[j])
                            {
                                if (a.Length == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != products[i].companyName[j + k])
                                    {
                                        status = false;
                                        break;
                                    }
                                    status = true;
                                }
                                if (status)
                                {
                                    break;
                                }
                            }
                        }
                        if (status == true)
                        {
                            result[count] = products[i];
                            count++;
                            continue;
                        }
                    }  
                    status = false;
                    if (a.Length <= products[i].manufacturingYear.ToString().Length)
                    {
                        for (int j = 0; j < products[i].manufacturingYear.ToString().Length; j++)
                        {
                            if (a[0] == products[i].manufacturingYear.ToString()[j])
                            {
                                if (a.Length == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != products[i].manufacturingYear.ToString()[j + k])
                                    {
                                        status = false;
                                        break;
                                    }
                                    status = true;
                                }
                                if (status)
                                {
                                    break;
                                }
                            }
                        }
                        if (status == true)
                        {
                            result[count] = products[i];
                            count++;
                            continue;
                        }
                    }
                    status = false;
                    if (a.Length <= products[i].category.name.Length)
                    {
                        for (int j = 0; j < products[i].category.name.Length; j++)
                        {
                            if (a[0] == products[i].category.name[j])
                            {
                                if (a.Length == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != products[i].category.name[j + k])
                                    {
                                        status = false;
                                        break;
                                    }
                                    status = true;
                                }
                                if (status)
                                {
                                    break;
                                }
                            }
                        }
                        if (status == true)
                        {
                            result[count] = products[i];
                            count++;
                            continue;
                        }
                    }
                }
            }
            return result;
        }
    }
}
