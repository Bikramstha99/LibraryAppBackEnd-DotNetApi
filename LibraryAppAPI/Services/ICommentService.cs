using LibraryAppAPI.Dto;

namespace LibraryAppAPI.Services
{
    public interface ICommentService
    {
        Task<List<CommentDto>> GetAllCommentAsync();

        Task<CommentDto> GetCommentAsync(int commentId);

        Task<bool> CreateBookCommentAsync(CommentCreateDto commentDto);

        Task<bool> UpdateCommentAsync(CommentDto commentDto);

        Task<bool> DeleteCommentAsync(int commentId);
        Task<List<CommentDto>> GetBookCommentAsync(int MovieId);

        Task<bool> AddBookCommentAsync(int MovieId, CommentCreateDto commentDto);
    }
}
