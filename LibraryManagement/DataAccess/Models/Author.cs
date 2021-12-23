namespace DataAccess.Models
{
    public class Author : EntityBase
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Description { get; set; }
    }
}
