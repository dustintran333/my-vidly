using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace my_vidly.Models
{
	public class Movie
	{
		public int Id { get; set; }

		[Required][StringLength(255)]
		public string Name { get; set; }

		//Navigation property
		public Genre Genre { get; set; }
		//FK exactly the same type
		[DisplayName("Genre")]
		[Required]
		public byte GenreId { get; set; } 

		[DisplayName("Release Date")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}")]
		public DateTime ReleaseDate { get; set; }

		[DisplayName("Date Added")]
		[DisplayFormat(DataFormatString = "{0:dd/MM/YYYY}")]
		public DateTime? DateAdded { get; set; }

		[DisplayName("Number In Stock")]
		[Range(1,20)]
		public int NumberInStock { get; set; }
		public int NumberAvailable { get; set; }
	}
}