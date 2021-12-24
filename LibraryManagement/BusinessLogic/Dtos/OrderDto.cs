using System;

namespace BusinessLogic.Dtos
{
    public class OrderDto : EntityBaseDto
    {
        public int SubscriberId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
