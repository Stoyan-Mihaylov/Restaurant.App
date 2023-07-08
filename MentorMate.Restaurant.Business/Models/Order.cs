using System;
using System.Collections.Generic;
using System.Linq;

namespace MentorMate.Restaurant.Business.Models
{
    public class Order
    {
        public int Id { get; set; }

        public List<OrderProduct> Products { get; set; }

        public decimal TotalPrice => Products.Sum(p => p.Price * p.Quantity);

        public DateTime? CreateOn { get; set; }

        public DateTime? CompleteOn { get; set; }
    }
}
