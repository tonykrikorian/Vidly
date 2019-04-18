using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;

            if (customer.MembershipTypeId == MembershipType.unknown 
                || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Birth Date is required");

            var age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            return (age > 18) 
                ? ValidationResult.Success 
                : new ValidationResult("The age must be at least 18 years old");
        }
    }
}