using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace my_vidly.Models
{
	public class Min18YearIfAMember: ValidationAttribute
	{
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
		{
			var customer = (Customer) validationContext.ObjectInstance;

			if (customer.MembershipTypeId == MembershipType.PayAsYouGo ||
			    customer.MembershipTypeId == MembershipType.Unknown)
				return ValidationResult.Success;

			if (customer.BirthDay == null)
				return new ValidationResult("Birthdate is required.");

			var age = DateTime.Today.Year - customer.BirthDay.Value.Year;

			return (age >= 18)
				? ValidationResult.Success
				: new ValidationResult("Customer should be at least 18yo to get a membership");
		}
	}
}