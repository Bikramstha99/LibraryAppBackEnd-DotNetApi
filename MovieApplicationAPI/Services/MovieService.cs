using AutoMapper;
using Microsoft.AspNetCore.Http;
using MovieAppAPI.Data;
using MovieAppAPI.Dto;
using MovieAppAppication.Interface.IRepository;
using MovieAppDomain;
using System.Globalization;

namespace MovieAppAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly string _imageMovieDirectory;

        public MovieService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _imageMovieDirectory = env.WebRootPath + @"\Images\Movie";
        }

        public async Task<List<MovieDto>> GetAllMoviesAsync()
        {
            var movie = await _unitOfWork.MovieRepo.GetAllAsync();

            var movieDto = _mapper.Map<List<MovieDto>>(movie);
            //movieDto.MovieImage = movie.PhotoPath;
            return movieDto;
        }
        public async Task<MovieDto> GetMovieAsync(int id)
        {
            var movie = await _unitOfWork.MovieRepo.GetByIdAsync(id);
            var movieDto = _mapper.Map<MovieDto>(movie);
            return movieDto;
        }

        public async Task<bool> AddMovieAsync(MovieCreateDto movieDto)
        {
           
            if (!Directory.Exists(_imageMovieDirectory))
            {
                Directory.CreateDirectory(_imageMovieDirectory);
            }

            FileInfo _fileInfo = new FileInfo(movieDto.MovieImage.FileName);
            string filename = _fileInfo.Name.Replace(_fileInfo.Extension, "") + "_" + DateTime.Now.Ticks.ToString() + _fileInfo.Extension;
            var _filePath = $"{_imageMovieDirectory}\\{filename}";
            using (var _fileStream = new FileStream(_filePath, FileMode.Create))
            {
                await movieDto.MovieImage.CopyToAsync(_fileStream);
            }

            string _urlPath = _filePath.Replace('\\', '/').Split("wwwroot").Last();

            var movie = _mapper.Map<Movie>(movieDto);
            movie.PhotoPath = _urlPath;
            await _unitOfWork.MovieRepo.CreateAsync(movie);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateMovieAsync(MovieUpdateDto movieDto)
        {
            if (!Directory.Exists(_imageMovieDirectory))
            {
                Directory.CreateDirectory(_imageMovieDirectory);
            }

            FileInfo _fileInfo = new FileInfo(movieDto.MovieImage.FileName);
            string filename = _fileInfo.Name.Replace(_fileInfo.Extension, "") + "_" + DateTime.Now.Ticks.ToString() + _fileInfo.Extension;
            var _filePath = $"{_imageMovieDirectory}\\{filename}";
            using (var _fileStream = new FileStream(_filePath, FileMode.Create))
            {
                await movieDto.MovieImage.CopyToAsync(_fileStream);
            }

            string _urlPath = _filePath.Replace('\\', '/').Split("wwwroot").Last();

            var movie = _mapper.Map<Movie>(movieDto);
            movie.PhotoPath = _urlPath;

            await _unitOfWork.MovieRepo.UpdateAsync(movie);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            await _unitOfWork.MovieRepo.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

