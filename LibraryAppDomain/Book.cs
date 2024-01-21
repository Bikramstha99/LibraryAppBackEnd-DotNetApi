using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppDomain
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string? BookName { get; set; }
        public string? Writer {  get; set; }
        public string? Genre {  get; set; }
        public DateTime ReleaseDate { get; set; }
        public string PhotoPath { get; set; }


    }
}
