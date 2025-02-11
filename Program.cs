using MIdTerm_c_.Models.User;
using System;

namespace MIdTerm_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserManager userManager = new UserManager();

            // Call UserLogin and store the logged-in username
            string createdByUser = userManager.UserLogin();

            if (!string.IsNullOrEmpty(createdByUser))  // Check if login was successful
            {
                Console.WriteLine($"Welcome, {createdByUser}!");

                // Now when adding a user, pass the logged-in username as 'createdByUser'
                userManager.UserManagement(createdByUser);
            }
            else
            {
                Console.WriteLine("Login failed. Exiting program...");
            }

            Console.ReadKey();
        }
    }
}
