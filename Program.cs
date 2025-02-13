using MIdTerm_c_.Models;
using MIdTerm_c_.Models.User;
using System;

namespace MIdTerm_c_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PosMenu menu = new PosMenu();
            UserManager userManager = new UserManager();

            // Call UserLogin and store the logged-in username
            
            string createdByUser = userManager.UserLogin();

            if (!string.IsNullOrEmpty(createdByUser))  // Check if login was successful
            {
                Console.WriteLine($"Welcome, {createdByUser}!");

                // Pass the logged-in username to the user management system\
                menu.PosSystemMenu(createdByUser);
            }
            else
            {
                Console.WriteLine("Login failed. Exiting program...");
            }

            Console.ReadKey();
        }
    }
}
