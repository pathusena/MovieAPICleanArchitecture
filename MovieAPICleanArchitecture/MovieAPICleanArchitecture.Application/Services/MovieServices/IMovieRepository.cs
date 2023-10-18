using MovieAPICleanArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPICleanArchitecture.Application.Services.MovieServices
{
    public interface IMovieRepository
    {
        Task<List<Movie>> GetMoviesAsync();
    }
}
