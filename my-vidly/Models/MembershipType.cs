﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace my_vidly.Models
{
	public class MembershipType
	{
		public byte Id { get; set; }
		public short SignUpFee { get; set; }
		public byte DurationInMonths { get; set; }
		public byte DiscoutRate { get; set; }

		[Required][StringLength(255)]
		public string Name { get; set; }

		public static readonly byte Unknown = 0;
		public static readonly byte PayAsYouGo = 1;
	}
} 