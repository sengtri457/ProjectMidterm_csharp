using System;
using System.Collections.Generic;
using System.Linq;

namespace MIdTerm_c_.Models.User
{
    internal class UserManager
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public string CreateBy { get; set; }
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public string UpdateBy { get; set; }

        private int number { get; set; }

        public UserManager(string userName, string password, int id, string gender, string email, bool status, string createBy, string updateBy, int number)
        {
            UserName = userName;
            Password = password;
            Id = id;
            Gender = gender;
            Email = email;
            Status = status;
            CreateBy = createBy;
            UpdateBy = updateBy;
            this.number = number;
        }

        public UserManager()
        {

        }
        public static List<UserManager> Users = new List<UserManager>()
        {
            {new UserManager("admin","123",1,"M","engtri",true,"","",1) },
             {new UserManager("tri","1234",2,"M","engtri",false,"","",1) }
        };

        public string UserLogin()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("-----------------------------POS-SYSTEM---------------------------------");
                    Console.Write("Please Input Username: ");
                    string inputUsername = Console.ReadLine();

                    Console.Write("Please Input Password: ");
                    string inputPassword = Console.ReadLine();

                    var user = FindUser(inputUsername, inputPassword);

                    if (user != null)
                    {
                        Console.WriteLine("Login successful!");
                        return user.UserName; //Return the logged-in username
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password. Please try again.");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        private UserManager FindUser(string inputUsername, string inputPassword)
        {
            foreach (var user in Users)
            {
                if (user.UserName == inputUsername && user.Password == inputPassword && user.Status == true)
                {
                    return user;
                }
            }
            return null;
        }


        public void AddUser(string createdByUser)
        {
            Console.Write("Enter the number of Users: ");
            int number = int.Parse(Console.ReadLine());

            for (int i = 0; i < number; i++)
            {
                UserManager userManager = new UserManager();

                Console.WriteLine("Enter User Details:");

                while (true)
                {
                    Console.Write("ID: ");
                    int id = int.Parse(Console.ReadLine());
                    if (Users.Any(u => u.Id == id))
                    {
                        Console.WriteLine("ID already exists. Please enter a unique ID.");
                    }
                    else
                    {
                        userManager.Id = id;
                        break;
                    }
                }

                while (true)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    if (Users.Any(u => u.UserName == username))
                    {
                        Console.WriteLine("Username already exists. Please enter a unique username.");
                    }
                    else
                    {
                        userManager.UserName = username;
                        break;
                    }
                }

                Console.Write("Gender: ");
                userManager.Gender = Console.ReadLine();

                Console.Write("Password: ");
                userManager.Password = Console.ReadLine();

                Console.Write("Email: ");
                userManager.Email = Console.ReadLine();

                Console.Write("Status (true/false): ");
                userManager.Status = bool.Parse(Console.ReadLine());

                userManager.CreateAt = DateTime.Now;
                userManager.UpdateAt = DateTime.Now;
                userManager.CreateBy = createdByUser;  
                userManager.UpdateBy = createdByUser;

                Users.Add(userManager);
                Console.WriteLine("User added successfully!");
            }
        }


