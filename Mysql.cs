using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using Colorful;
using Console = Colorful.Console;

namespace project1
{
    class Connection
    {
        protected string connectionString;
       
        public Connection()
        {
            string server = "localhost";
            string database = "activitynew";
            string uid = "root";
            string password = "";
            connectionString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
        }


        public void InsertProduct(string pName, int pPrice, string pDes)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO products (productName, productPrice, productDescription) VALUES (@productName, @productPrice, @productDescription)";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@productName", pName);
                        cmd.Parameters.AddWithValue("@productPrice", pPrice);
                        cmd.Parameters.AddWithValue("@productDescription", pDes);

                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("\nProduct is added successfully!", Color.Green);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public bool CheckProductLimit()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM products";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        return count < 14;
                    }
                }
            }catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                return false;
            }
        }


        public bool loginform(string username, string userPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM users WHERE username = @username AND userPassword = @userPassword";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@userPassword", userPassword);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;

            }
        }


        public void InsertUser(string username, string userPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO users (username, userPassword) VALUES (@username, @userPassword)"; //mali ito username	userPassword	dapat ganyan ang loob yan
                    using (MySqlCommand cmd = new MySqlCommand(query, connection)) // users kasi hindi user..................!!!!!!!!
                    {
                        cmd.Parameters.AddWithValue("@username", username); 
                        cmd.Parameters.AddWithValue("@userPassword", userPassword); 
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("\nRegistered successfully!", Color.Green);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}