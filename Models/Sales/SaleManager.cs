using MIdTerm_c_.Models.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models
{
    internal class SaleManager
    {

        public int Id { get; set; } 
        public DateTime DateTime { get; set; }
        

        public int UserId { get; set; } 
        public double TotalAmount   { get; set; }
        public int numberOfUsers { get; set; }



        public static List<SaleManager> saleManages = new List<SaleManager>();
        public void AddSale()
        {

            Console.Write("Enter the number of Role: ");
            numberOfUsers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfUsers; i++)
            {
                SaleManager saleManager = new SaleManager();
                Console.WriteLine("Input Sale Details:");
                Console.Write("Input ID: ");
                saleManager.Id = int.Parse(Console.ReadLine());
                Console.Write("Input Sale Date: ");
                saleManager.DateTime = DateTime.Parse(Console.ReadLine());  
                Console.Write("Input User ID= ");
                saleManager.UserId=int.Parse(Console.ReadLine());
                Console.Write("Input TotalAmount: ");
                saleManager.TotalAmount = int.Parse(Console.ReadLine());
                saleManages.Add(saleManager);   

                Console.WriteLine("User added successfully!");
            }

        }
        public void DisplaySalae()
        {
            try
            {
                if (saleManages.Count == 0)
                {
                    Console.WriteLine("No Sale found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-Sales---------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-35}{2,-15}{3,-15}", "ID", "SaleDate", "UserId", "TotalAmount");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

                foreach (var role in saleManages)
                {
                    string data = string.Format("{0,-15}{1,-35}{2,-15}{3,-15}", role.Id, role.DateTime, role.UserId, role.TotalAmount);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void DeleteRoles()
        {
            try
            {
                Console.WriteLine("------------------------Delete-Sales----------------------------------");
                Console.Write("Please Input ID You Want To Remove: ");
                int id = int.Parse(Console.ReadLine());

                SaleManager sales = saleManages.Find(u => u.Id == id);
                if (sales != null)
                {
                    saleManages.Remove(sales);
                    Console.WriteLine("Sales Removed Successfully!");
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
        public void SearchSales()
        {
            try
            {
                Console.WriteLine("-------------------Search-Sales------------------------");
            SearchP:
                Console.Write("Please Input Id or Name You Want To Search: ");
                string value = Console.ReadLine().Trim();

                List<SaleManager> rolelist = new List<SaleManager>();


                foreach (var roleFind in saleManages)
                {
                    if (roleFind.Id.ToString().Contains(value))
                    {
                        rolelist.Add(roleFind);
                        Console.WriteLine("Sales Search Successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No Saleas found with the given ID or Name.");
                        goto SearchP;
                    }
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-Sales---------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-35}{2,-15}{3,-15}", "ID", "SaleDate", "UserId", "TotalAmount");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

                foreach (var role in rolelist)
                {
                    string data = string.Format("{0,-15}{1,-35}{2,-15}{3,-15}", role.Id, role.DateTime, role.UserId, role.TotalAmount);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void UpdateSales()
        {
            try
            {
                Console.Write("Enter Sales ID to update: ");
                int id = int.Parse(Console.ReadLine());

                SaleManager roleFind = saleManages.Find(u => u.Id == id);
                if (roleFind == null)
                {
                    Console.WriteLine("Sales not found.");
                    return;
                }

                Console.WriteLine("Leave field blank to keep old value.");

                Console.Write("New SalesDate: ");
                string newDate =(Console.ReadLine());
                if (!string.IsNullOrEmpty(newDate))
                    roleFind.DateTime = DateTime.Parse(newDate);
                Console.Write("New UserID: ");
                string newUserId = Console.ReadLine();
                if (!string.IsNullOrEmpty(newUserId))
                    roleFind.UserId = int.Parse(newUserId);
                Console.Write("New TotalAmount: ");
                string newAmount = Console.ReadLine();
                if (!string.IsNullOrEmpty(newAmount))
                    roleFind.TotalAmount = double.Parse(newAmount);

                Console.WriteLine("User updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public void SaleManagement()
        {
            try
            {
                SaleManager saleManager = new SaleManager();    
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n—————————User categories——————————");
                    Console.WriteLine("1. Add Sales");
                    Console.WriteLine("2. Display Sales");
                    Console.WriteLine("3. Update Sales");
                    Console.WriteLine("4. Search Sales");
                    Console.WriteLine("5. Delete Sales");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            saleManager.AddSale();
                            break;
                        case 2:
                            saleManager.DisplaySalae();
                            break;
                        case 3:
                            saleManager.UpdateSales();
                            break;
                        case 4:
                            saleManager.SearchSales();

                            break;
                        case 5:
                            saleManager.DeleteRoles();
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
