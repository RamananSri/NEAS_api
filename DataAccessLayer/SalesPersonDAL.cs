using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class SalesPersonDAL : ISalesPersonDAL
    {
        string connectionString;

        // Constructors - connection string injection
        public SalesPersonDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString;   
        }
        public SalesPersonDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }



        public bool delete(int id)
        {
            int affectedLines;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE "
                                 + "FROM Store "
                                 + "WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    affectedLines = cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                // log Exception
                throw;
            };
                       

            if(affectedLines == 1)
            {
                return true;
            }

            return false;
                
        }

        public List<SalesPerson> getAll()
        {
            List<SalesPerson> personList = new List<SalesPerson>();

            //string query = "SELECT * "
            //             + "FROM SalesPerson";
            //conn.Open();
            //SqlCommand command = new SqlCommand(query, conn);
            //IDataReader reader = command.ExecuteReader();

            //SalesPerson person;

            //while (reader.Read())
            //{
            //    person = new SalesPerson
            //    {
            //        ID = Convert.ToInt32(reader["ID"].ToString()),
            //        FirstName = reader["FirstName"].ToString(),
            //        LastName = reader["LastName"].ToString()
            //    };

            //    personList.Add(person);
            //}
            //conn.Close();
             
            return personList;
        }

        public SalesPerson getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(int id, SalesPerson obj)
        {
            throw new NotImplementedException();
        }
    }
}
