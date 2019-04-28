﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
	public class Customer
	{
		public int Id { get; set; }

		[Required(ErrorMessage ="Nombre de usuario requerido")]
		[StringLength(255)]
		public string Name { get; set; }

		public bool IsSuscribedToNewsletter { get; set; }

		[Min18YearsIfAMember(ErrorMessage = "Birth Date is required")]
		public DateTime? BirthDate { get; set; }

		public MembershipType MembershipType { get; set; }

		[Display(Name="Membership Type")]
		public byte MembershipTypeId { get; set; }
	}
}