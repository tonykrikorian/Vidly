using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _dbContex;

        public CustomersController()
        {
            _dbContex = new ApplicationDbContext();
        }
        // GET/ api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return _dbContex.Customers.ToList();
        }

        //GET / api/customers/1

        public Customer GetCustomer(int id)
        {
            var customer = _dbContex.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }

        // POST /api/customers
        [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbContex.Customers.Add(customer);
            _dbContex.SaveChanges();
            return customer;
        }

        //PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _dbContex.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            customerInDB.Name = customer.Name;
            customerInDB.BirthDate = customer.BirthDate;
            customerInDB.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
            customerInDB.MembershipTypeId = customer.MembershipTypeId;

            _dbContex.SaveChanges();
        }

        //DELETE api/customers/1
        [HttpDelete]
        public void DeleteCustomers(int id)
        {
            var customerInDB = _dbContex.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _dbContex.Customers.Remove(customerInDB);
            _dbContex.SaveChanges();
        }
    }
}
