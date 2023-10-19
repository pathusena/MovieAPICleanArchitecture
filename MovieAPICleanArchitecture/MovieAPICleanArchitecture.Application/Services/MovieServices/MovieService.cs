using MovieAPICleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPICleanArchitecture.Application.Services.MovieServices
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _movieRepository.GetMoviesAsync();
        }

        public async Task<Movie?> GetMovie(int id) {
            return await _movieRepository.GetMovieAsync(id);
        }

        public async Task<Movie> CreateMovie(Movie movie) { 
            return await _movieRepository.CreateMovieAsync(movie);
        }

        public async Task<Movie?> UpdateMovie(Movie movie) { 
            return await _movieRepository.UpdateMovieAsync(movie);
        }

        public async Task<Movie?> DeleteMovie(int id) { 
            return await _movieRepository.DeleteMovieAsync(id);
        }
    }
}
