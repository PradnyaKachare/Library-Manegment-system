using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Library_Manegment_system.Configuration
{
    class DBConnect
    {       
         const string connectionString = "server=HP\\SQLEXPRESS;Database=Library;Integrated Security = True";

            public static SqlConnection GetConnection()
            {
                try
                {
                    SqlConnection con = new SqlConnection(connectionString);
                    return con;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                return null;
            }

        
    }
}
