using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public byte? GenreId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public byte? NumberInStock { get; set; }
    }
}