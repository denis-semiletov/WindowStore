using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindowSubElement;
using WindowStore.Shared.Window;

namespace WindowStore.Shared.OrderedWindow
{
    public class OrderedWindowDTO
    {
		public int OrderedWindowId { get; set; }
        public WindowDTO? Window { get; set; }
		public bool IsExpanded { get; set; }
		public List<OrderedWindowSubElementDTO>? OrderedWindowSubElements { get; set; }
    }
}
