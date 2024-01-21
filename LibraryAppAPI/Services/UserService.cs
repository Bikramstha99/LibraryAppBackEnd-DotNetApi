using AutoMapper;
using LibraryAppAPI.Dto;
using LibraryAppAppication.Interface.IRepository;
using LibraryAppDomain;

namespace LibraryAppAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
      

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> RegisterUserAsync(RegisterDto registerDto)
        {
            var user = _mapper.Map<User>(registerDto);
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerDto.Password);
            await _unitOfWork.UserRepo.RegisterUserAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<User> LoginUserAsync(LoginDto loginDto)
        {
            var user=_mapper.Map<User>(loginDto);  
            var founduser=  await _unitOfWork.UserRepo.LoginUserAsync(user);
            return founduser;
            
            
        }

        public async Task<List<UserDto>> GetAllUserAsync()
        {
            var user = await _unitOfWork.UserRepo.GetAllUserAsync();

            var userDto = _mapper.Map<List<UserDto>>(user);

            //movieDto.MovieImage = movie.PhotoPath;
            return userDto;
        }

        public async Task<UserDto> GetUserAsync(int Userid)
        {
            var user = await _unitOfWork.UserRepo.GetByUserIdAsync(Userid);
            var userDto = _mapper.Map<UserDto>(user);
            return userDto;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            await _unitOfWork.UserRepo.DeleteUserAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
