using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Tutorial.SqlConn
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "test1";
            string username = "root";
            string password = "g22143hp80";

            return DBMySQLUtils.GetDBConnection(host, port, database, username, password);
        }

    }

}