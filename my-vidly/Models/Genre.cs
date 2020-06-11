using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;

namespace my_vidly.Models
{
	public class Genre
	{
		public byte Id { get; set; }

		[Required][StringLength(255)]
		[DisplayName("Genre")]
		public string Name { get; set; }
	}
}