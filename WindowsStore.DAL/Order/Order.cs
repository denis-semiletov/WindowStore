using System.ComponentModel.DataAnnotations;

namespace WindowsStore.DAL.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public required string OrderName { get; set; }
        public required string State { get; set; }
        public List<OrderedWindow.OrderedWindow> OrderedWindows { get; set; } = [];
    }
}
