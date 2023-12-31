using System.ComponentModel.DataAnnotations;

namespace WindowsStore.DAL.Window
{
    public class Window
    {
        [Key]
        public int WindowId { get; set; }
        public required string WindowName { get; set; }
        public ushort QuantityOfWindows { get; set; }
        public List<OrderedWindow.OrderedWindow>? OrderedWindows { get; set; } = [];
    }
}
