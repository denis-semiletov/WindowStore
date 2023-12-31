namespace WindowStore.Shared.Order
{
    public class OrderUpdateDTO
    {
        public required int OrderId { get; set; }
        public required string OrderName { get; set; }
        public required string State { get; set; }
    }
}
