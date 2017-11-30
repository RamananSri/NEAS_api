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

        public HttpResponseMessage Get(){

            return Request.CreateResponse(HttpStatusCode.InternalServerError);
            //try
            //{
            //    List<SalesPerson> personList = salesPersonDAL.getAll();

            //    return personList;
            //}
            //catch (Exception e)
            //{
            //    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            //}
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
