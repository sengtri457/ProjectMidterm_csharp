using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models.Sales
{
    internal class AddStockManager
    {
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public int Qty { get; set; }
        public double Price { get; set; }
        public double Amount { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        private int number { get; set; }

        public static List<AddStockManager> addStockManagers = new List<AddStockManager>();

        public void AddAddStock(string createdByUser)
        {
            Console.Write("Enter the number of Stock: ");
            number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                AddStockManager addStock = new AddStockManager();

                Console.WriteLine("Enter Stock Details:");
                Console.Write("ID: ");
                addStock.Id = int.Parse(Console.ReadLine());
                Console.Write("SupplierID: ");
                addStock.SupplierId = int.Parse(Console.ReadLine());
                Console.Write("Qty: ");
                addStock.Qty = int.Parse(Console.ReadLine());
                Console.Write("Price: ");
                addStock.Price = double.Parse(Console.ReadLine());
                addStock.CreateAt = DateTime.Now;
                addStock.UpdateAt = DateTime.Now;
                addStock.UpdateBy = createdByUser;
                addStock.CreateBy = createdByUser;
                addStockManagers.Add(addStock);
                Console.WriteLine("User added successfully!");
                addStock.Amount = addStock.Price * addStock.Qty;
            }
        }
        public void DisplayAddStock()
        {
            try
            {
                if (addStockManagers.Count == 0)
                {
                    Console.WriteLine("No Stock found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-AddStock---------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");

                string columnheader = string.Format("{0,-15}{1,-15}{2,-10}{3,-10}{4,-10}{5,-25}{6,-15}{7,-15}{8,-15}", "ID", "SupplierID", "Qty", "Price", "Amount", "Create At", "CreateBy", "UpdateBy", "Update At");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");



                foreach (var addstock3 in addStockManagers)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-10}{3,-10}{4,-10}{5,-25}{6,-15}{7,-15}{8,-15}", addstock3.Id, addstock3.SupplierId, addstock3.Qty, addstock3.Price, addstock3.Amount, addstock3.CreateAt, addstock3.CreateBy, addstock3.UpdateBy, addstock3.UpdateAt);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void UpdateAddStock(string createdByUser)
        {
            try
            {
                Console.Write("Enter StockID to update: ");
                this.Id = int.Parse(Console.ReadLine());
                AddStockManager roleFind = addStockManagers.Find(u => u.Id == Id);
                if (roleFind == null)
                {
                    Console.WriteLine("Sales not found.");
                    return;

                }
                Console.Write("New Id: ");
                string newId = (Console.ReadLine());
                if (!string.IsNullOrEmpty(newId))
                            roleFind.Id = int.Parse(newId);
                        Console.Write("New SupplierID: ");
                        string newSuppliersId = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newSuppliersId))
                            roleFind.SupplierId = int.Parse(newSuppliersId);
                        Console.Write("New Qty: ");
                        string newQty = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newQty))
                            roleFind.Qty = int.Parse(newQty);
                        Console.Write("New Price: ");
                        string newprice = Console.ReadLine();
                        if (!string.IsNullOrEmpty(newprice))
                    roleFind.Price = double.Parse(newprice);
                        double newPrice = double.Parse(newprice);
                        double newqty = double.Parse(newQty);
                        double newTotal = newPrice * newqty;
                        if (roleFind.Amount != 0)
                        {

                    roleFind.Amount = newTotal;
                        }
                roleFind.UpdateAt = DateTime.Now;
                roleFind.UpdateAt = DateTime.Now;
                roleFind.UpdateBy = createdByUser;
                        roleFind.CreateBy = createdByUser;
                        Console.WriteLine("Stock updated successfully!");
                        return;
                    
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SearchStock()
        {
            try
            {
                Console.WriteLine("-------------------Search-Stock------------------------");
            SearchP:
                Console.Write("Please Input Id To Search: ");
                string value = Console.ReadLine().Trim();
                List<AddStockManager> addStocks = new List<AddStockManager>();

                foreach (var addStock3 in addStockManagers)
                {
                    if (addStock3.Id.ToString().Contains(value))
                    {
                        addStocks.Add(addStock3);
                        Console.WriteLine("Stock Search Successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No Stock found with the given ID.");
                        goto SearchP;
                    }
                }
                Console.WriteLine("Stock Search Successful!");
                Console.WriteLine("------------------------DisPlay-AddStock---------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");

                string columnheader = string.Format("{0,-15}{1,-10}{2,-10}{3,-10}{4,-10}{5,-25}{6,-15}{7,-15}{8,-15}", "ID", "SupplierID", "Qty", "Price", "Amount", "Create At", "CreateBy", "UpdateBy", "Update At");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");



                foreach (var addstock3 in addStocks)
                {
                    string data = string.Format("{0,-15}{1,-10}{2,-10}{3,-10}{4,-10}{5,-25}{6,-15}{7,-15}{8,-15}", addstock3.Id, addstock3.SupplierId, addstock3.Qty, addstock3.Price, addstock3.Amount, addstock3.CreateAt, addstock3.CreateBy, addstock3.UpdateBy, addstock3.UpdateAt);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------------------");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteStock()
        {
            try
            {
                Console.WriteLine("------------------------Delete-AddStock----------------------------------");
                Console.Write("Please Input ID You Want To Remove: ");
                int id = int.Parse(Console.ReadLine());

                AddStockManager addStockToDelete = addStockManagers.Find(u => u.Id == id);
                if (addStockToDelete != null)
                {
                    addStockManagers.Remove(addStockToDelete);
                    Console.WriteLine("AddStock Removed Successfully!");
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
        public void AddStockManagement(string createdByUser)
        {
            try
            {
                AddStockManager addStockManager = new AddStockManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n—————————AddStock categories——————————");
                    Console.WriteLine("1. Add AddStock");
                    Console.WriteLine("2. Display AddStock");
                    Console.WriteLine("3. Update AddStock");
                    Console.WriteLine("4. Search AddStock");
                    Console.WriteLine("5. Delete AddStock");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            addStockManager.AddAddStock(createdByUser);
                            break;
                        case 2:
                            addStockManager.DisplayAddStock();
                            break;
                        case 3:
                            addStockManager.UpdateAddStock(createdByUser);
                            break;
                        case 4:
                            addStockManager.SearchStock();
                            break;
                        case 5:
                            addStockManager.DeleteStock();
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
