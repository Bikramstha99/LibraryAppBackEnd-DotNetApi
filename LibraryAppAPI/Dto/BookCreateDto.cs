using System.ComponentModel.DataAnnotations;

namespace LibraryAppAPI.Dto
{
    public class BookCreateDto
    {
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Writer { get; set; }
        [Required]
        public string Genre { get; set; }
       
        public DateTime ReleaseDate { get; set; }

        public IFormFile? BookImage { get; set; }
    }
}
