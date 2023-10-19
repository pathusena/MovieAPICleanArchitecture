using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieAPICleanArchitecture.Application.Services.MovieServices;
using MovieAPICleanArchitecture.Domain.Models;

namespace MovieAPICleanArchitecture.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Movie>>> GetMovies() {
            var movies = await _movieService.GetMovies();
            return Ok(movies);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id) {
            Movie? movie = await _movieService.GetMovie(id);
            if (movie == null) {
                return BadRequest("Unable to find the movie!");
            }
            return Ok(movie);
        }

        [HttpPost]
        public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
        {
            try
            {
                if (movie == null) { 
                    return BadRequest("Invalid mpvie data!");
                }

                var newMovie = await _movieService.CreateMovie(movie);

                return CreatedAtAction("GetMovie", new { id = newMovie.Id }, newMovie);
            }
            catch {
                return StatusCode(500, "An error occurred while saving data!");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Movie>> UpdateMovie(Movie movie)
        {
            try {
                if (movie == null) {
                    return BadRequest("Invalid movie data!");
                }

                var updatedMovie = await _movieService.UpdateMovie(movie);
                if (updatedMovie == null)
                {
                    return BadRequest("Movie not found");
                }
                return Ok(updatedMovie);
            } catch {
                return StatusCode(500, "An error occurred while updating data!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Movie>> DeleteMovie(int id) {
            try {
                var deletedMovie = await _movieService.DeleteMovie(id);
                if (deletedMovie == null) { 
                    return BadRequest("Movie not found");
                }
                return Ok(deletedMovie);
            }catch {
                return StatusCode(500, "An error occurred while processing data!");
            }
        }
    }
}
