using LibraryAppAPI.Dto;
using LibraryAppDomain;

namespace LibraryAppAPI.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetAllUserAsync();
        Task<UserDto> GetUserAsync(int id);
        //Task<bool> UpdateMovieAsync(MovieDto movieDto);
        Task<bool> DeleteUserAsync(int id);
        Task<bool> RegisterUserAsync(RegisterDto registerDto);
        Task<User> LoginUserAsync(LoginDto loginDto);
    }
}
