using CarRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentalMVCApplication.WebAPIs
{
    public class ServiceTypesController : ApiController
    {
        ApplicationDbContext _context;
        public ServiceTypesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [HttpGet]
        //Get /api/ServiceType
        public IEnumerable<ServiceType> FindServiceType()
        {
            return _context.ServiceTypes.ToList();
        }
        //Get /api/ServiceType/id
        public ServiceType GetServiceTypeById(int? id)
        {
            return _context.ServiceTypes.SingleOrDefault(c => c.Id == id);
        }
        [HttpPost]
        public IHttpActionResult CreateServiceType(ServiceType serviceType)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();
            _context.ServiceTypes.Add(serviceType);
            _context.SaveChanges();
            return Ok(serviceType);
        }
    }
}
