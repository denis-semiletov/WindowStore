using WindowStore.Shared.SubElement;

namespace WindowsStore.BLL.Interfaces
{
    public interface ISubElementService
    {
        Task<List<SubElementDTO>> GetSubElements();
        Task<SubElementDTO> CreateSubElementAsync(SubElementCreateDTO subElementCreateDTO);
        Task<SubElementDTO> UpdateSubElementAsync(SubElementUpdateDTO subElementUpdateDTO);
        Task<bool> SubElementRemoveAsync(int subElementId);
        Task<int> GetOrdersCountBySubElementIdAsync(int subElementId);
    }
}
