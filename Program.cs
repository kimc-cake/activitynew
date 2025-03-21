using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace project1
{
    class Home
    {
        static bool isLogin = false;
        static string title = @"
                             █████╗  ██████╗████████╗██╗██╗   ██╗██╗████████╗██╗   ██╗
                            ██╔══██╗██╔════╝╚══██╔══╝██║██║   ██║██║╚══██╔══╝╚██╗ ██╔╝
                            ███████║██║        ██║   ██║██║   ██║██║   ██║    ╚████╔╝ 
                            ██╔══██║██║        ██║   ██║╚██╗ ██╔╝██║   ██║     ╚██╔╝  
                            ██║  ██║╚██████╗   ██║   ██║ ╚████╔╝ ██║   ██║      ██║   
                            ╚═╝  ╚═╝ ╚═════╝   ╚═╝   ╚═╝  ╚═══╝  ╚═╝   ╚═╝      ╚═╝";
        


        public static void Homepage()
        {
            while (true)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(title, Color.Violet);
                Console.WriteLine(@"                                            
                                             Welcome to the C# App!");

                string home = @"
                                                 Enter 1 - 4:
                                                  1 = Register
                                                  2 = Login
                                                  3 = Add Product
                                                  4 = Exit";

                if (isLogin)
                {
                    home = @"
                                                 Enter 1 - 5:
                                                  1 = Register
                                                  2 = Login
                                                  3 = Add Product
                                                  4 = Logout
                                                  5 = Exit";
                }

                Console.WriteLine(home, Color.Blue);

                // Display login status
                Console.WriteLine(isLogin ? @"
                                             You are already logged in!" : @"
                                You are not logged in. Please log in to continue.",
                                  isLogin ? Color.Green : Color.Red);

                if (!int.TryParse(Console.ReadLine(), out int select))
                {
                    Console.WriteLine("Invalid input. Please enter a number.", Color.Red);
                    Thread.Sleep(2000); 
                    continue;
                }

                switch (select)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        Login();
                        break;
                    case 3:
                        AddProduct();
                        break;
                    case 4:
                        if (isLogin)
                        {
                            Logout();
                        }
                        else
                        {
                            Console.WriteLine("Exiting...", Color.Yellow);
                            Thread.Sleep(2000); // Wait for 2 seconds
                            return;
                        }
                        break;
                    case 5:
                        if (isLogin)
                        {
                            Console.WriteLine("Goodbye!", Color.Yellow);
                            Thread.Sleep(2000); 
                            return;
                        }
                        Console.WriteLine("Invalid option.", Color.Red);
                        Thread.Sleep(2000); 
                        break;
                    default:
                        Console.WriteLine("Invalid number", Color.Red);
                        Thread.Sleep(2000); 
                        break;
                }
            }
        }

        public static void Register()
        {
            if (!isLogin)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(@"
                        ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗ 
                        ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗
                        ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝
                        ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗
                        ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║
                        ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝", Color.Red);

                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();

                Connection conn = new Connection();
                conn.InsertUser(username, password);
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        public static void Login()
        {
            if (!isLogin)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(@"
                                    ██╗      ██████╗  ██████╗ ██╗███╗   ██╗
                                    ██║     ██╔═══██╗██╔════╝ ██║████╗  ██║
                                    ██║     ██║   ██║██║  ███╗██║██╔██╗ ██║
                                    ██║     ██║   ██║██║   ██║██║██║╚██╗██║
                                    ███████╗╚██████╔╝╚██████╔╝██║██║ ╚████║
                                    ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝╚═╝  ╚═══╝", Color.Purple);

                Console.WriteLine("Enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Enter password: ");
                string password = Console.ReadLine();

                Connection conn = new Connection();
                if (conn.loginform(username, password))
                {
                    Console.WriteLine("\nLogin Successful!", Color.Green);
                    isLogin = true;
                }
                else
                {
                    Console.WriteLine("\nLogin Failed. You need to register first!", Color.Red);
                }
                Thread.Sleep(2000); 
                Console.Clear();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(title, Color.Violet);

                Console.WriteLine("You are already logged in!", Color.Green);
                Thread.Sleep(2000); 
            }
        }

        public static void Logout()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@"
                           
                                ██╗      ██████╗  ██████╗  ██████╗ ██╗   ██╗████████╗
                                ██║     ██╔═══██╗██╔════╝ ██╔═══██╗██║   ██║╚══██╔══╝
                                ██║     ██║   ██║██║  ███╗██║   ██║██║   ██║   ██║   
                                ██║     ██║   ██║██║   ██║██║   ██║██║   ██║   ██║   
                                ███████╗╚██████╔╝╚██████╔╝╚██████╔╝╚██████╔╝   ██║   
                                ╚══════╝ ╚═════╝  ╚═════╝  ╚═════╝  ╚═════╝    ╚═╝   ", Color.Green);
            Console.WriteLine(@"
                                                 Logging out...", Color.Yellow);
            Thread.Sleep(2000); 
            isLogin = false;
            Console.WriteLine(@"
                                     You have been logged out successfully.", Color.Green);
            Thread.Sleep(2000); 
        }

        public static void AddProduct()
        {
            if (!isLogin)
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(title, Color.Violet);
                Console.WriteLine(@"                                            
                                             Welcome to the C# App!");
                string home = @"
                                                 Enter 1 - 4:
                                                  1 = Register
                                                  2 = Login
                                                  3 = Add Product
                                                  4 = Exit";
                Console.WriteLine(home, Color.Blue);
                Console.WriteLine("You need to login first!", Color.Red);
                Thread.Sleep(2000);
                return;
            }

            Console.Clear();
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(@"
                            ██████╗ ██████╗  ██████╗ ██████╗ ██╗   ██╗ ██████╗████████╗
                            ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██║   ██║██╔════╝╚══██╔══╝
                            ██████╔╝██████╔╝██║   ██║██║  ██║██║   ██║██║        ██║   
                            ██╔═══╝ ██╔══██╗██║   ██║██║  ██║██║   ██║██║        ██║   
                            ██║     ██║  ██║╚██████╔╝██████╔╝╚██████╔╝╚██████╗   ██║   
                            ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝  ╚═════╝   ╚═╝", Color.Green);

            Console.WriteLine("Enter product name: ");
            string productName = Console.ReadLine();
            Console.WriteLine("Enter product description: ");
            string productDescription = Console.ReadLine();
            Console.WriteLine("Enter product price: ");
            if (!int.TryParse(Console.ReadLine(), out int productPrice))
            {
                Console.WriteLine("Invalid price. Please enter a valid number.", Color.Red);
                Thread.Sleep(2000);
                return;
            }

            Connection conn = new Connection();
            conn.InsertProduct(productName, productPrice, productDescription);
            Thread.Sleep(2000); 
            Console.Clear();
        }
    }
}
