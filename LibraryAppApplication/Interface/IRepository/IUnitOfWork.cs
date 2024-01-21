using LibraryAppAppication.Interface.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppAppication.Interface.IRepository
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepo { get; set; }
        IUserRepository UserRepo { get; set; }
        ICommentRepository CommentRepo { get; set; }

        void Save();

        Task<bool> SaveChangesAsync();

    }
}
