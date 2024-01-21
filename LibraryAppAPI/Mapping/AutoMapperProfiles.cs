using AutoMapper;
using LibraryAppAPI.Dto;
using LibraryAppDomain;
using LibraryppAPI.Dto;

namespace LibraryAppAPI.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<BookCreateDto, Book>().ReverseMap();
            CreateMap<BookUpdateDto, Book>().ReverseMap();

            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<LoginDto,User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<CommentDto, Comment>().ReverseMap();
            CreateMap<CommentCreateDto, Comment>().ReverseMap();

        }
    }
}
