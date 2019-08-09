using CarRentalMVCApplication.Models;
using CarRentalMVCApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarRentalMVCApplication.Controllers
{
    public class CarController : Controller
    {
        ApplicationDbContext _context;
        public CarController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Car
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CarForm(ApplicationUser user)
        {
            var viewModel = new SingleCarViewModel
            {
                User = user
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(SingleCarViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {

                return View("CarForm", viewModel);
            }
            viewModel.Car.UserId = viewModel.User.Id;
            var user = _context.Users.Find(viewModel.User.Id);
            var car = viewModel.Car;
            _context.Cars.Add(car);
            _context.SaveChanges();
            return RedirectToAction("CustAndCarForm", "Customer", user);
        }
        public ActionResult EditForm(Car car)
        {
            //  return View(car);
            var user = _context.Users.Find(car.UserId);
            var viewModel = new SingleCarViewModel
            {
                Car = car,
                User = user
            };

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(Car car)
        {

            var carInDb = _context.Cars.Find(car.Id);
            var user = _context.Users.Find(carInDb.UserId);
            carInDb.VIN = car.VIN;
            carInDb.Make = car.Make;
            carInDb.Model = car.Model;
            carInDb.Color = car.Color;
            carInDb.Year = car.Year;
            carInDb.Miles = car.Miles;
            _context.SaveChanges();

            return RedirectToAction("CustAndCarForm", "Customer", user);
        }

        public ActionResult Delete(int id)
        {
            Car car = _context.Cars.Find(id);
            var user = _context.Users.Find(car.UserId);
            _context.Cars.Remove(car);
            _context.SaveChanges();
            return RedirectToAction("CustAndCarForm", "Customer", user);
        }
        public ActionResult AddNewServices(Car car)
        {
            var user = _context.Users.Where(c => c.Id.Equals(car.UserId)).SingleOrDefault();
            List<Service> service = _context.Services.Where(c => c.CarId == car.Id).ToList();
            List<ServiceType> serviceType = _context.ServiceTypes.ToList();

            var viewModel = new CarAndServiceViewModel()
            {
                User = user,
                Car = car,
                Services = service,
                ServiceType = serviceType
            };

            return View(viewModel);
        }

        public ActionResult AddServices(CarAndServiceViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                viewModel.Service.DateAdded = DateTime.Today;
                viewModel.Service.CarId = viewModel.Car.Id;
                var car = _context.Cars.Find(viewModel.Car.Id);

                _context.Services.Add(viewModel.Service);
                _context.SaveChanges();

                return RedirectToAction("AddNewServices", "Car", car);
            }
            viewModel.Car = _context.Cars.Find(viewModel.Car.Id);
            viewModel.Services = _context.Services.Where(c => c.CarId == viewModel.Car.Id).OrderByDescending(c => c.DateAdded).ToList();
            viewModel.ServiceType = _context.ServiceTypes.ToList();
            return View("AddNewServices", viewModel);

            //if(!ModelState.IsValid)
            //{

            //    viewModel.ServiceType = _context.ServiceTypes.ToList();
            //    viewModel.Services = _context.Services.ToList();

            //    return View("AddNewServices", viewModel);
            //}
            //viewModel.Service.DateAdded = DateTime.Today;
            //viewModel.Service.CarId = viewModel.Car.Id;
            //var car = _context.Cars.Find(viewModel.Car.Id);

            //_context.Services.Add(viewModel.Service);
            //_context.SaveChanges();

            //return RedirectToAction("AddNewServices", "Car", car);
        }
    

        public ActionResult Delete1(int id)
        {
            Service service = _context.Services.Find(id);
            var car = _context.Cars.Find(service.CarId);
            _context.Services.Remove(service);
            _context.SaveChanges();
            return RedirectToAction("AddNewServices", "Car", car);
        }

    }
}