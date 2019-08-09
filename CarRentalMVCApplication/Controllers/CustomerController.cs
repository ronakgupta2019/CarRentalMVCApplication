using CarRentalMVCApplication.Models;
using CarRentalMVCApplication.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace CarRentalMVCApplication.Controllers
{
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Customer
        public ActionResult Index(string search = "", string option = "")
        {
            //var cust = _context.Customers.ToList();
            //return View(cust);
            //var cust = _context.Customers.ToList();
            //return View(cust);
            if (search.Equals(""))
            {
                var users = _context.Users.ToList();
                var viewModel = new SearchBarViewModel
                {
                    Users = users
                };
                return View(viewModel);
            }
            else
            {
                if (option.Equals("Email"))
                {
                    var users = _context.Users.Where(c => c.Email.Equals(search)).ToList();
                    var viewModel = new SearchBarViewModel
                    {
                        Users = users
                    };
                    return View(viewModel);
                }

                else if (option.Equals("PhoneNumber"))
                {
                  // var searchMobile = Convert.ToDouble(search);
                    var users = _context.Users.Where(c => c.PhoneNumber.Equals(search)).ToList();
                    var viewModel = new SearchBarViewModel
                    {
                        Users = users
                    };
                    return View(viewModel);
                }

                else
                {
                    var users = _context.Users.Where(c => c.FirstName.Equals(search)).ToList();
                    var viewModel = new SearchBarViewModel
                    {
                        Users = users
                    };
                    return View(viewModel);
                }
            }
        }
        public ActionResult CustForm(ApplicationUser user)
        {
            var cars = _context.Cars.ToList();
            var viewModel = new NewCustomerViewModel
            {
                User = user,
                Cars = cars,
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Save(ApplicationUser user)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    User = user,
                    Cars = _context.Cars.ToList()
                };
                return View("CustForm", viewModel);
            }
            if (user.Id.Equals(0))
            {
                _context.Users.Add(user);
            }
            else
            {
                var userInDb = _context.Users.Single(c => c.Id == user.Id);
                userInDb.FirstName = user.FirstName;
                userInDb.LastName = user.LastName;
                userInDb.PhoneNumber = user.PhoneNumber;
                user.Email = user.Email;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        public ActionResult Delete(string id)
        {
            ApplicationUser user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CustAndCarForm(ApplicationUser user)
        {
            var cars = _context.Cars.ToList();
            //var cust = _context.Customers.Find(customer.Id);
            var viewModel = new NewCustomerViewModel()
            {
                User = user,
                Cars = cars,
            };
            return View(viewModel);

            }
        [Authorize]
        public ActionResult CustAndCarForm1(ApplicationUser user)
        {
            var cars = _context.Cars.ToList();
            var applicationUser= _context.Users.Find(User.Identity.GetUserId());
            var viewModel = new NewCustomerViewModel()
            {
                User = applicationUser,
                Cars = cars,
            };
            return View("CustAndCarForm",viewModel);

        }

    }
}