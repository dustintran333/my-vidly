using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel.Administration;
using System.Web;
using System.Web.Mvc;
using my_vidly.Models;
using my_vidly.ViewModels;

namespace my_vidly.Controllers
{
	public class MoviesController : Controller
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext(); //db object
		}

		public ActionResult Index()
		{
			//var movies = _context.Movies.Include(c => c.Genre).ToList();
			if (User.IsInRole(RoleName.CanManageMovies))
				return View("List");
			return View("ReadOnlyList");
		}

		public ActionResult Details(int id)
		{
			var ret = _context.Movies.Include(c => c.Genre).FirstOrDefault(x => x.Id == id);

			if (ret == null)
				return Content("No Movie found.");

			return View(ret);
		}

		[Authorize(Roles = RoleName.CanManageMovies)]
		public ActionResult New()
		{
			var viewModel = new MovieFormViewModel()
			{
				Movie = new Movie()
				{
					Id = 0,
					NumberInStock = 1,
					ReleaseDate = DateTime.Today
				},
				Genres = _context.Genres.ToList()
			};
				
			return View("MovieForm",viewModel);
		}
		public ActionResult Edit(int id)
		{
			var movie = _context.Movies.SingleOrDefault(i => i.Id == id);

			if (movie == null) return HttpNotFound();

			var viewModel = new MovieFormViewModel()
			{
				Movie = movie,
				Genres = _context.Genres.ToList()
			};

			return View("MovieForm", viewModel);
		}
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(Movie movie)
		{
			//Server site validation
			if (!ModelState.IsValid)
			{
				var viewModel = new MovieFormViewModel()
				{
					Movie = movie,
					Genres = _context.Genres.ToList()
				};
				return View("MovieForm", viewModel);
			}
			if (movie.Id == 0)
			{
				movie.DateAdded = DateTime.Now;
				movie.NumberAvailable = movie.NumberInStock;

				_context.Movies.Add(movie);
			}
			else
			{
				var movieInDb = _context.Movies.SingleOrDefault(i => i.Id == movie.Id);

				movieInDb.Name = movie.Name;
				movieInDb.ReleaseDate = movie.ReleaseDate;
				movieInDb.GenreId = movie.GenreId;
				movieInDb.NumberInStock = movie.NumberInStock;
			}
			_context.SaveChanges();

			return RedirectToAction("Index","Movies");
		}

		// GET: Movies
		public ActionResult Random()
		{
			var movie = new Movie{ Name = "Shrek!"};
			var customers = new List<Customer>
			{
				new Customer{Name = "Customer 1"},
				new Customer{Name = "Customer 2"}
			};
			var viewModel = new RandomMovieViewModel()
			{
				Movie = movie,
				Customers = customers
				
			};
			return View(viewModel);
		}

		[Route("movies/released/{year}/{month:range(1,12)}")]
		public ActionResult ByReleaseDate(int year, int month)
		{
			return Content($"year {year} month {month}");
		}

	}
}