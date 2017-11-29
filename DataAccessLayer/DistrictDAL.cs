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
        SqlConnection connection;

        // Constructor dependency injection for DB connectionString
        public DistrictDAL(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }
        public DistrictDAL()
        {
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString;
            connection = new SqlConnection(strcon);
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<District> getAll()
        {
            List<District> districts = new List<District>();

            string query = "";

            connection.Open();

            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();



        }

        public District getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(int id, District obj)
        {
            throw new NotImplementedException();
        }
    }
}
