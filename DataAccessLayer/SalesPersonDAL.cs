using DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using ModelLayer;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class SalesPersonDAL : ISalesPersonDAL
    {
        string connectionString;

        #region Constructor DB connectionString injection
        public SalesPersonDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString;   
        }
        public SalesPersonDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

        public void delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE "
                                 + "FROM SalesPerson "
                                 + "WHERE ID = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    int affectedLines = cmd.ExecuteNonQuery();

                    // Return custom exception if no rows were affected
                    if (affectedLines == 0)
                    {
                        throw new Exception("SalesPerson with specified ID not found");
                    }
                }
            }
            catch (SqlException e)
            {
                // Log exception (Serilog?)
                throw new Exception("Internal error");
            }
        }

        public List<SalesPerson> getAll()
        {
            List<SalesPerson> personList = new List<SalesPerson>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * "
                                 + "FROM SalesPerson";

                    conn.Open();
                    SqlCommand command = new SqlCommand(query, conn);
                    IDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        SalesPerson person = new SalesPerson
                        {
                            ID = Convert.ToInt32(reader["ID"].ToString()),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString()
                        };

                        personList.Add(person);
                    }
                }
                return personList;
            }
            catch (SqlException)
            {
                // Log exception
                return null;
            }
        }

        public SalesPerson getById(int id)
        {
            throw new NotImplementedException();
        }

        public void update(SalesPerson obj)
        {
            throw new NotImplementedException();
        }

        public void create(SalesPerson obj)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO SalesPerson(FirstName,LastName) "
                                 + "VALUES(@firstName,@lastName)";

                    // Create SQL command with parameterized 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@firstName", obj.FirstName);
                    cmd.Parameters.AddWithValue("@lastName", obj.LastName);
                    conn.Open();
                    int affectedLines = cmd.ExecuteNonQuery();

                    // Return custom exception if no rows were affected
                    if (affectedLines == 0)
                    {
                        throw new Exception("SalesPerson was not created");
                    }
                }
            }
            catch (SqlException e)
            {
                // Log exception (Serilog?)
                throw new Exception("Internal error");
            }
        }
    }
}
