using LibraryAppAppication.Interface.IRepository;
using LibraryAppDomain;
using LibraryAppInfrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace LibraryAppInfrastructure.Implementation.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDb _context;
        public CommentRepository(AppDb context)
        {
            _context = context;
        }
        public async Task<bool> CreateCommentAsync(Comment commnt)
        {
            await _context.Comments.AddAsync(commnt);
            return true;
        }

        public async Task<bool> DeleteCommentAsync(int commentId)
        {
            var commentToDelete = await _context.Comments.FindAsync(commentId);

            if (commentToDelete != null)
            {
                _context.Comments.Remove(commentToDelete);
                return true;
            }
            return false;
        }

        public async Task<List<Comment>> GetAllCommentAsync()
        {
            return await _context.Comments.ToListAsync();
        }

        public async Task<Comment> GetByCommentIdAsync(int commentId)
        {
            return await _context.Comments.FindAsync(commentId);
        }

        public async Task<List<Comment>> GetByMovieCommentIdAsync(int BookId)
        {
            var comments = await _context.Comments
                .Where(c => c.BookId == BookId)
                .ToListAsync();
            return comments;

        }
        public async Task<bool> CreateMovieCommentAsync(int BookId, Comment comment)
        {
            comment.BookId = BookId;
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateCommentAsync(Comment comment)
        {
            var existingcomment = await _context.Comments.FindAsync(comment.CommentId);

            if (existingcomment != null)
            {

                existingcomment.CommentDesc = comment.CommentDesc;
                return true;
            }
            return false;
        }
    }
}
