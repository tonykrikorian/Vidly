using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DTO;
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
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQuery = _dbContex.Customers
                           .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));

            var customerDtos = customersQuery
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(customerDtos);

        }

        //GET / api/customers/1

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _dbContex.Customers.SingleOrDefault(x => x.Id == id);

            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();

            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }

        // POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDTO);

            _dbContex.Customers.Add(customer);
            _dbContex.SaveChanges();
            customerDTO.Id = customer.Id;
            //return customerDTO;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDTO);
        }

        //PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDTO customerDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDB = _dbContex.Customers.SingleOrDefault(x => x.Id == id);

            if (customerInDB == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map<CustomerDTO, Customer>(customerDTO, customerInDB);
            //customerInDB.Name = customer.Name;
            //customerInDB.BirthDate = customer.BirthDate;
            //customerInDB.IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
            //customerInDB.MembershipTypeId = customer.MembershipTypeId;

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
