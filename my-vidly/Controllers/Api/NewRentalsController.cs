﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using my_vidly.Dtos;
using my_vidly.Models;


namespace my_vidly.Controllers.Api
{
	public class NewRentalsController : ApiController
	{
		private ApplicationDbContext _context;
		public NewRentalsController()
		{
			_context = new ApplicationDbContext();
		}
		[HttpPost]
		public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
		{
			//getting references from db
			var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

			var movies = _context.Movies.Where( m => newRental.MovieIds.Contains(m.Id) ).ToList();
			
			foreach (var movie in movies)
			{
				//check availability
				if (movie.NumberAvailable == 0) return BadRequest("Movie not Available");

				_context.Rentals.Add(new Rental(){
					Customer = customer,
					Movie = movie,
					DateRented = DateTime.Now
				});
				movie.NumberAvailable--;
			}

			_context.SaveChanges();
			return Ok();
		}
	}
}
