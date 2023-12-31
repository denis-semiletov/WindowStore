using System.ComponentModel.DataAnnotations;
using WindowStore.Shared.SubElement;

namespace WindowsStore.DAL.SubElement
{
    public class SubElement
    {
        [Key]
        public int SubElementId { get; set; }
        public SubElementType Type { get; set; }
        public ushort Element { get; set; }
        public ushort Width { get; set; }
        public ushort Hight { get; set; }
    }
}
