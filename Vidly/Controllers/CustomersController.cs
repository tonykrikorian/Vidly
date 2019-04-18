using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList();
            return View(customers);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers
                .Include(c=>c.MembershipType)
                .SingleOrDefault(x => x.Id == id);

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                 MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CreateCustomer",viewModel);
        }
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };


            return View(viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCustomer(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var viewmodel = new CustomerFormViewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("createCustomer", viewmodel);
            }
           if(customer.Id == 0 )
                _context.Customers.Add(customer);
            else
            {
                var objInDb = _context.Customers.Single(x => x.Id == customer.Id);
                objInDb.Name = customer.Name;
                objInDb.BirthDate = customer.BirthDate;
                objInDb.MembershipTypeId = customer.MembershipTypeId;
                objInDb.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }

    }
}