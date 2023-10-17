using System.ComponentModel.DataAnnotations;

namespace MovieAppAPI.Dto
{
    public class MovieUpdateDto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Genre { get; set; }
     
        public DateTime? ReleaseDate { get; set; }
        [Required]
        public IFormFile? MovieImage { get; set; }
    }
}
