using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private MovieContext _context;
        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddMovie([FromBody] Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(_context.Movies);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(long id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

    }
}