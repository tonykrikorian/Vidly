using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Movies
        public ActionResult Index()
        {
            var movies = _context.Movies.Include(g=>g.Genre).ToList();
            return View(movies);
        }

        [Route("movies/edit/{id}")]
        public ActionResult EditMovie(int id)
        {
            //var movie = _context.Movies
            //    .Include(g=>g.Genre)
            //    .SingleOrDefault(x => x.Id == id);

            var movie = _context.Movies
                .SingleOrDefault(x => x.Id == id);

            var viewmodel = new MoviesFormViewModel
            {
                 Movie =  movie,
                 Genres = _context.Genres.ToList()
            };


            return View("CreateMovie", viewmodel);
        }
        public ActionResult Random()
        {
            var movie = new Movie(){ Id = 1,Name = "Shrek" };
            var customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "Customer1" },
                new Customer { Id = 2, Name = "Customer2" }
            };

            var viewModel = new RandomMovieViewModel
            {
                 Movie = movie,
                 Customers = customers
            };
            return View(viewModel);
            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page=1});
        }



        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrEmpty(sortBy))
        //        sortBy = "Name";

        //    return Content(string.Format("pageIndex={0}&sortyBy={1}",pageIndex,sortBy));
        //}
        [HttpGet]
        [Route("released/{year}/{month:regex(\\d{2})}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content($"{year}/{month}");
        }

        public ActionResult ByYearAndGenre(int year, int genre)
        {
            return Content($"{year}/{genre}");
        }

        [HttpGet]
        public ActionResult CreateMovie()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MoviesFormViewModel
            {
                 Genres = genres,
                 Movie = new Movie()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveMovie(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                var viewmodel = new MoviesFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("CreateMovie", viewmodel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);

            }
            else
            {
                var movieInDb = _context.Movies.Single(x => x.Id == movie.Id);
                movieInDb.Id = movie.Id;
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.DateAdded = DateTime.Now;
            }

            _context.SaveChanges();

            return RedirectToAction("Index","Movies");
        }


    }
}