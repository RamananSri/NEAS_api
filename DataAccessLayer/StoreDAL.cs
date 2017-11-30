using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccessLayer
{
    public class StoreDAL : IStoreDAL
    {
        string connectionString;

        #region Constructor DB connectionString injection
        public StoreDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public StoreDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString;
        }
        #endregion

        public void delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Store> getAll()
        {
            throw new NotImplementedException();
        }

        public Store getById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(Store obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Store "
                                 + "SET Franchice = @franchise, "
                                 + "DistrictID = @dId "
                                 + "Where Store.ID = @id";

                    // Create parameterized command
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@franchise", obj.Franchise);
                    cmd.Parameters.AddWithValue("@dId", obj.DistrictID ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", obj.ID);
                    conn.Open();
                    int affected = cmd.ExecuteNonQuery();

                    // Return custom exception if no rows were affected
                    if (affected == 0)
                    {
                        throw new Exception("Store with specified ID not found");
                    }
                }
            }
            catch (Exception)
            {
                // Log exception (Serilog?)
                throw new Exception("Internal error");
            }            
        }
    }
}
