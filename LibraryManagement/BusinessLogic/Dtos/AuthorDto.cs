namespace BusinessLogic.Dtos
{
    public class AuthorDto : EntityBaseDto
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Description { get; set; }
    }
}
