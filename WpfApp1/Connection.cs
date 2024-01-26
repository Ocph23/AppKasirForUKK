using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class DBConnection : IDisposable
    {
        public MySqlConnection Connection { get; set; }

        private static DBConnection _instance { get; set; }

        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }


        public bool IsConnect()
        {
            if (Connection == null)
            {
                string connectionString = $"Server=localhost; database=kasir; UID=root; password=Sonyalpha@77";
                Connection = new MySqlConnection(connectionString);
                Connection.Open();
            }
            return true;
        }

        public void Dispose()
        {
            Connection.Close();
        }
    }
}
