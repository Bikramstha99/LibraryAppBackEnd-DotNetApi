using LibraryAppAppication.Interface.IRepository;
using LibraryAppInfrastructure.Data;

namespace LibraryAppInfrastructure.Implementation.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly AppDb _context;
        public IBookRepository BookRepo { get; set; }
        public IUserRepository UserRepo { get; set; }
        public ICommentRepository CommentRepo { get; set; }

        public UnitOfWork(AppDb context)
        {
            _context = context;
            BookRepo = new BookRepository(context);
            UserRepo=new UserRepository(context);
            CommentRepo = new CommentRepository(context);
        }


        public void Save()
        {
            _context.SaveChanges();
          
        }

        public async Task<bool> SaveChangesAsync()
        {
              await _context.SaveChangesAsync();
            return true;
        }

      
    }
}
