using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Models
{
    public class Movie
    {
        public Movie()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; private set; }

        [Required(ErrorMessage = "The Title field is mandatory.")]
        public string Title { get; set; }

        [Required]
        public string Director { get; set; }

        [StringLength(30, ErrorMessage = "The Genre can't exceed 30 characters long.")]
        public string Genre { get; set; }

        [Range(1, 600, ErrorMessage = "The Duration must be between 1 and 600.")]
        public int Duration { get; set; }
    }
}