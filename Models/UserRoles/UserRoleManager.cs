using MIdTerm_c_.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models.UserRoles
{
    internal class UserRoleManager
    {

        public int Id { get; set; } // Primary Key
        public int UserId { get; set; } // Foreign Key to User
        public int RoleId { get; set; } // Foreign Key to Role
        public DateTime CreateAt { get; set; }
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; }
        public string UpdateBy { get; set; }

        private int number { get; set; }

        public static List<UserRoleManager> UserRoles = new List<UserRoleManager>();
        

        public void AddUserRoles()
        {
            Console.Write("Enter the number of Users: ");
            number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                UserRoleManager userRoleManager = new UserRoleManager();

                Console.WriteLine("Enter User Details:");
                Console.Write("ID: ");
                userRoleManager.Id = int.Parse(Console.ReadLine());
                Console.Write("UserID: ");
                userRoleManager.UserId =int.Parse( Console.ReadLine());
                Console.Write("Input UserRoleID= ");
                userRoleManager.RoleId= int.Parse( Console.ReadLine()); 
                userRoleManager.CreateAt = DateTime.Now;

                userRoleManager.UpdateAt = DateTime.Now;

                UserRoles.Add(userRoleManager);
                Console.WriteLine("User added successfully!");
            }
        }


        public void DisplayUsersRoles()
        {
            try
            {
                if (UserRoles.Count == 0)
                {
                    Console.WriteLine("No users found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-User---------------------------");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-25}", "ID", "UserID", "RoleID", "Create At", "CreateBy", "UpdateBy", "Update At");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");

                foreach (var user in UserRoles)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-25}", user.Id, user.UserId, user.RoleId, user.CreateAt, user.CreateBy, user.UpdateBy, user.UpdateAt);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void UpdateUserRoles( )
        {
            try
            {
                Console.Write("Enter User ID to update: ");
                this.Id = int.Parse(Console.ReadLine());

               foreach (var userFind in UserRoles)
                {
                    if (userFind.Id == this.Id)
                    {
                        Console.WriteLine("User found!");
                        Console.WriteLine("Enter User Details:");
                        Console.Write("UserID: ");
                        userFind.UserId = int.Parse(Console.ReadLine());
                        Console.Write("Input RoleID: ");
                        userFind.RoleId = int.Parse(Console.ReadLine());
                        userFind.UpdateAt = DateTime.Now;
                        Console.WriteLine("User updated successfully!");
                        return;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void SearchUserRoles()
        {
            try
            {
                Console.WriteLine("-------------------Search-User------------------------");
            SearchP:
                Console.Write("Please Input Id or Name You Want To Search: ");
                string value = Console.ReadLine().Trim();
                List<UserRoleManager> userRoleList = new List<UserRoleManager>();

                foreach (var userFind in UserRoles)
                {
                    if (userFind.Id.ToString().Contains(value))
                    {
                        userRoleList.Add(userFind);
                        Console.WriteLine("User Search Successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No usersRoles found with the given ID or Name.");
                        goto SearchP;
                    }
                }
                Console.WriteLine("UserRoles Search Successful!");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-25}", "ID", "UserID", "RoleID", "Create At", "CreateBy", "UpdateBy", "Update At");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                foreach (var userFind in userRoleList)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-25}", userFind.Id, userFind.UserId, userFind.RoleId, userFind.CreateAt, userFind.CreateBy, userFind.UpdateBy, userFind.UpdateAt);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public void DeleteUserRoles()
        {
            try
            {
                Console.WriteLine("------------------------Delete-User----------------------------------");
                Console.Write("Please Input ID You Want To Remove: ");
                int id = int.Parse(Console.ReadLine());

                UserRoleManager userToDelete = UserRoles.Find(u => u.Id == id);
                if (userToDelete != null)
                {
                    UserRoles.Remove(userToDelete);
                    Console.WriteLine("UserRoles Removed Successfully!");
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



        public void UserRolesManagement( )
        {
            try
            {
                UserRoleManager userRoles = new UserRoleManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n—————————User categories——————————");
                    Console.WriteLine("1. Add UserRoles");
                    Console.WriteLine("2. Display UsersRoles");
                    Console.WriteLine("3. Update UsersRoels");
                    Console.WriteLine("4. Search UsersRoels");
                    Console.WriteLine("5. Delete UserRoles");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            userRoles.AddUserRoles();
                            break;
                        case 2:
                            userRoles.DisplayUsersRoles();
                            break;
                        case 3:
                            userRoles.UpdateUserRoles();
                            break;
                        case 4:
                            userRoles.SearchUserRoles();
                            break;
                        case 5:
                            userRoles.DeleteUserRoles();
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
