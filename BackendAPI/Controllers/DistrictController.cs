using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BackendAPI.Controllers
{
    public class DistrictController : ApiController
    {
        public List<string> Get()
        {
            List<string> list = new List<string>();
            list.Add("hej");

            return list;
        }

    }
}
