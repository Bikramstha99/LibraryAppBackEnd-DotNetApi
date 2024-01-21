using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAppDomain
{
    public class User
    {
        [Key]
        
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; } 

        [Required]
        public string PasswordHash { get; set; } 

        [Required]
        public string Email { get; set; } 

        [Required]
        public string FirstName { get; set; } 

        [Required]
        public string LastName { get; set; } 
        [Required]
        public string Role { get; set; }
    }
}
