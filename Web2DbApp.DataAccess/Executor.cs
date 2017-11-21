using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Web2DbApp.DataAccess
{
    public class Executor
    {
        /// <summary>
        /// the connectionString To our database
        /// </summary>
        private const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TestDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        /// <summary>
        /// Used to call the stored procedure
        /// </summary>
        /// <param name="procedurName">The name of the stored procedure</param>
        /// <param name="sqlQuery">The statement you want executed </param>
        public void Execute(string procedureName, string sqlQuery)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(procedureName, conn))
                {
                    //set the command type to StoredProcedure
                    command.CommandType = CommandType.StoredProcedure;
                    //give the parameter in the database our value sqlQuery
                    command.Parameters.AddWithValue("@smart", sqlQuery);
                    //open the connection
                    conn.Open();
                    //run our command
                    command.ExecuteNonQuery();
                    //close the connection since we are done
                    conn.Close();
                }
                
            }
        }


        /// <summary>
        /// Used to fetch data from the DB.
        /// </summary>
        /// <param name="sqlQuery">The statement you want executed </param>
        /// <returns></returns>
        public DataSet Execute(string sqlQuery)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    connection.Open();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet set = new DataSet();
                        adapter.Fill(set);
                        connection.Close();
                        return set;
                    }
                }

            }
        }
    }
}
