using System.ComponentModel.DataAnnotations;

namespace LibraryAppAPI.Dto
{
    public class BookUpdateDto
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Writer { get; set; }
        [Required]
        public string Genre { get; set; }
     
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public IFormFile? BookImage { get; set; }
    }
}
