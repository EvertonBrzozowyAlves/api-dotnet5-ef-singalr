using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private static List<Movie> movies = new List<Movie>();

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            movies.Add(movie);
            return CreatedAtAction(nameof(GetById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(string id)
        {
            var movie = movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

    }
}