using System;

namespace DataAccess.Models
{
    public class Order : EntityBase
    {
        public int SubscriberId { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
