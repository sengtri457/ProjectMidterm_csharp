using MIdTerm_c_.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models.Product
{
    internal class ProductManager
    {

        public string Name { get; set; }
        public string Barcode { get; set; }
        public int Id { get; set; }
      
        public double  SellPrice { get; set; }
        public int QtyInstock { get; set; }
        public string Photo { get; set; }
        public int Category { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public string UpdateBy { get; set; }


        public List<ProductManager> productManagers = new List<ProductManager>();
        private int number { get; set; }
        public void AddProduct(string createdByUser)
        {
            Console.Write("Enter the number of Product: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                ProductManager productManager = new ProductManager();

                Console.WriteLine("Enter User Details:");

                while (true)
                {
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    if (productManagers.Any(u => u.Id == id))
                    {
                        Console.WriteLine("ID already exists. Please enter a unique ID.");
                    }
                    else
                    {
                        productManager.Id = id;
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    if (productManagers.Any(u => u.Name == name))
                    {
                        Console.WriteLine("Username already exists. Please enter a unique username.");
                    }
                    else
                    {
                        productManager.Name = name;
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Barcode: ");
                    string code = Console.ReadLine();
                    if (productManagers.Any(u => u.Barcode == code))
                    {
                        Console.WriteLine("Barcode already exists. Please enter a unique username.");
                    }
                    else
                    {
                        productManager.Barcode = code;
                        break;
                    }
                }

                Console.Write("SellPrice: ");
                productManager.SellPrice = double.Parse(Console.ReadLine());

                Console.Write("QtyInStock: ");
                productManager.QtyInstock = int.Parse(Console.ReadLine());

                Console.Write("Photo: ");
                productManager.Photo =Console.ReadLine();
                Console.Write("Input categoryId: ");
                productManager.Category= int.Parse(Console.ReadLine()); 

                productManager.CreateAt = DateTime.Now;
                productManager.UpdateAt = DateTime.Now;
                productManager.CreateBy = createdByUser;
                productManager.UpdateBy = createdByUser;

                productManagers.Add(productManager);
                Console.WriteLine("Product added successfully!");
            }
        }
        public void DisplayProduct()
        {
            try
            {
                if (productManagers.Count == 0)
                {
                    Console.WriteLine("No users found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-Product---------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-25}{7,-15}{8,-25}{9,-25}{10,-25}", "ID", "Name", "Barcode", "SellPrice", "Qty", "Photo", "CategoryId ", "Created At", "Create By", "Updated At", "Updated By");
                Console.WriteLine(columnheader);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");

                foreach (var user in productManagers)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-25}{7,-15}{8,-25}{9,-25}{10,-25}", user.Id, user.Name, user.Barcode, user.SellPrice, user.QtyInstock, user.Photo,user.Category, user.CreateAt, user.CreateBy, user.UpdateAt, user.UpdateBy);
                    Console.WriteLine(data);
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void ProductManagement(string createdByUser)
        {
            try
            {
                ProductManager pro = new ProductManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n—————————User categories——————————");
                    Console.WriteLine("1. Add Product");
                    Console.WriteLine("2. Display Product");
                    Console.WriteLine("3. Update Product");
                    Console.WriteLine("4. Search Product");
                    Console.WriteLine("5. Delete Product");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            pro.AddProduct(createdByUser);
                            break;
                        case 2:
                            pro.DisplayProduct();
                            break;
                      /*  case 3:
                            roleManager.UpdateRole(createdByUser);
                            break;
                        case 4:
                            roleManager.SearchRole();
                            break;
                        case 5:
                            roleManager.DeleteRoles();
                            break;*/
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
