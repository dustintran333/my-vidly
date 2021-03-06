﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using my_vidly.Models;

namespace my_vidly.Dtos
{
	public class CustomerDto
	{
		public int Id { get; set; }

		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSubscribedToNewsletter { get; set; }

		public byte MembershipTypeId { get; set; }
		public MembershipTypeDto MembershipType { get; set; }
		//[Min18YearIfAMember]
		public DateTime? BirthDay { get; set; }

	}
}