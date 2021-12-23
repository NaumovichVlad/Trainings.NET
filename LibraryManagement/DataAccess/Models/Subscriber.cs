using DataAccess.Enums;

namespace DataAccess.Models
{
    public class Subscriber : EntityBase
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public Genders Gender { get; set; }
        public string Address { get; set; }
    }
}
