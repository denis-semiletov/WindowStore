using WindowStore.Shared.SubElement;

namespace WindowStore.Client.Services
{
    public interface ISubElementServiceClient
    {
        Task<List<SubElementDTO>?> GetSubElements();
        Task<SubElementDTO?> CreateSubElementAsync(SubElementCreateDTO subElementCreateDTO);
        Task<SubElementDTO?> UpdateSubElementAsync(SubElementUpdateDTO subElementUpdateDTO);
        Task<bool> SubElementRemoveAsync(int subElementId);
    }
}
