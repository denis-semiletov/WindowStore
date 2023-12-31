using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WindowsStore.DAL.OrderedWindowSubElement
{
    public class OrderedWindowSubElement
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(OrderedWindow))]
        public int OrderedWindowId { get; set; }
        public OrderedWindow.OrderedWindow? OrderedWindow { get; set; }
        [ForeignKey(nameof(SubElement))]
        public int SubElementId { get; set; }
        public SubElement.SubElement? SubElement { get; set; }
    }
}
