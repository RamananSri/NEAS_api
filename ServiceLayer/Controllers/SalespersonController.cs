using DataAccessLayer;
using DataAccessLayer.Interfaces;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    public class SalespersonController : ApiController
    {
        ISalesPersonDAL salesPersonDAL;

        // Constructor dependency injection (use IoC containers instead)
        public SalespersonController(){
            salesPersonDAL = new SalesPersonDAL();
        }
        public SalespersonController(ISalesPersonDAL salesPersonDAL)
        {
            this.salesPersonDAL = salesPersonDAL;
        }

        public List<SalesPerson> Get()
        {
                List<SalesPerson> personlist = salesPersonDAL.getAll();
                return personlist;
        }

        public SalesPerson Get(int id){ 

            return null;
        }

        public Response Put(int id, SalesPerson obj){
            return null;
        }

        public Response Delete(int id){
            try
            {
                salesPersonDAL.delete(id);
                return new Response { Success = true, Message = "SalesPerson deleted" };
            }
            catch (Exception e)
            {
                return new Response { Success = false, Message = e.Message };
            }
        }

        public Response Post(SalesPerson obj){
            try
            {
                salesPersonDAL.create(obj);
                return new Response { Success = true, Message = "SalesPerson created" };
            }
            catch (Exception e)
            {
                return new Response {Success=false,Message=e.Message};
            }
        }
    }
}
