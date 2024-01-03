using System.ComponentModel.DataAnnotations;

namespace WindowStore.Shared.SubElement
{
    public class SubElementUpdateDTO
    {
        [Required]
        public int SubElementId { get; set; }
        [Required]
        public ushort Width { get; set; }
        [Required]
        public ushort Hight { get; set; }
    }
}
