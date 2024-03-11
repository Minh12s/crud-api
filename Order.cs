namespace CRUD_order
{
    public class Order
    {
        public int OrderId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? Status { get; set; }
    }
}
