namespace WindowStore.Shared.SubElement
{
    public class SubElementCreateDTO
    {
        public required ushort Element { get; set; }
        public required ushort Width { get; set; }
        public required ushort Hight { get; set; }
        public required SubElementType Type { get; set; }
    }
}
