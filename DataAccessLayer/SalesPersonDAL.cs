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
        SqlConnection conn;

        public SalesPersonDAL()
        {
            string strcon = ConfigurationManager.ConnectionStrings["ConnectionStringLocal"].ConnectionString;
            conn = new SqlConnection(strcon);     
        }

        public bool delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<SalesPerson> getAll()
        {
            List<SalesPerson> personList = new List<SalesPerson>();

            string query = "SELECT * "
                         + "FROM SalesPerson";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            IDataReader reader = command.ExecuteReader();

            SalesPerson person;

            while (reader.Read())
            {
                person = new SalesPerson
                {
                    ID = Convert.ToInt32(reader["ID"].ToString()),
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString()
                };

                personList.Add(person);
            }
            conn.Close();
             
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
