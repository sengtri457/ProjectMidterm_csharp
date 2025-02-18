using MIdTerm_c_.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models.Product
{
    internal class SupplierManager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Tel { get; set; }
        public string Address { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }

        private int number { get; set; }

        public static List<SupplierManager> supplier = new List<SupplierManager>();

        public void AddSupplier(string createdByUser)
        {
            Console.Write("Enter the number of Supplier: ");
            number = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------------");

            for (int i = 0; i < number; i++)
            {
                SupplierManager supplierManager = new SupplierManager();

                Console.Write("ID: ");
                supplierManager.Id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                supplierManager.Name = Console.ReadLine();
                Console.Write("Tell: ");
                supplierManager.Tel = long.Parse(Console.ReadLine());
                Console.Write("Address: ");
                supplierManager.Address = Console.ReadLine();

                supplierManager.CreateAt = DateTime.Now;
                supplierManager.UpdateAt = DateTime.Now;
                supplierManager.UpdateBy = createdByUser;
                supplierManager.CreateBy = createdByUser;

                supplier.Add(supplierManager);
                Console.WriteLine("Supplier added successfully!");
            }
        }
        public void DisplaySupplier()
        {
            try
            {
                if (supplier.Count == 0)
                {
                    Console.WriteLine("No supplier found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-Supplier---------------------------");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");

                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-35}{5,-15}{6,-15}{7,-15}", "ID", "Name", "Tel", "Address", "Create At", "CreateBy", "UpdateBy", "Update At");
                Console.WriteLine(columnheader);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");



                foreach (var supplier3 in supplier)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-35}{5,-15}{6,-15}{7,-15}", supplier3.Id, supplier3.Name, supplier3.Tel, supplier3.Address, supplier3.CreateAt, supplier3.CreateBy, supplier3.UpdateBy, supplier3.UpdateAt);
                    Console.WriteLine(data);
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void UpdateSupplier(string createdByUser)
        {
            try
            {
                Console.Write("Enter Supplier ID to update: ");
                this.Id = int.Parse(Console.ReadLine());

                SupplierManager roleFind = supplier.Find(u => u.Id == Id);
                if (roleFind == null)
                {
                    Console.WriteLine("Supplier not found.");
                    return;

                }
                Console.Write("New Id: ");
                string newId = (Console.ReadLine());
                if (!string.IsNullOrEmpty(newId))
                    roleFind.Id = int.Parse(newId);
                Console.Write("New Name: ");
                string newSuppliersName = Console.ReadLine();
                if (!string.IsNullOrEmpty(newSuppliersName))
                    roleFind.Name =(newSuppliersName);
                Console.Write("New Tell: ");
                string newTell = Console.ReadLine();
                if (!string.IsNullOrEmpty(newTell))
                    roleFind.Tel = long.Parse(newTell);
                Console.Write("New Address: ");
                string ad = Console.ReadLine(); 
                if (!string.IsNullOrEmpty(ad))
                    roleFind.Address = ad;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void SearchSupplier()
        {
            try
            {
                Console.WriteLine("-------------------Search-Supplier------------------------");
            SearchP:
                Console.Write("Please Input Id or Name You Want To Search: ");
                string value = Console.ReadLine().Trim();
                List<SupplierManager> suppliers = new List<SupplierManager>();

                foreach (var supplier3 in supplier)
                {
                    if (supplier3.Id.ToString().Contains(value))
                    {
                        suppliers.Add(supplier3);
                        Console.WriteLine("Supplier Search Successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No Supplier found with the given ID or Name.");
                        goto SearchP;
                    }
                }
                Console.WriteLine("Supplier Search Successful!");
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-35}{5,-15}{6,-15}{7,-15}", "ID", "Name", "Tel", "Address", "Create At", "CreateBy", "UpdateBy", "Update At");
                Console.WriteLine(columnheader);
                Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");



                foreach (var supplier3 in suppliers)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-35}{5,-15}{6,-15}{7,-15}", supplier3.Id, supplier3.Name, supplier3.Tel, supplier3.Address, supplier3.CreateAt, supplier3.CreateBy, supplier3.UpdateBy, supplier3.UpdateAt);
                    Console.WriteLine(data);
                    Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------------------------------------------");


                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DeleteSupplier()
        {
            try
            {
                Console.WriteLine("------------------------Delete-Supplier----------------------------------");
                Console.Write("Please Input ID You Want To Remove: ");
                int id = int.Parse(Console.ReadLine());

                SupplierManager supplierToDelete = supplier.Find(u => u.Id == id);
                if (supplierToDelete != null)
                {
                    supplier.Remove(supplierToDelete);
                    Console.WriteLine("Supplier Removed Successfully!");
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
        public void SupplierManagement(string createdByUser)
        {
            try
            {
                SupplierManager supplierManager = new SupplierManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n—————————Supplier categories——————————");
                    Console.WriteLine("1. Add Supplier");
                    Console.WriteLine("2. Display Supplier");
                    Console.WriteLine("3. Update Supplier");
                    Console.WriteLine("4. Search Supplier");
                    Console.WriteLine("5. Delete Supplier");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            supplierManager.AddSupplier(createdByUser);
                            break;
                        case 2:
                            supplierManager.DisplaySupplier();
                            break;
                        case 3:
                            supplierManager.UpdateSupplier(createdByUser);
                            break;
                        case 4:
                            supplierManager.SearchSupplier();
                            break;
                        case 5:
                            supplierManager.DeleteSupplier();
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
