namespace WindowStore.Shared.Window
{
    public class WindowDTO
    {
        public int WindowId { get; set; }
        public required string WindowName { get; set; }
        public ushort QuantityOfWindows { get; set; }
    }
}
