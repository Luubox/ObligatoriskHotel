using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelRestService.Controllers
{
    public class HotelController : ApiController
    {
        // GET: api/Hotel
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Hotel/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Hotel
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Hotel/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
        }
    }
}
