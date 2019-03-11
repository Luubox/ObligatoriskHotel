using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelModels;
using HotelRestService.DBUtil;

namespace HotelRestService.Controllers
{
    public class FacilitiesController : ApiController
    {
        ManageFacilities manageFacilities = new ManageFacilities();
        // GET: api/Facilities
        public List<Facilities> Get()
        {
            return manageFacilities.GetAllFacilities();
        }

        // GET: api/Facilities/5
        public Facilities Get(int id)
        {
            return manageFacilities.GetFacilitiesFromId(id);
        }

        // POST: api/Facilities
        public void Post([FromBody]Facilities value)
        {
            manageFacilities.CreateFacilities(value)
        }

        // PUT: api/Facilities/5
        public void Put(int id, [FromBody]Facilities value)
        {
            manageFacilities.UpdateFacilities(value, id);
        }

        // DELETE: api/Facilities/5
        public void Delete(int id)
        {
            manageFacilities.DeleteFacilities(id);
        }
    }
}
