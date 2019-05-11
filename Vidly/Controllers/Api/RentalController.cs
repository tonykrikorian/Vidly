using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _dbContext;

        public RentalController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        //HTTP POST /api/NewRental/newRentalDTO
        public IHttpActionResult NewRental(NewRentalDTO newRental)
        {
            var customer = _dbContext.Customers
                .Single(x => x.Id == newRental.CustomerId);

            var movies = _dbContext.Movies
                .Where(x => newRental.MoviesIds
                .Contains(x.Id));

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("La pelicula no esta disponible");

                movie.NumberAvailable--;
                var rental = new Rental()
                {
                    Movie = movie,
                    Customer = customer,
                    DateRented = DateTime.Now
                };
                _dbContext.Rentals.Add(rental);
            }
            _dbContext.SaveChanges();
            return Ok();

        }
    }
}
