

namespace LibraryAppAPI.Dto
{
    public class CommentCreateDto
    {
        public string? CommentDesc { get; set; }

        //[ForeignKey("Movies")]
        //public int MovieId { get; set; }
        //public Movie Movies { get; set; }

        //[ForeignKey("IdentityUser")]
        //public int UserId { get; set; }
        //public User UserName { get; set; }



        public DateTime TimeStamp { get; set; }
    }
}
