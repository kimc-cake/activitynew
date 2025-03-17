using MySql.Data.MySqlClient;
using System;

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
                Console.WriteLine("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }


        public bool loginform(string username, string userPassword)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM user WHERE username = @username AND password = @password";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", userPassword);
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


        public void InsertUser(string username, string password)
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
                        cmd.Parameters.AddWithValue("@userPassword", password); 
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

    }
}