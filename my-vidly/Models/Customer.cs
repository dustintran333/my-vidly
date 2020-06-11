using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace my_vidly.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Required][StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		//Navigation property
		public MembershipType MembershipType { get; set; }

		[Display(Name = "Membership Type")]
		public byte MembershipTypeId { get; set; }

		[Display(Name = "Date of Birth")]
		[Min18YearIfAMember]
		public DateTime? BirthDay { get; set; }
	}
}