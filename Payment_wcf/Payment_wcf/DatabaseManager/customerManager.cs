using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Payment_wcf;

namespace Payment_wcf.DatabaseManager
{
    public class customerManager : BaseDatabaseManager, ISQL
    {
        public List<Customer> Select()
        {
            List<Customer> records = new List<Customer>();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "SELECT * FROM customer ORDER BY name";
            try
            {
                MySqlConnection connection = BaseDatabaseManager.connection;
                connection.Open();
                command.Connection = connection;
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Id = Convert.ToInt32(reader["id"].ToString());
                    customer.Age = Convert.ToInt32(reader["age"].ToString());
                    customer.City = reader["city"].ToString();
                    customer.Name = reader["name"].ToString();
                    records.Add(customer);
                }
            }
            catch (Exception ex)
            {
                Customer customer = new Customer();
                customer.Name = ex.Message;
                records.Add(customer);
            }
            finally
            {
                connection.Close();
            }

            return records;
        }
        public int Insert(Customer record)
        {
            Customer customer = new Customer();
            MySqlCommand command = new MySqlCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "INSERT INTO customer (name,age,city) VALUES (@name,@age,@city);";
            command.Parameters.Add(new MySqlParameter("@name", MySqlDbType.VarChar)).Value = customer.Name;
            command.Parameters.Add(new MySqlParameter("@age", MySqlDbType.Int32)).Value = customer.Age;
            command.Parameters.Add(new MySqlParameter("@city", MySqlDbType.VarChar)).Value = customer.City;
            int hozzaAdottSorokSzama = 0;
            command.Connection = BaseDatabaseManager.connection;
            try
            {
                command.Connection.Open();
                try
                {
                    hozzaAdottSorokSzama = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Nem tudta hozzáadni.");
                    Console.WriteLine(ex.Message);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            command.Parameters.Clear();
            return hozzaAdottSorokSzama;
        }

        public int Update(Customer record)
        {
            return 0;
        }

        public int Delete(int id)
        {
            return 0;
        }
    }
}