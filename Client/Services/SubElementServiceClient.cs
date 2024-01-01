using System.Net.Http.Json;
using WindowStore.Shared.SubElement;

namespace WindowStore.Client.Services
{
    public class SubElementServiceClient(HttpClient httpClient) : ISubElementServiceClient
    {
        public async Task<SubElementDTO?> CreateSubElementAsync(SubElementCreateDTO subElementCreateDTO)
        {
            var response = await httpClient.PostAsJsonAsync("/api/subelements", subElementCreateDTO);

            return await response.Content.ReadFromJsonAsync<SubElementDTO>();
        }

        public async Task<List<SubElementDTO>?> GetSubElements()
        {
            return await httpClient.GetFromJsonAsync<List<SubElementDTO>>("/api/subelements/all");
        }

        public async Task<bool> SubElementRemoveAsync(int subElementId)
        {
            var response = await httpClient.DeleteAsync($"/api/windows/{subElementId}");

            return await response.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<SubElementDTO?> UpdateSubElementAsync(SubElementUpdateDTO subElementUpdateDTO)
        {
            var response = await httpClient.PutAsJsonAsync("/api/subelements", subElementUpdateDTO);

            return await response.Content.ReadFromJsonAsync<SubElementDTO>();
        }
    }
}
