namespace WindowStore.Shared.Order
{
    public class OrderCreateDTO
    {
        public required string OrderName { get; set; }
        public required string State { get; set; }
    }
}