using AutoMapper;
using LibraryAppAPI.Dto;
using LibraryAppAppication.Interface.IRepository;
using LibraryAppDomain;
using LibraryppAPI.Dto;

namespace LibraryAppAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;
        private readonly string _imageMovieDirectory;

        public BookService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _env = env;
            _imageMovieDirectory = env.WebRootPath + @"\Images\Book";
        }

        public async Task<List<BookDto>> GetAllBooksAsync()
        {
            var movie = await _unitOfWork.BookRepo.GetAllAsync();

            var movieDto = _mapper.Map<List<BookDto>>(movie);
            //movieDto.MovieImage = movie.PhotoPath;
            return movieDto;
        }
        public async Task<BookDto> GetBookAsync(int id)
        {
            var movie = await _unitOfWork.BookRepo.GetByIdAsync(id);
            var movieDto = _mapper.Map<BookDto>(movie);
            return movieDto;
        }

        public async Task<bool> AddBookAsync(BookCreateDto bookDto)
        {
           
            if (!Directory.Exists(_imageMovieDirectory))
            {
                Directory.CreateDirectory(_imageMovieDirectory);
            }

            FileInfo _fileInfo = new FileInfo(bookDto.BookImage.FileName);
            string filename = _fileInfo.Name.Replace(_fileInfo.Extension, "") + "_" + DateTime.Now.Ticks.ToString() + _fileInfo.Extension;
            var _filePath = $"{_imageMovieDirectory}\\{filename}";
            using (var _fileStream = new FileStream(_filePath, FileMode.Create))
            {
                await bookDto.BookImage.CopyToAsync(_fileStream);
            }

            string _urlPath = _filePath.Replace('\\', '/').Split("wwwroot").Last();

            var movie = _mapper.Map<Book>(bookDto);
            movie.PhotoPath = _urlPath;
            await _unitOfWork.BookRepo.CreateAsync(movie);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateBookAsync(BookUpdateDto bookDto)
        {
            if (!Directory.Exists(_imageMovieDirectory))
            {
                Directory.CreateDirectory(_imageMovieDirectory);
            }

            FileInfo _fileInfo = new FileInfo(bookDto.BookImage.FileName);
            string filename = _fileInfo.Name.Replace(_fileInfo.Extension, "") + "_" + DateTime.Now.Ticks.ToString() + _fileInfo.Extension;
            var _filePath = $"{_imageMovieDirectory}\\{filename}";
            using (var _fileStream = new FileStream(_filePath, FileMode.Create))
            {
                await bookDto.BookImage.CopyToAsync(_fileStream);
            }

            string _urlPath = _filePath.Replace('\\', '/').Split("wwwroot").Last();

            var movie = _mapper.Map<Book>(bookDto);
            movie.PhotoPath = _urlPath;

            await _unitOfWork.BookRepo.UpdateAsync(movie);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            await _unitOfWork.BookRepo.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

