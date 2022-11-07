using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Payment_wcf;

namespace Payment_wcf.DatabaseManager
{
    public class BaseDatabaseManager
    {
        protected BaseDatabaseManager()
        {

        }
        public static MySqlConnection connection
        {
            get
            {
                MySqlConnection connection = new MySqlConnection();
                string connectionString = "SERVER=localhost;" + "DATABASE=payment;" + "UID=root;" + "PASSWORD=;" + "SSL MODE=none;";
                connection.ConnectionString = connectionString;
                return connection;
            }
        }
    }
}