using LibraryAppAPI.Dto;
using LibraryppAPI.Dto;

namespace LibraryAppAPI.Services
{
    public interface IBookService
    {
        Task<List<BookDto>> GetAllBooksAsync();

        Task<BookDto> GetBookAsync(int id);

        Task<bool> AddBookAsync(BookCreateDto bookDto);

        Task<bool> UpdateBookAsync(BookUpdateDto bookDto);

        Task<bool> DeleteBookAsync(int id);
    }
}
