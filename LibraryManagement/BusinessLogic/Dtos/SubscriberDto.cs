using BusinessLogic.Enums;

namespace BusinessLogic.Dtos
{
    public class SubscriberDto : EntityBaseDto
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public Genders Gender { get; set; }
        public string Address { get; set; }
    }
}
