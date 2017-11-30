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
    public class DistrictController : ApiController
    {
        IDistrictDAL districtDAL;

        // Constructors - dependency injection (use IoC containers instead)
        public DistrictController(IDistrictDAL districtDAL)
        {
            this.districtDAL = districtDAL;
        }
        public DistrictController()
        {
            districtDAL = new DistrictDAL();
        } 

        // Get single instance by ID
        public District Get(int id)
        {
            District district = districtDAL.GetById(id);
            return district; 
        }

        // Get all instances 
        public List<District> Get()
        {
            List<District> districts = districtDAL.GetAll();
            return districts;
        }


        public Response Put(int id, District obj)
        {
            //districtDAL.update(id, obj);
            return new Response { Success = false, Message = "not implemented" };
        }

        public Response Delete(int id)
        {
            try
            {
                districtDAL.Delete(id);
                return new Response { Success = true, Message = "District deleted" };
            }
            catch (Exception e)
            {
                return new Response { Success = false, Message = e.Message };
            }          
        }

        public Response Post(District obj)
        {
            //districtDAL.cre
            return new Response { Success = true, Message = "District created" };
        }

    }
}
