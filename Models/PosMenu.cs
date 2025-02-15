using MIdTerm_c_.Models.Product;
using MIdTerm_c_.Models.User;
using MIdTerm_c_.Models.UserRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIdTerm_c_.Models
{
    internal class PosMenu
    {
       public void PosSystemMenu(string createdByUser)
        {
            while (true)
            {
            try
            {
                    Console.WriteLine("--------------------------------POS-SYSTEM----------------------------------");
                    Console.WriteLine("1. User-Management");
                Console.WriteLine("2. UserRole-Management");
                Console.WriteLine("3. Role-Management");
                Console.WriteLine("4. View Product");
                Console.WriteLine("5. Exit");
                Console.Write("Please Select Option=  ");
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                       UserManager userManager = new UserManager();
                        userManager.UserManagement(createdByUser);
                        break;
                    case 2:
                            UserRoleManager userRoleManager = new UserRoleManager();
                            userRoleManager.UserRolesManagement(createdByUser);
                            break;
                    case 3:
                            RoleManager roleManager = new RoleManager();
                            roleManager.RolesManagement(createdByUser);
                        break;
                    case 4:
                        ProductManager productManager = new ProductManager();
                            productManager.ProductManagement(createdByUser);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
            }
    }
}
