using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Cors;
using BowlingBE.Models;
using BowlingBE.Repository;

namespace BowlingBE.Controllers
{
    public class BowlingController : ApiController
    {
        [HttpPost]
        public IHttpActionResult Post(BowlingFrames frames)
        {
            return Ok(BowlingRepository.CountScore(frames));
        }

    }
}
