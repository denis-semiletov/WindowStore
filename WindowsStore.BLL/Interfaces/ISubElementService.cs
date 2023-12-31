using WindowStore.Shared.SubElement;

namespace WindowsStore.BLL.Interfaces
{
    public interface ISubElementService
    {
        Task<List<SubElementDTO>> GetSubElements();
        Task<SubElementDTO> CreateSubElementAsync(SubElementCreateDTO subElementCreateDTO);
        Task UpdateSubElementAsync(SubElementUpdateDTO subElementUpdateDTO);
        Task SubElementRemoveAsync(int subElementId);
    }
}
