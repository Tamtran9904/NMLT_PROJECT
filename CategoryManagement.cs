using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NMLT_PROJECT
{
    public struct Category
    {
        public string name;
        public string description;
        public float discount;
    }
    internal class CategoryManagement
    {
        public static Category enterInformation(Category[] categories)
        {
            Category category;

            Console.WriteLine("Please enter Product information:");
            Console.Write("Category name: ");
            category.name = Console.ReadLine();
            Console.Write("Category description: ");
            category.description = Console.ReadLine();
            Console.Write("Category discount: ");
            category.discount = float.Parse(Console.ReadLine());

            return category;
        }

        public static Category[] addCategory(Category[] categories, Category category)
        {
            if (categories[categories.Length - 1].name != null)
            {
                categories = reSizeArray(categories);
            }
            for (int i = 0; i < categories.Length; i++)
            {
                if (categories[i].name == null)
                {
                    categories[i] = category;
                    return categories;
                }
            }
            return categories;
        }

        public static void displayCategory(Category[] categories)
        {
            string header = "Name".PadRight(10) + "Description".PadRight(20) + "Discount".PadRight(10);
            Console.WriteLine(header);
            for (int i = 0; i < categories.Length; i++)
            {
                if (categories[i].name != null)
                {
                    string product = $"{categories[i].name.PadRight(10)}{categories[i].description.PadRight(20)}{categories[i].discount + "%".PadRight(10)}";
                    Console.WriteLine(product);
                }
            }
        }

        public static void getCategory(Category[] categories)
        {
            string key;
            Console.Write("Please enter any keywords want to GET: ");
            key = Console.ReadLine();
            /*
            if (select <= categories.Length)
            {
                Console.WriteLine("Your category");
                int i = select - 1;
                string category = $"{categories[i].name} - {categories[i].description} - {categories[i].discount}";
                Console.WriteLine(category);
            }
            else Console.WriteLine("This product doesn't exist");
            */
            Category[] result = compare(key, categories);
            displayCategory(result);
        }

        public static Category[] deleteCategory(Category[] categories)
        {
            Category[] newCategories = new Category[100];
            int select;
            int j = 0;

            Console.Write("Please choose the number of category want to DELETE: ");
            select = int.Parse(Console.ReadLine());
            if (select <= categories.Length)
            {
                for (int i = 0; i < categories.Length; i++)
                {
                    if (i != select - 1)
                    {
                        newCategories[j] = categories[i];
                        j++;
                    }
                }
                return newCategories;
            }
            else return newCategories;
        }

        public static Category[] reSizeArray(Category[] categories)
        {
            Category[] newCategories = new Category[categories.Length + 10];
            for (int i = 0; i < categories.Length; i++)
            {
                newCategories[i] = categories[i];
            }
            return newCategories;
        }

        public static Category[] compare(string a, Category[] categories)
        {
            Category[] result = new Category[10];
            int count = 0;
            int legth = a.Length;
            for (int i = 0; i < categories.Length; i++)
            {
                Boolean status = false;
                if (categories[i].name != null)
                {
                    if (a.Length <= categories[i].name.Length)
                    {
                        for (int j = 0; j < categories[i].name.Length; j++)
                        {
                            if (a[0] == categories[i].name[j])
                            {
                                if (a.Length == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != categories[i].name[j + k])
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
                            result[count] = categories[i];
                            count++;
                            continue;
                        }
                    }   
                    status = false;
                    if (a.Length <= categories[i].description.Length)
                    {
                        for (int j = 0; j < categories[i].description.Length; j++)
                        {
                            if (a[0] == categories[i].description[j])
                            {
                                if (a.Length == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != categories[i].description[j + k])
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
                            result[count] = categories[i];
                            count++;
                            continue;
                        }
                    }
                    status = false;
                    if (a.Length <= categories[i].discount.ToString().Length)
                    {
                        for (int j = 0; j < categories[i].discount.ToString().Length; j++)
                        {
                            if (a[0] == categories[i].discount.ToString()[j])
                            {
                                if (a.Length == 1)
                                {
                                    status = true;
                                    break;
                                }
                                for (int k = 1; k < a.Length; k++)
                                {
                                    if (a[k] != categories[i].discount.ToString()[j + k])
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
                            result[count] = categories[i];
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
