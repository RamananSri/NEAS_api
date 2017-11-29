using BusinessLogicLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    public class DistrictController : ApiController
    {
        IDistrictBLL districtBLL;

        // Constructor dependency injection (use IoC containers instead)
        public DistrictController(IDistrictBLL districtBLL)
        {
            this.districtBLL = districtBLL;
        }
        public DistrictController()
        {
            districtBLL = new DistrictBLL();
        } 

        // Get single instance by ID
        public HttpResponseMessage Get(int id)
        {
            District district = districtBLL.getById(id);
            return Request.CreateResponse(HttpStatusCode.OK, district);
        }

        // Get all instances 
        public HttpResponseMessage Get()
        {
            List<District> districts = districtBLL.getAll();
            return Request.CreateResponse(HttpStatusCode.OK,districts);        
        }

        public IHttpActionResult Put(int id, District obj)
        {
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            return Ok();
        }

        public IHttpActionResult Post(District obj)
        {
            return Ok();
        }

    }
}
