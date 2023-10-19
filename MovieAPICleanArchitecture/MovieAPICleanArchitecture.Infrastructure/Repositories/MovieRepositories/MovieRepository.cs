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

        public async Task<Movie?> GetMovieAsync(int Id) { 
            var movie = await _dbContext.Movies.FindAsync(Id);
            if (movie != null)
            {
                return movie;
            }
            return null;
        }

        public async Task<Movie> CreateMovieAsync(Movie movie) {
            try {
                _dbContext.Movies.Add(movie);
                await _dbContext.SaveChangesAsync();
                return movie;
            } catch {
                throw;
            }
        }

        public async Task<Movie?> UpdateMovieAsync(Movie movie)
        {
            try
            {
                var existingMovie = await _dbContext.Movies.FindAsync(movie.Id);
                if (existingMovie == null)
                {
                    return null;
                }

                existingMovie.Name = movie.Name;
                existingMovie.Description = movie.Description;
                existingMovie.Cost = movie.Cost;

                await _dbContext.SaveChangesAsync();

                return existingMovie;

            } catch {
                throw;
            }
        }

        public async Task<Movie?> DeleteMovieAsync(int id)
        {
            try {
                var existingMovie = await _dbContext.Movies.FindAsync(id);
                if (existingMovie == null){
                    return null;
                }

                _dbContext.Movies.Remove(existingMovie);
                await _dbContext.SaveChangesAsync();
                return existingMovie;
            } catch {
                throw;
            }
        }
    }
}
