using System.ComponentModel.DataAnnotations;

namespace WindowStore.Shared.SubElement
{
    public class SubElementCreateDTO
    {
        [Required]
        public ushort Element { get; set; }
		[Required]
		public SubElementType Type { get; set; }
		[Required]
		public ushort Width { get; set; }
		[Required]
		public ushort Hight { get; set; }
    }
}
