namespace WindowStore.Shared.SubElement
{
    public class SubElementDTO
    {
        public int SubElementId { get; set; }
		public ushort Element { get; set; }
		public SubElementType Type { get; set; }
        public ushort Width { get; set; }
        public ushort Hight { get; set; }
    }
}
