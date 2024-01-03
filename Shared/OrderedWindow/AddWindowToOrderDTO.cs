using System.ComponentModel.DataAnnotations;

namespace WindowStore.Shared.OrderedWindow
{
    public class AddWindowToOrderDTO
    {
        [Required]
        public int OrderId { get; set; }
		[Required]
		public int WindowId { get; set; }
    }
}
