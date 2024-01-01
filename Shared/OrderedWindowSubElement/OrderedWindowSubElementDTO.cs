using WindowStore.Shared.SubElement;

namespace WindowStore.Shared.OrderedWindowSubElement
{
	public class OrderedWindowSubElementDTO
	{
		public int Id { get; set; }
		public int OrderedWindowId { get; set; }
        public SubElementDTO? SubElement { get; set; }
    }
}
