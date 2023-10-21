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
        public static Category enterInformation()
        {
            Category category;
            Console.Write("Category name: ");
            category.name = Console.ReadLine();
            Console.Write("Category description: ");
            category.description = Console.ReadLine();
            Console.Write("Category discount: ");
            category.discount = float.Parse(Console.ReadLine());

            return category;
        }

        public static void addCategory(Product[] products)
        {

        }

        public static void getCategory(Product[] products)
        {

        }

        public static void deleteCategory(Product[] products)
        {

        }
    }
}
