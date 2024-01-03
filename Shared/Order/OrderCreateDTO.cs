using System.ComponentModel.DataAnnotations;

namespace WindowStore.Shared.Order
{
    public class OrderCreateDTO
	{
		[Required]
		public string OrderName { get; set; }
		[Required]
		public string State { get; set; }
	}
}