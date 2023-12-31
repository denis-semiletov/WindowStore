using WindowStore.Shared.OrderedWindowSubElement;
using WindowStore.Shared.Window;

namespace WindowStore.Shared.OrderedWindow
{
    public class OrderedWindowDTO
    {
        public int OrderId { get; set; }
        public WindowDTO? Window { get; set; }
        public List<OrderedWindowSubElementDTO>? OrderedWindowSubElements { get; set; }
    }
}
