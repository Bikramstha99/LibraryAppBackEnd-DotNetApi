using LibraryAppAppication.Interface.IRepository;
using LibraryAppDomain;
using LibraryAppInfrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryAppInfrastructure.Implementation.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDb _context;      
        public BookRepository(AppDb context)
        {
            _context = context;          
        }

        public async Task<bool> CreateAsync(Book book)
        {
            await _context.Books.AddAsync(book);          
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var movieToDelete = await _context.Books.FindAsync(id);

            if (movieToDelete != null)
            {
                _context.Books.Remove(movieToDelete);
                return true;
            }
            return false;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Book book)
        {
            var existingMovie = await _context.Books.FindAsync(book.BookId);

            if (existingMovie != null)
            {
                
                existingMovie.BookName = book.BookName;
                existingMovie.Writer = book.Writer;
                existingMovie.ReleaseDate = book.ReleaseDate;
                existingMovie.Genre= book.Genre;
                existingMovie.PhotoPath= book.PhotoPath;
                
                return true; 
            }
            return false;
        }
    }
}
