using CarRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CarRentalMVCApplication.Controllers
{
    public class ServiceTypeController : Controller
    {
        ApplicationDbContext _context;

        public ServiceTypeController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: ServiceType
        public ActionResult Index()
        {
            //var servType = _context.ServiceTypes.ToList();
            //return View(servType);
            IEnumerable<ServiceType> serviceTypes = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:53179/api/");
                var responseTask = client.GetAsync("ServiceTypes");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<ServiceType>>();
                    readTask.Wait();
                    serviceTypes = readTask.Result;
                }
                else
                {
                    serviceTypes = Enumerable.Empty<ServiceType>();
                    ModelState.AddModelError(string.Empty, "Server Error");
                }
            }
            return View(serviceTypes);
        }
        [Authorize(Roles = Roles.Admin)]
        public ActionResult AddService()
        {

           
            return View(new ServiceType());
        }
        public ActionResult Save(ServiceType serviceType)
        {
            //if (!ModelState.IsValid)
            //{

            //    return View("AddService",serviceType);
            //}
            //if (serviceType.Id == 0)
            //    _context.ServiceTypes.Add(serviceType);
            //else
            //{
            //    var serviceInDb = _context.ServiceTypes.Single(c => c.Id == serviceType.Id);
            //    serviceInDb.Name = serviceType.Name;
            //}
            //_context.SaveChanges();
            //return RedirectToAction("Index", "ServiceType");
            if (!ModelState.IsValid)
            {

                return View("AddService", serviceType);
            }
            HttpResponseMessage response = GlobalVariables
                .WebApiClient.PostAsJsonAsync("ServiceTypes", serviceType).Result;
            TempData["SuccessMessage"] = "Saved Successfully";
            return RedirectToAction("Index", "ServiceType");
        }
    }
}