using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BowlingBE.Controllers
{
    public class BowlingController : ApiController
    {
        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok(value);
        }
    }
}
