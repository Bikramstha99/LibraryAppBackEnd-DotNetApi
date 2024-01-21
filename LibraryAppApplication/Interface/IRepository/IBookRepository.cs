using LibraryAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppAppication.Interface.IRepository
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();

        Task<Book> GetByIdAsync(int id);

        Task<bool> CreateAsync(Book book);

        Task<bool> UpdateAsync(Book book);

        Task<bool> DeleteAsync(int id);
    }
}
