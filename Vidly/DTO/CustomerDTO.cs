using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.DTO
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre de usuario requerido")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSuscribedToNewsletter { get; set; }

        [Min18YearsIfAMember(ErrorMessage = "Birth Date is required")]
        public DateTime? BirthDate { get; set; }



        public byte MembershipTypeId { get; set; }
    }
}