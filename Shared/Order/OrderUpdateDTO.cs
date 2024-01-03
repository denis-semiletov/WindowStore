using System.ComponentModel.DataAnnotations;

namespace WindowStore.Shared.Order
{
    public class OrderUpdateDTO
    {
        [Required]
        public int OrderId { get; set; }
		[Required]
		public string OrderName { get; set; }
		[Required]
		public string State { get; set; }
    }
}
