using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using my_vidly.Models;

namespace my_vidly.Dtos
{
	public class MovieDto
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		public byte GenreId { get; set; }
		public GenreDto Genre { get; set; }
			

		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime ReleaseDate { get; set; }


		[DisplayFormat(DataFormatString = "{0:d}")]
		public DateTime? DateAdded { get; set; }

		[Range(1, 20)]
		public int NumberInStock { get; set; }
		public int NumberAvailable { get; set; }

	}
}