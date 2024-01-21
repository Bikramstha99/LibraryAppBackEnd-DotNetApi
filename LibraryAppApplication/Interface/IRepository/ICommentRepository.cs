using LibraryAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppAppication.Interface.IRepository
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllCommentAsync();

        Task<Comment> GetByCommentIdAsync(int commentId);

        Task<bool> CreateCommentAsync(Comment comment);

        Task<bool> UpdateCommentAsync(Comment comment);

        Task<bool> DeleteCommentAsync(int commentId);

        Task<List<Comment>> GetByMovieCommentIdAsync(int MovieId);

        Task<bool> CreateMovieCommentAsync(int MovieId,Comment comment);


    }
}
