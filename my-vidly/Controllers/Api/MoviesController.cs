using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using my_vidly.Dtos;
using my_vidly.Models;

namespace my_vidly.Controllers.Api
{
	public class MoviesController : ApiController
	{
		private ApplicationDbContext _context;

		public MoviesController()
		{
			_context = new ApplicationDbContext();
		}

		//Get all

		public IHttpActionResult GetMovies(string query = null)
		{
			var moviesQuery = _context.Movies
				.Include(m => m.Genre)
				.Where(m => m.NumberAvailable > 0);

			if (!String.IsNullOrWhiteSpace(query)) 
				moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

			return Ok(moviesQuery
				.ToList()
				.Select(Mapper.Map<Movie, MovieDto>));
		}

		//public IEnumerable<MovieDto> GetMovies(string query = null)
		//{
		//	var moviesQuery = _context.Movies
		//		.Include(m => m.Genre)
		//		.Where(m => m.NumberAvailable > 0);

		//	if (!String.IsNullOrWhiteSpace(query))
		//		moviesQuery = moviesQuery.Where(m => m.Name.Contains(query));

		//	return moviesQuery
		//		.ToList()
		//		.Select(Mapper.Map<Movie, MovieDto>);
		//}

		//Get single
		public IHttpActionResult GetMovies(int id)
		{
			var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

			if (movie == null) return NotFound();

			return Ok(Mapper.Map<Movie, MovieDto>(movie));
		}

		//Post
		[HttpPost]
		public IHttpActionResult CreateMovies(MovieDto movieDto)
		{
			if (!ModelState.IsValid) return BadRequest();

			var movie = Mapper.Map<MovieDto, Movie>(movieDto);
			movie.DateAdded = DateTime.Today;
			movie.NumberAvailable = movie.NumberInStock;

			_context.Movies.Add(movie);
			_context.SaveChanges();

			movieDto.Id = movie.Id;
			movieDto.DateAdded = movie.DateAdded;

			return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
		}


		//Put
		[HttpPut]
		public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
		{
			if (!ModelState.IsValid) return BadRequest();

			var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
			if (movieInDb == null) return NotFound();

			//movieDto.Id = id;

			Mapper.Map(movieDto, movieInDb);
			_context.SaveChanges();

			return Ok("Updated");
		}
		//Delete
		[HttpDelete]
		public IHttpActionResult DeleteMovie(int id)
		{
			var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

			if (movie == null) return NotFound();

			_context.Movies.Remove(movie);

			_context.SaveChanges();

			return Ok("Deleted" + id);
		}
	}
}
