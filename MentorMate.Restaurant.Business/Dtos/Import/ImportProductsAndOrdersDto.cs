using MentorMate.Restaurant.Business.Models;
using System.Collections.Generic;

namespace MentorMate.Restaurant.Business.Dtos.Import
{
    public class ImportProductsAndOrdersDto
    {
        public List<Product> Products { get; set; }

        public List<Order> Orders { get; set; }
    }
}
