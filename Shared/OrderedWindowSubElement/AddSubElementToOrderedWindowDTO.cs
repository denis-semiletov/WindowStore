using System.ComponentModel.DataAnnotations;

namespace WindowStore.Shared.OrderedWindowSubElement
{
    public class AddSubElementToOrderedWindowDTO
    {
        [Required]
        public int OrderedWindowId { get; set; }
		[Required]
		public int SubElementId { get; set; }
    }
}
