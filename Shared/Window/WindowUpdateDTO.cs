namespace WindowStore.Shared.Window
{
    public class WindowUpdateDTO
    {
        public required int WindowId { get; set; }
        public required string WindowName { get; set; }
        public required ushort QuantityOfWindows { get; set; }
    }
}
