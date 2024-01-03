using System.ComponentModel.DataAnnotations;

namespace WindowStore.Shared.Window
{
    public class WindowCreateDTO
    {
        [Required]
		[MinLength(3, ErrorMessage = "WindowName length can't be least than 3.")]
		[StringLength(50, ErrorMessage = "WindowName length can't be more than 50.")]
		public string WindowName { get; set; }
		[Required]
		public ushort QuantityOfWindows { get; set; }
    }
}
