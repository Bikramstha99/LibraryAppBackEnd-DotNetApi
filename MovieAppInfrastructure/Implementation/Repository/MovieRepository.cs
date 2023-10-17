using Microsoft.EntityFrameworkCore;
using MovieAppAPI.Data;
using MovieAppAppication.Interface.IRepository;
using MovieAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAppInfrastructure.Implementation.Repository
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDb _context;      
        public MovieRepository(MovieDb context)
        {
            _context = context;          
        }

        public async Task<bool> CreateAsync(Movie movie)
        {
            await _context.Movies.AddAsync(movie);          
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movieToDelete = await _context.Movies.FindAsync(id);

            if (movieToDelete != null)
            {
                _context.Movies.Remove(movieToDelete);
                return true;
            }
            return false;
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Movie movie)
        {
            var existingMovie = await _context.Movies.FindAsync(movie.Id);

            if (existingMovie != null)
            {
                
                existingMovie.Name = movie.Name;
                existingMovie.Director = movie.Director;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.Genre=movie.Genre;
                existingMovie.PhotoPath=movie.PhotoPath;
                
                return true; 
            }
            return false;
        }

    }
}
