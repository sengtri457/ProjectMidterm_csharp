using MIdTerm_c_.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models.UserRoles
{
    internal class RoleManager
    {
        public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key to User
        public int RoleId { get; set; } // Foreign Key to Role
        public string RoleName { get; set; }
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }
        public bool Status { get; set; }

        private int number { get; set; }

         
        public static List<RoleManager> roleManagers = new List<RoleManager>();

        public void AddRole(string createdByUser)
        {

            Console.Write("Enter the number of Role: ");
            number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {

                RoleManager roleManager = new RoleManager();
                Console.WriteLine("Enter User Details:");
                Console.Write("ID: ");
                roleManager.Id = int.Parse(Console.ReadLine());
                Console.Write("RoleName: ");
                roleManager.RoleName = Console.ReadLine();
                Console.Write("Input Status= ");
                roleManager.Status = bool.Parse(Console.ReadLine());    
                roleManager.CreateAt = DateTime.Now;
                roleManager.UpdateAt = DateTime.Now;
                roleManager.UpdateBy=createdByUser;
                roleManager.CreateBy = createdByUser;   
                roleManagers.Add(roleManager);
                Console.WriteLine("User added successfully!");
            }

        }
        public void DisplayRoles()
        {
            try
            {
                if (roleManagers.Count == 0)
                {
                    Console.WriteLine("No Roles found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-Roles---------------------------");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-25}{4,-15}{5,-15}{6,-25}", "ID", "RoleName", "Status", "Create At", "CreateBy", "UpdateBy", "Update At");
                Console.WriteLine(columnheader);
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");

                foreach (var role in roleManagers)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-25}{4,-15}{5,-15}{6,-25}", role.Id, role.RoleName, role.Status, role.CreateAt, role.CreateBy, role.UpdateBy, role.UpdateAt);
                    Console.WriteLine(data);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void RolesManagement(string createdByUser)
        {
            try
            {
               RoleManager roleManager = new RoleManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n—————————User categories——————————");
                    Console.WriteLine("1. Add Roles");
                    Console.WriteLine("2. Display Roles");
                    Console.WriteLine("3. Update Roels");
                    Console.WriteLine("4. Search Roels");
                    Console.WriteLine("5. Delete Roles");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            roleManager.AddRole(createdByUser);
                            break;
                        case 2:
                            roleManager.DisplayRoles();
                            break;
                        case 3:
                            roleManager.UpdateRole(createdByUser);
                            break;
                        case 4:
                            roleManager.SearchRole();
                            break;
                        case 5:
                            roleManager.DeleteRoles();
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
        public void UpdateRole(string createdByUser)
        {
            try
            {
                Console.Write("Enter Role ID to update: ");
                int id = int.Parse(Console.ReadLine());

                RoleManager roleFind = roleManagers.Find(u => u.Id == id);
                if (roleFind == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                Console.WriteLine("Leave field blank to keep old value.");

                Console.Write("New RoleName: ");
                string newUsername = Console.ReadLine();
                if (!string.IsNullOrEmpty(newUsername))
                    roleFind.RoleName = newUsername;

                Console.Write("New Status: ");
                string newstatus = Console.ReadLine();
                if (!string.IsNullOrEmpty(newstatus))
                    roleFind.Status = bool.Parse(newstatus);
                if (!string.IsNullOrEmpty(newstatus))
                    roleFind.Status = bool.Parse(newstatus);
                roleFind.UpdateAt = DateTime.Now;
                roleFind.UpdateBy = createdByUser;

                Console.WriteLine("User updated successfully!");
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
                Console.WriteLine("------------------------Delete-Roles----------------------------------");
                Console.Write("Please Input ID You Want To Remove: ");
                int id = int.Parse(Console.ReadLine());

                RoleManager roleToDelete = roleManagers.Find(u => u.Id == id);
                if (roleToDelete != null)
                {
                    roleManagers.Remove(roleToDelete);
                    Console.WriteLine("Roles Removed Successfully!");
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

        public void SearchRole()
        {
            try
            {
                Console.WriteLine("-------------------Search-Roles------------------------");
            SearchP:
                Console.Write("Please Input Id or Name You Want To Search: ");
                string value = Console.ReadLine().Trim();

                List<RoleManager> rolelist = new List<RoleManager>();


                foreach (var roleFind in roleManagers)
                {
                    if (roleFind.Id.ToString().Contains(value) || roleFind.RoleName.Contains(value))
                    {
                        rolelist.Add(roleFind);
                        Console.WriteLine("Roles Search Successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No Roles found with the given ID or Name.");
                        goto SearchP;
                    }
                }
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-25}{4,-25}{5,-15}{6,-25}", "ID", "RoleName", "Status", "Create At", "CreateBy", "UpdateBy", "Update At");
                Console.WriteLine(columnheader);
                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");

                foreach (var role in rolelist)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-25}{4,-15}{5,-15}{6,-25}", role.Id, role.RoleName, role.Status, role.CreateAt, role.CreateBy, role.UpdateBy, role.UpdateAt);
                    Console.WriteLine(data);
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
