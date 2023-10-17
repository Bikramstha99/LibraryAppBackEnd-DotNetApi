using System.ComponentModel.DataAnnotations;

namespace MovieAppAPI.Dto
{
    public class MovieCreateDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Director { get; set; }
        [Required]
        public string Genre { get; set; }
       
        public DateTime? ReleaseDate { get; set; }

        public IFormFile? MovieImage { get; set; }
    }
}
