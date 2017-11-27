using BusinessLogicLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    public class SalespersonController : ApiController
    {
        ISalesPersonBLL salesPersonBLL;

        public SalespersonController(){
            salesPersonBLL = new SalesPersonBLL();
        }
        public SalespersonController(ISalesPersonBLL salesPersonBLL)
        {
            this.salesPersonBLL = salesPersonBLL;
        }



        public IHttpActionResult Get(){

            List<SalesPerson> personList;

            try
            {
                personList = salesPersonBLL.getAll();
            }
            catch (Exception)
            {

                throw;
            }
            
            return Ok(personList);
        }

        public IHttpActionResult Get(int id){
            // if found return ok(result) else return notfound() 

            return Ok();
        }

        public IHttpActionResult Put(int id, SalesPerson obj){
            return Ok();
        }

        public IHttpActionResult Delete(int id){
            return Ok();
        }

        public IHttpActionResult Post(SalesPerson obj){
            return Ok();
        }
    }
}
