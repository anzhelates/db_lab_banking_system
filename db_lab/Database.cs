using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace db_lab
{
    public  static class Database
    {
        private static string connectionString = "Host=localhost;Port=5432;Username=postgres;Password=Evkalipt0909;Database=Bank_System";
        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
    }
}
