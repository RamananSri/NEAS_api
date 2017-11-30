using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataAccessLayer;

namespace Testing
{
    [TestClass]
    public class DALtest
    {

        [TestMethod]
        public void TestMethod1()
        {
            SalesPersonDAL salesPersonDAL = new SalesPersonDAL(); 

            //SalesPerson = salesPersonDAL.getById
        }
    }
}
