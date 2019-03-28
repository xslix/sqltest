using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tutorial.SqlConn;
using System.Data.Common;
using MySql.Data.MySqlClient;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppContext db = new AppContext())
            {
                // db.Database.EnsureCreated();
                var users = db.names.ToList();
                foreach (Person p in users)
                {
                    Console.WriteLine($"{p.Id} {p.Name}");
                }

                Person p1 = new Person { Name = "abc", Id = 123 };
                db.names.Add(p1);
                db.SaveChanges();
                users = db.names.ToList();
                foreach (Person p in users)
                {
                    Console.WriteLine($"{p.Id} {p.Name}");
                }
            }
            Console.Read();

            //// Получить объект Connection подключенный к DB.
            //MySqlConnection conn = DBUtils.GetDBConnection();
            //conn.Open();
            //try
            //{
            //    QueryEmployee(conn);
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine("Error: " + e);
            //    Console.WriteLine(e.StackTrace);
            //}
            //finally
            //{
            //    // Закрыть соединение.
            //    conn.Close();
            //    // Уничтожить объект, освободить ресурс.
            //    conn.Dispose();
            //}
            //Console.Read();
        }
    
        private static void QueryEmployee(MySqlConnection conn)
        {
            string sql = "Select * from names";

            // Создать объект Command.
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            using (DbDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        // Индекс (index) столбца Emp_ID в команде SQL.
                        int idIndex = reader.GetOrdinal("id"); // 0


                        long empId = Convert.ToInt64(reader.GetValue(0));

                        // Столбец Emp_No имеет index = 1.
                        string empNo = reader.GetString(1);
                        int empNameIndex = reader.GetOrdinal("name");// 2
                        string empName = reader.GetString(empNameIndex);

                        Console.WriteLine("--------------------");
                        Console.WriteLine("empIdIndex:" + idIndex);
                        Console.WriteLine("EmpId:" + empId);
                        Console.WriteLine("EmpNo:" + empNo);
                        Console.WriteLine("EmpName:" + empName);
                    }
                }
            }   

        }
    }

}