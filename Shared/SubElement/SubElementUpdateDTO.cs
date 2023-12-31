namespace WindowStore.Shared.SubElement
{
    public class SubElementUpdateDTO
    {
        public required int SubElementId { get; set; }
        public required ushort Element { get; set; }
        public required ushort Width { get; set; }
        public required ushort Hight { get; set; }
        public required SubElementType Type { get; set; }
    }
}
