using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="El Nombre es requerido")]
        public string Name { get; set; }

       

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "El Genero es requerido")]
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Release Date")]
        [Required(ErrorMessage = "El ReleaseDate es requerido")]
        public DateTime? ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Required(ErrorMessage = "El NumberInStock es requerido")]
        [Range(1,int.MaxValue,ErrorMessage ="El Stock debe ser mayor a cero")]
        public byte? NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }

    }
}