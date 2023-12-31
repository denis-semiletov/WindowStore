using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsStore.DAL.OrderedWindow
{
    public class OrderedWindow
    {
        [Key]
        public int OrderedWindowId { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public Order.Order? Order { get; set; }
        [ForeignKey("Window")]
        public int WindowId { get; set; }
        public Window.Window? Window { get; set; }
        public List<OrderedWindowSubElement.OrderedWindowSubElement> OrderedWindowSubElements { get; set; } = [];
    }
}
