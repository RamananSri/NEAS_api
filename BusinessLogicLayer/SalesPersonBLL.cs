using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer;

namespace BusinessLogicLayer
{
    public class SalesPersonBLL : ISalesPersonBLL
    {
        ISalesPersonDAL salesPersonDAL;

        public SalesPersonBLL(){
            this.salesPersonDAL = new SalesPersonDAL();
        }

        public SalesPersonBLL(ISalesPersonDAL salesPersonDAL){
            this.salesPersonDAL = salesPersonDAL;
        }

        public bool delete(int id){
            throw new NotImplementedException();
        }

        public List<SalesPerson> getAll(){
            return salesPersonDAL.getAll();     
        }

        public SalesPerson getById(int id){
            throw new NotImplementedException();
        }

        public bool update(int id, SalesPerson obj){
            throw new NotImplementedException();
        }
    }
}
