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
    public class StoreController : ApiController
    {
        IStoreDAL storeDAL;

        public StoreController(IStoreDAL storeDAL)
        {
            this.storeDAL = storeDAL;
        }
        public StoreController()
        {
            storeDAL = new StoreDAL();
        }

        public Response Get(int id)
        {
            // if found return ok(result) else return notfound() 

            return null;
        }

        public Response Get()
        {
            return null;
        }

        public Response Put(Store obj)
        {
            try
            {
                storeDAL.update(obj);
                return new Response { Success = true, Message = "Store updated" };
            }
            catch (Exception e)
            {
                return new Response { Success = false, Message = e.Message };
            }
        }

        public Response Delete(int id)
        {
            return null;
        }

        public Response Post(Store obj)
        {
            return null;
        }
    }
}
