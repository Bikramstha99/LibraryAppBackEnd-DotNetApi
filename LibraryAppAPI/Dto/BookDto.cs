using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace LibraryppAPI.Dto
{
    public class BookDto
    {
        [Key] 
        public int BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string Writer { get; set; }
        [Required]
        public string Genre { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public string PhotoPath { get; set; }
    }
}
