using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoviesApi.Data;
using MoviesApi.Data.DTOs;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private MovieContext _context;
        private IMapper _mapper;

        public MoviesController(MovieContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public IActionResult AddMovie([FromBody] CreateMovieDto movieDto)
        {
            var movie = _mapper.Map<Movie>(movieDto);

            _context.Movies.Add(movie);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { Id = movie.Id }, movie);
        }

        [HttpGet]
        [Route("")]
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
                var readMovieDto = _mapper.Map<ReadMovieDto>(movie);
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateMovie(long id, [FromBody] UpdateMovieDto updatedMovie)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _mapper.Map(updatedMovie, movie);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult UpdateMovie(long id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return NoContent();
        }

    }
}