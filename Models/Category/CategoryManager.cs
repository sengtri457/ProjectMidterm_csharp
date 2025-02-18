using MIdTerm_c_.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models.Category
{
    internal class CategoryManager
    {


        public int Id { get; set; }
        public string NameUnique { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public static List<CategoryManager> CategoryLists = new List<CategoryManager>();

        public void AddCategory(string createdByUser)
        {
            Console.WriteLine("------------------------------ Category --------------------------------");
            int n;
            Console.Write("Input Number Record :");
            n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                CategoryManager category = new CategoryManager();
                Console.Write("Input Id :");
                category.Id = int.Parse(Console.ReadLine());
                while (true)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    if (CategoryLists.Any(u => u.NameUnique == name))
                    {
                        Console.WriteLine("Username already exists. Please enter a unique username.");
                    }
                    else
                    {
                        category.NameUnique = name;
                        break;
                    }
                }
                Console.Write("Input Status (True/False):");
                category.Status = bool.Parse(Console.ReadLine());
                category.UpdateBy = createdByUser;
                category.CreateBy = createdByUser;
                category.CreateAt = DateTime.Now;
                category.UpdateAt = DateTime.Now;
                CategoryLists.Add(category);
                Console.WriteLine("------------------ Category Added Successfully ---------------------");
            }
        }
        public void ShowCategory()
        {
            Console.WriteLine("------------------------------ Category's Lists ------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            string columnHeader = string.Format("{0,-10}{1,-15}{2,-15}{3,-25}{4,-15}{5,-25}{6,-15}",
                                                "Id", "Name", "Status", "Create At", "Create By", "Update At", "Update By");
            Console.WriteLine(columnHeader);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            foreach (var category in CategoryLists)
            {
                string dataRecord = string.Format("{0,-10}{1,-15}{2,-15}{3,-25}{4,-15}{5,-25}{6,-15}",
                                                 category.Id, category.NameUnique, category.Status, category.CreateAt,
                                                 category.CreateBy, category.UpdateAt, category.UpdateBy);
                Console.WriteLine(dataRecord);
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }
        }
        public void UpdateCategoryById(string createdByUser)
        {
            Console.WriteLine("------------------------------ Update Category --------------------------------");
            try
            {
                Console.Write("Enter User ID to update: ");
                int id = int.Parse(Console.ReadLine());

                CategoryManager catFind = CategoryLists.Find(u => u.Id == id);
                if (catFind == null)
                {
                    Console.WriteLine("Category not found.");
                    return;
                }
                Console.WriteLine("Leave field blank to keep old value.");
                Console.Write("New Name: ");
                string newUsername = Console.ReadLine();
                if (!string.IsNullOrEmpty(newUsername))
                    catFind.NameUnique = newUsername;
                Console.Write("New Status (true/false): ");
                string newStatus = Console.ReadLine();
                if (!string.IsNullOrEmpty(newStatus))
                    catFind.Status = bool.Parse(newStatus);
                catFind.UpdateAt = DateTime.Now;
                catFind.UpdateBy = createdByUser;

                Console.WriteLine("User updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteCategory()
        {
            try
            {
            Console.WriteLine("------------------------------ Delete Category --------------------------------");
                Console.Write("Please Input ID You Want To Remove: ");
                int id = int.Parse(Console.ReadLine());

                CategoryManager catDel = CategoryLists.Find(u => u.Id == id);
                if (catDel != null)
                {
                    CategoryLists.Remove(catDel);
                    Console.WriteLine("Category Removed Successfully!");
                }
                else
                {
                    Console.WriteLine("ID was Not Found!");
                }
            }
            catch
            (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SearchCategory()
        {
            Console.WriteLine("-------------------Search-User------------------------");
        SearchP:
            Console.Write("Please Input Id or Name You Want To Search: ");
            string value = Console.ReadLine().Trim();

            List<CategoryManager> CategoryLists1 = new List<CategoryManager>();


            foreach (var cateFind in CategoryLists)
            {
                if (cateFind.Id.ToString().Contains(value) || cateFind.NameUnique.Contains(value))
                {
                    CategoryLists1.Add(cateFind);
                    Console.WriteLine("Category Search Successful!");
                    break;
                }
                else
                {
                    Console.WriteLine("No Category found with the given ID or Name.");
                    goto SearchP;
                }
            }
            Console.WriteLine("------------------------------ Category's Lists ------------------------------");
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            string columnHeader = string.Format("{0,-10}{1,-15}{2,-15}{3,-25}{4,-15}{5,-25}{6,-15}",
                                                "Id", "Name", "Status", "Create At", "Create By", "Update At", "Update By");
            Console.WriteLine(columnHeader);
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            foreach ( var category in CategoryLists1)
            {
                string dataRecord = string.Format("{0,-10}{1,-15}{2,-15}{3,-25}{4,-15}{5,-25}{6,-15}",
                                                  category.Id, category.NameUnique, category.Status, category.CreateAt,
                                                  category.CreateBy, category.UpdateAt, category.UpdateBy);
                Console.WriteLine(dataRecord);
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");

            }
        }
        public void CategoryMenu( string createdByUser)
        {
            try
            {
                CategoryManager category = new CategoryManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n————————— Category Management ——————————");
                    Console.WriteLine("1. Add Category");
                    Console.WriteLine("2. Display Category");
                    Console.WriteLine("3. Update Category");
                    Console.WriteLine("4. Search Category");
                    Console.WriteLine("5. Delete CAtegory");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            category.AddCategory(createdByUser);
                            break;
                        case 2:
                            category.ShowCategory();
                            break;
                        case 3:
                            category.UpdateCategoryById(createdByUser);
                            break;
                        case 4:
                            category.SearchCategory();
                            break;
                        case 5:
                            category.DeleteCategory();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
