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
        public static void Homepage()
        {

            string title = @"
             
                        

                             █████╗  ██████╗████████╗██╗██╗   ██╗██╗████████╗██╗   ██╗
                            ██╔══██╗██╔════╝╚══██╔══╝██║██║   ██║██║╚══██╔══╝╚██╗ ██╔╝
                            ███████║██║        ██║   ██║██║   ██║██║   ██║    ╚████╔╝ 
                            ██╔══██║██║        ██║   ██║╚██╗ ██╔╝██║   ██║     ╚██╔╝  
                            ██║  ██║╚██████╗   ██║   ██║ ╚████╔╝ ██║   ██║      ██║   
                            ╚═╝  ╚═╝ ╚═════╝   ╚═╝   ╚═╝  ╚═══╝  ╚═╝   ╚═╝      ╚═╝   
                                                            
                                                                                                 
                ";
            while (true)
            {
                Console.WriteLine(title, Color.Violet);


                Console.WriteLine(@"     
                                              Welcome to the C# App!");
                string home = @"
                                                 Enter 1 - 3:
                                                  1 = register
                                                  2 = login
                                                  3 = product
                                                  4 = exit
                                                                    ";
                Console.WriteLine(home, Color.Blue);
                int select = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (select)
                {
                    case 1:
                        register();
                        break;
                    case 2:
                        login();
                        break;
                    case 3:
                        product();
                        break;
                    case 4:
                        Console.WriteLine("Goodbye!");
                        return;
                        break;
                    default:
                        Console.WriteLine("Invalid number"); // pumapasok sa product kahit hindi login?
                        break;
                }
            }
        }
        public static void register()
        {
            string regis = @"
                                
                        ██████╗ ███████╗ ██████╗ ██╗███████╗████████╗███████╗██████╗ 
                        ██╔══██╗██╔════╝██╔════╝ ██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗
                        ██████╔╝█████╗  ██║  ███╗██║███████╗   ██║   █████╗  ██████╔╝
                        ██╔══██╗██╔══╝  ██║   ██║██║╚════██║   ██║   ██╔══╝  ██╔══██╗
                        ██║  ██║███████╗╚██████╔╝██║███████║   ██║   ███████╗██║  ██║
                        ╚═╝  ╚═╝╚══════╝ ╚═════╝ ╚═╝╚══════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝
                                                             
                                                                 ";
            if (!isLogin)
            {
                Console.WriteLine(regis, Color.Red);
                Console.WriteLine("enter username: ");
                string username = Console.ReadLine();
                Console.WriteLine("enter password: ");
                string password = Console.ReadLine();

                Connection conn = new Connection();
                conn.InsertUser(username, password);
                Console.Clear();
            }
            else
            {
                Console.WriteLine(@"                          You are already logged in.");
            }
        }




        public static void login()
        {
            string log = @" 
                                    ██╗      ██████╗  ██████╗ ██╗███╗   ██╗
                                    ██║     ██╔═══██╗██╔════╝ ██║████╗  ██║
                                    ██║     ██║   ██║██║  ███╗██║██╔██╗ ██║
                                    ██║     ██║   ██║██║   ██║██║██║╚██╗██║
                                    ███████╗╚██████╔╝╚██████╔╝██║██║ ╚████║
                                    ╚══════╝ ╚═════╝  ╚═════╝ ╚═╝╚═╝  ╚═══╝
                                       

                                                                 ";
            if (!isLogin)
            {
                Console.WriteLine(log, Color.Purple);

                Console.WriteLine("enter username: "); // ganto diba may coded ka diba makinig ka kupal ka first hanapin mo yung github d2
                string username = Console.ReadLine();
                Console.WriteLine("enter password: ");
                string password = Console.ReadLine();
                Connection conn = new Connection();
                conn.loginform(username, password);
                Console.WriteLine("Login Successful");
                isLogin = true;
                Console.Clear();
            }
            else
            {
                Console.WriteLine(@"                      You are already logged in.");
            }
        }



        public static void product()
        {
            string prod = @" 
                           
                            ██████╗ ██████╗  ██████╗ ██████╗ ██╗   ██╗ ██████╗████████╗
                            ██╔══██╗██╔══██╗██╔═══██╗██╔══██╗██║   ██║██╔════╝╚══██╔══╝
                            ██████╔╝██████╔╝██║   ██║██║  ██║██║   ██║██║        ██║   
                            ██╔═══╝ ██╔══██╗██║   ██║██║  ██║██║   ██║██║        ██║   
                            ██║     ██║  ██║╚██████╔╝██████╔╝╚██████╔╝╚██████╗   ██║   
                            ╚═╝     ╚═╝  ╚═╝ ╚═════╝ ╚═════╝  ╚═════╝  ╚═════╝   ╚═╝   
                                                           
   
                                                                                                             
                                 ";

            if (isLogin)
            {
                Console.WriteLine(prod, Color.Green);
                Console.WriteLine("Enter product name: ");
                string productName = Console.ReadLine();
                Console.WriteLine("Enter product description: ");
                string productDescription = Console.ReadLine();
                Console.WriteLine("Enter product price: ");
                int productPrice = Convert.ToInt32(Console.ReadLine());
                Connection conn = new Connection();
                conn.InsertProduct(productName, productPrice, productDescription);
                Console.Clear();
            }
            else
            {
                Console.WriteLine(@"                    You need to login first!");
            }
        }
    }
}