using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LABSHEET08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ADONET Example 

            // step 1 : connecting to the Microsoft SQL
            string connectionString = "Data Source=PRADEEPREDDY\\SQLEXPRESS;Initial Catalog=MOVIE1_DB;Integrated Security=True;";
            SqlConnection conn = new SqlConnection(connectionString);

            // step 2: Opening the connection 
            conn.Open();

            try
            {
                // step 3: insert / update / delete commands 

                string Query1 = "CREATE TABLE MOVIE_INFO (MOVIE_ID INT PRIMARY KEY, MOVIE_NAME VARCHAR(30), RATING FLOAT)";
                SqlCommand cmd1 = new SqlCommand(Query1, conn);
                cmd1.ExecuteNonQuery();

                string Query2 = "INSERT INTO MOVIE_INFO VALUES (1001, 'BHAHUBALI', 4.9),(1002, 'RRR', 4.8)";
                SqlCommand cmd2 = new SqlCommand(Query2, conn);
                cmd2.ExecuteNonQuery();

                // step 4: Data Reader -> select command to view data table
                string Query3 = "SELECT * FROM MOVIE_INFO";
                SqlCommand cmd3 = new SqlCommand(Query3, conn);
                SqlDataReader reader = cmd3.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2]);
                }

                // print : Sucess 
               Console.WriteLine("Exceution Sucesss");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // step 5: close the connection
            conn.Close();


        }
    }
}
