using LibraryAppDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppAppication.Interface.IRepository
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllUserAsync();

        Task<User> GetByUserIdAsync(int Userid);

        Task<bool> RegisterUserAsync(User user);
        Task<User> LoginUserAsync(User user);
        Task<bool> DeleteUserAsync(int Userid);
       
    }
}
