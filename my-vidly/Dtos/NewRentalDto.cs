using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using my_vidly.Models;

namespace my_vidly.Dtos
{
	public class NewRentalDto
	{
		public int CustomerId { get; set; }
		public List<int> MovieIds { get; set; }

	}
}