namespace MentorMate.Restaurant.Business.Dtos.Export
{
    public class ExportOrderDto
    {
        public decimal AvgOrderPrice { get; set; }

        public decimal MinOrderPrice { get; set; }

        public decimal MaxOrderPrice { get; set; }

        public int OrdersQuantityForDay { get; set; }
    }
}
