using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using my_vidly.Models;

namespace my_vidly.ViewModels
{
	public class CustomerFormViewModel
	{
		public IEnumerable<MembershipType> MembershipTypes { get; set; }
		public Customer Customer { get; set; }
	}
}