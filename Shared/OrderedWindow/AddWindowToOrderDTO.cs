namespace WindowStore.Shared.OrderedWindow
{
    public class AddWindowToOrderDTO
    {
        public required int OrderId { get; set; }
        public required int WindowId { get; set; }
    }
}
