using BusinessLogic.Enums;

namespace BusinessLogic.Dtos
{
    public class BooksInOrderDto : EntityBaseDto
    {
        public int BookId { get; set; }
        public int OrderId { get; set; }
        public Conditions ConditionBeforeReceiving { get; set; }
        public Conditions ConditionAfterReturning { get; set; }
        public bool IsReturned { get; set; }
    }
}
