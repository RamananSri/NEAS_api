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
    public class DistrictDAL : IDistrictDAL
    {
        string connectionString;

        #region Constructor DB connectionString injection
        public DistrictDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public DistrictDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString;
        }
        #endregion

        public void Delete(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE "
                                 + "FROM District "
                                 + "WHERE ID = @id";

                    // Create SQL command with parameterized 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    int affectedLines = cmd.ExecuteNonQuery();

                    // Return custom exception if no rows were affected
                    if(affectedLines == 0)
                    {
                        throw new Exception("District with specified ID not found");
                    }
                }
            }
            catch (SqlException e)
            {
                // Log exception (Serilog?)
                throw new Exception("Internal error");
            }
        }

        public List<District> GetAll()
        {
            List<District> districts = new List<District>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT "
                                + "A.ID AS DistrictID,"
                                + "A.Name AS DistrictName,"
                                + "C.ID AS PrimeID,"
                                + "C.FirstName AS PrimeFirstName,"
                                + "C.LastName AS PrimeSecondName,"
                                + "B.ID AS SecondID,"
                                + "B.FirstName AS SecondFirstname,"
                                + "B.LastName AS SecondLastname,"
                                + "D.ID AS StoreID,"
                                + "D.Franchice AS StoreFranchice "
                             + "FROM District A "
                             + "JOIN Personnel X ON A.ID = X.DistrictID "
                             + "JOIN SalesPerson B ON X.PersonID = B.ID "
                             + "JOIN SalesPerson C ON A.PrimarySalesPerson = C.ID "
                             + "JOIN Store D ON D.DistrictID = A.ID";

                // Create SQL command with parameterized 
                SqlCommand cmd = new SqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // District
                        District d = new District();
                        d.ID = Convert.ToInt32(reader["DistrictID"].ToString());
                        d.Name = reader["DistrictName"].ToString();
                        d.PrimarySalesPerson = new SalesPerson();
                        d.PrimarySalesPerson.ID = Convert.ToInt32(reader["PrimeID"].ToString());
                        d.PrimarySalesPerson.FirstName = reader["PrimeFirstName"].ToString();
                        d.PrimarySalesPerson.LastName = reader["PrimeSecondName"].ToString();

                        // Secondary
                        SalesPerson sp = new SalesPerson(); 
                        sp.ID = Convert.ToInt32(reader["SecondID"].ToString());
                        sp.FirstName = reader["SecondFirstname"].ToString();
                        sp.LastName = reader["SecondLastname"].ToString();

                        // Store
                        Store s = new Store();
                        s.ID = Convert.ToInt32(reader["StoreID"].ToString());
                        s.Franchise = reader["StoreFranchice"].ToString();

                        // Add district if not in list and go to next iteration
						if (!districts.Any(x => x.ID == d.ID))
						{
							d.Personnel = new List<SalesPerson>();
							d.Personnel.Add(sp);
							d.Stores = new List<Store>();
							d.Stores.Add(s);
							districts.Add(d);
							continue;
						}

                        // Find index of exisisting district
                        int index = districts.FindIndex(x => x.ID == d.ID);

                        // Add secondary salesperson if not found on district
                        if (!districts.ElementAt(index).Personnel.Any(x => x.ID == sp.ID))
                        {
                            districts.ElementAt(index).Personnel.Add(sp);
                        }

                        // Add store if not found on district
                        if (!districts.ElementAt(index).Stores.Any(x => x.ID == s.ID))
                        {
                            districts.ElementAt(index).Stores.Add(s);
                        }
                    }
                }
         
            }
            return districts;
        }

        public District GetById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "";

                // Create SQL command with parameterized 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();


                while (reader.Read())
                {
                    

                    //person = new SalesPerson
                    //{
                    //    ID = Convert.ToInt32(reader["ID"].ToString()),
                    //    FirstName = reader["FirstName"].ToString(),
                    //    LastName = reader["LastName"].ToString()
                    //};

                    //personList.Add(person);

                }
            }



            //    District district = new District();

            //string query = "SELECT * "
            //             + "FROM SalesPerson "
            //             + "WHERE ID = ";

            //throw new NotImplementedException();
            return null;
        }

        public void Update(int id, District obj)
        {
            throw new NotImplementedException();
        }

        public void Create(District obj)
        {
            throw new NotImplementedException();
        }
    }
}
