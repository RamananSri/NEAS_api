﻿using ModelLayer;
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
        public IHttpActionResult Get(int id)
        {
            // if found return ok(result) else return notfound() 

            return Ok();
        }

        public IHttpActionResult Get()
        {
            return Ok();
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
