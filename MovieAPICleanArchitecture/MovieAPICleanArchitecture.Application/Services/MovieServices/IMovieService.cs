using MovieAPICleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPICleanArchitecture.Application.Services.MovieServices
{
    public interface IMovieService
    {
        Task<List<Movie>> GetMovies();
        Task<Movie?> GetMovie(int id);
        Task<Movie> CreateMovie(Movie movie);
        Task<Movie?> UpdateMovie(Movie movie);
        Task<Movie?> DeleteMovie(int id);
    }
}
