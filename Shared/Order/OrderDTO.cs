using WindowStore.Shared.OrderedWindow;

namespace WindowStore.Shared.Order
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public required string OrderName { get; set; }
        public required string State { get; set; }
        public List<OrderedWindowDTO>? OrderedWindows { get; set; } = [];
    }
}