        public void DisplayUsers()
        {
            try {
                if (Users.Count == 0)
                {
                    Console.WriteLine("No users found.");
                    return;
                }

                Console.WriteLine();
                Console.WriteLine("------------------------DisPlay-User---------------------------");
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-25}{7,-15}{8,-25}{9,-25}", "ID", "Username", "Password", "Gender", "Email", "Status", "Created At", "Create By", "Updated At", "Updated By");
                Console.WriteLine(columnheader);
                Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");

                foreach (var user in Users)
                {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-25}{7,-15}{8,-25}{9,-25}", user.Id, user.UserName, user.Password, user.Gender, user.Email, user.Status, user.CreateAt, user.CreateBy, user.UpdateAt, user.UpdateBy);
                    Console.WriteLine(data);
                    Console.WriteLine("--------------------------------------------------------------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void UpdateUser(string createdByUser)
        {
            try {
                Console.Write("Enter User ID to update: ");
                int id = int.Parse(Console.ReadLine());

                UserManager userFind = Users.Find(u => u.Id == id);
                if (userFind == null)
                {
                    Console.WriteLine("User not found.");
                    return;
                }

                Console.WriteLine("Leave field blank to keep old value.");

                Console.Write("New Username: ");
                string newUsername = Console.ReadLine();
                if (!string.IsNullOrEmpty(newUsername))
                    userFind.UserName = newUsername;

                Console.Write("New Gender: ");
                string newGender = Console.ReadLine();
                if (!string.IsNullOrEmpty(newGender))
                    userFind.Gender = newGender;

                Console.Write("New Password: ");
                string newPassword = Console.ReadLine();
                if (!string.IsNullOrEmpty(newPassword))
                    userFind.Password = newPassword;

                Console.Write("New Email: ");
                string newEmail = Console.ReadLine();
                if (!string.IsNullOrEmpty(newEmail))
                    userFind.Email = newEmail;

                Console.Write("New Status (true/false): ");
                string newStatus = Console.ReadLine();
                if (!string.IsNullOrEmpty(newStatus))
                    userFind.Status = bool.Parse(newStatus);
                userFind.UpdateAt = DateTime.Now;
                userFind.UpdateBy = createdByUser;

                Console.WriteLine("User updated successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void DeleteUser()
        {
            try {
                Console.WriteLine("------------------------Delete-User----------------------------------");
                Console.Write("Please Input ID You Want To Remove: ");
                int id = int.Parse(Console.ReadLine());

                UserManager userToDelete = Users.Find(u => u.Id == id);
                if (userToDelete != null)
                {
                    Users.Remove(userToDelete);
                    Console.WriteLine("User Removed Successfully!");
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

        public void SearchUser()
        {
            try {
                Console.WriteLine("-------------------Search-User------------------------");
            SearchP:
                Console.Write("Please Input Id or Name You Want To Search: ");
                string value = Console.ReadLine().Trim();

                List<UserManager>userList = new List<UserManager>();


                foreach(var userFind in Users)
                {
                    if (userFind.Id.ToString().Contains(value) || userFind.UserName.Contains(value))
                    {
                        userList.Add(userFind);
                        Console.WriteLine("User Search Successful!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No users found with the given ID or Name.");
                        goto SearchP;
                    }
                }
                Console.WriteLine("User Search Successful!");
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                string columnheader = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}{8,-15}", "ID", "Username", "Password", "Gender", "Email", "Status", "Created At", "Create By", "Updated At", "Updated By");
                Console.WriteLine(columnheader);
                Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                foreach (var userFind in userList) {
                    string data = string.Format("{0,-15}{1,-15}{2,-15}{3,-15}{4,-15}{5,-15}{6,-15}{7,-15}{8,-15}", userFind.Id, userFind.UserName, userFind.Password, userFind.Gender, userFind.Email, userFind.Status, userFind.CreateAt, userFind.CreateBy, userFind.UpdateAt, userFind.UpdateBy);
                    Console.WriteLine(data);
                    Console.WriteLine("-----------------------------------------------------------------------------------------------------------");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void UserManagement( string createdByUser)
        {
            try {
                UserManager posManager = new UserManager();
                bool exit = false;

                while (!exit)
                {
                    Console.WriteLine("\n—————————User categories——————————");
                    Console.WriteLine("1. Add User");
                    Console.WriteLine("2. Display Users");
                    Console.WriteLine("3. Update Users");
                    Console.WriteLine("4. Search Users");
                    Console.WriteLine("5. Delete User");
                    Console.WriteLine("6. Back");
                    Console.Write("Select an option: ");
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            posManager.AddUser(createdByUser); 
                            break;
                        case 2:
                            posManager.DisplayUsers();
                            break;
                        case 3:
                            posManager.UpdateUser(createdByUser); 
                            break;
                        case 4:
                            posManager.SearchUser();
                            break;
                        case 5:
                            posManager.DeleteUser();
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