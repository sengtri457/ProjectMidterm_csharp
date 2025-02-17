using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models.Sales
{
    internal class SalesDetailManager
    {

        public int Id { get; set; }


        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public  int QtyIStock { get; set; }
        public double Price { get; set; }

        public double Total { get; set; }
        public int numberOfUsers { get; set; }


        public static List<SalesDetailManager> salesDetailManagers = new List<SalesDetailManager>();
        public void AddSaleDetail()
        {
        SalesDetailManager salesDetail = new SalesDetailManager();
            
            Console.Write("Enter the number of SaleDetail: ");
            numberOfUsers = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfUsers; i++)
            {
                Console.WriteLine("Input Sale Details:");
                Console.Write("Input ID: ");
                salesDetail.Id = int.Parse(Console.ReadLine());
                Console.Write("Input SaleId: ");
                salesDetail.SaleId=int.Parse(Console.ReadLine());
                Console.Write("Input ProductId= ");
                salesDetail.ProductId = int.Parse(Console.ReadLine());
                Console.Write("Input QtyInStock: ");
                salesDetail.QtyIStock = int.Parse(Console.ReadLine());
                Console.Write("Input Price: ");
                salesDetail.Price = int.Parse(  Console.ReadLine());
                salesDetailManagers.Add(salesDetail);
                Console.WriteLine("Sales added successfully!");
                salesDetail.Total= salesDetail.Price+salesDetail.QtyIStock;
            }


        }
        public void DisplaySalae()
        {
            try
            {
                if (salesDetailManagers.Count == 0)
                {
                    Console.WriteLine("No Sale found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-SalesDetail---------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", "ID", "SaleID", "ProductId", "Qty","Price","Total");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

                foreach (var role in salesDetailManagers)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", role.Id, role.SaleId, role.ProductId, role.QtyIStock,role.Price,role
                        .Total);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void UpdateSalesDetail()
        {
            try
            {
                Console.Write("Enter Sales ID to update: ");
                int id = int.Parse(Console.ReadLine());

                SalesDetailManager roleFind = salesDetailManagers.Find(u => u.Id == id);
                if (roleFind == null)
                {
                    Console.WriteLine("Sales not found.");
                    return;
                }

                Console.WriteLine("Leave field blank to keep old value.");

                Console.Write("New SalesId: ");
                string newId = (Console.ReadLine());
                if (!string.IsNullOrEmpty(newId))
                    roleFind.SaleId = int.Parse(newId);
                Console.Write("New ProductID: ");
                string newProductId = Console.ReadLine();
                if (!string.IsNullOrEmpty(newProductId))
                    roleFind.ProductId = int.Parse(newProductId);
                Console.Write("New Qty: ");
                string newQty = Console.ReadLine();
                if (!string.IsNullOrEmpty(newQty))
                    roleFind.QtyIStock = int.Parse(newQty);
                Console.Write("New Price: ");
                string newprice = Console.ReadLine();
                if (!string.IsNullOrEmpty(newprice))
                    roleFind.Price = double.Parse(newprice);
                double newPrice = double.Parse(newprice);
                double newqty = double.Parse(newQty);
                double newTotal = newPrice + newqty;
           if(roleFind.Total !=0)
                {

                    roleFind.Total = newTotal;
                }


                Console.WriteLine("User updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void DeleteSaleDetail()
        {
            try
            {
                Console.WriteLine("------------------------Delete-Sales----------------------------------");
                Console.Write("Please Input ID You Want To Remove: ");
                int id = int.Parse(Console.ReadLine());

                SalesDetailManager sales = salesDetailManagers.Find(u => u.Id == id);
                if (sales != null)
                {
                    salesDetailManagers.Remove(sales);
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
                Console.WriteLine("-------------------Search-SalesDetail------------------------");
            SearchP:
                Console.Write("Please Input Id or Name You Want To Search: ");
                string value = Console.ReadLine().Trim();

                List<SalesDetailManager> rolelist = new List<SalesDetailManager>();


                foreach (var roleFind in salesDetailManagers)
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
                Console.WriteLine("------------------------DisPlay-SalesDetail---------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", "ID", "SaleID", "ProductId", "Qty", "Price", "Total");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

                foreach (var role in rolelist)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}", role.Id, role.SaleId, role.ProductId, role.QtyIStock, role.Price, role
                        .Total);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void SaleDetailManagement()
        {
            try
            {
                SalesDetailManager salesdeatil = new SalesDetailManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n—————————SalesDetail-categories——————————");
                    Console.WriteLine("1. Add SalesDetail");
                    Console.WriteLine("2. Display SalesDetail");
                    Console.WriteLine("3. Update SalesDetail");
                    Console.WriteLine("4. Search SalesDetail");
                    Console.WriteLine("5. Delete SalesDetail");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            salesdeatil.AddSaleDetail();
                            break;
                        case 2:
                            salesdeatil.DisplaySalae();
                            break;
                        case 3:
                            salesdeatil.UpdateSalesDetail();
                            break;
                        case 4:
                            salesdeatil.SearchSales();
                            break;
                        case 5:
                            salesdeatil.DeleteSaleDetail();
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
