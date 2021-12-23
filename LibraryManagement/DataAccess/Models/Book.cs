using DataAccess.Enums;

namespace DataAccess.Models
{
    public class Book : EntityBase
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public Conditions Condition { get; set; }
    }
}
