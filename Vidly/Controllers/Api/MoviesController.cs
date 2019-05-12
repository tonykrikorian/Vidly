using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTO;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext dbContext;

        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }

        //GET /api/movies/
        public IHttpActionResult GetMovies(string query=null)
        {

            var moviesQuery = dbContext.Movies
                .Include(x => x.Genre);

            if (!string.IsNullOrEmpty(query))
                moviesQuery = moviesQuery.Where(x => x.Name.Contains(query));

            var moviesDTO = moviesQuery
                .ToList().Select(Mapper.Map<Movie,MovieDTO>);

            return Ok(moviesDTO);
        }

        //GET /api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(x => x.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie,MovieDTO>(movie));
        }

        //POST /api/movies
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("No se ha podido crear el recurso");

            var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
            movie.DateAdded = DateTime.Now;
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            movieDTO.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);


        }

        //PUT /api/movies/1
        [HttpPut]
        public void UpdateMovie(int id,MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDB = dbContext.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Mapper.Map<MovieDTO, Movie>(movieDTO,movieInDB);
            dbContext.SaveChanges();
        }

        // Delete /api/movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDB = dbContext.Movies.SingleOrDefault(x => x.Id == id);

            if (movieInDB == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            dbContext.Movies.Remove(movieInDB);
            dbContext.SaveChanges();
        }
    }
}
