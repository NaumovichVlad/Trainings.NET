using BusinessLogic.Enums;

namespace BusinessLogic.Dtos
{
    public class BookDto : EntityBaseDto
    {
        public string Title { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
        public Conditions Condition { get; set; }
    }
}
