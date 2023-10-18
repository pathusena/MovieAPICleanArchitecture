using Microsoft.EntityFrameworkCore;
using MovieAPICleanArchitecture.Application.Services.MovieServices;
using MovieAPICleanArchitecture.Domain.Models;
using MovieAPICleanArchitecture.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPICleanArchitecture.Infrastructure.Repositories.MovieRepositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public MovieRepository(ApplicationDBContext dBContext) { 
            _dbContext = dBContext;
        }

        public async Task<List<Movie>> GetMoviesAsync() { 
            return await _dbContext.Movies.ToListAsync();
        }
    }
}
