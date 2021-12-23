using DataAccess.Enums;

namespace DataAccess.Models
{
    public class BooksInOrder : EntityBase
    {
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public Conditions ConditionBeforeReceiving { get; set; }
        public Conditions ConditionAfterReturning { get; set; }
        public bool IsReturned { get; set; }
    }
}
