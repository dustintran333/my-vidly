using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using my_vidly.Models;

namespace my_vidly.ViewModels
{
	public class MovieFormViewModel
	{
		public Movie Movie { get; set; }
		public IEnumerable<Genre> Genres { get; set; }

		public string Title => Movie.Id == 0 ? "New Movie" : "Edit Movie";
	}
}