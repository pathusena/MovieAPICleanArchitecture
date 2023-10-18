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
    }
}
