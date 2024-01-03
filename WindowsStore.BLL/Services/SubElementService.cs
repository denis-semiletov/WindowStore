using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WindowsStore.BLL.Interfaces;
using WindowsStore.DAL;
using WindowsStore.DAL.SubElement;
using WindowStore.Shared.SubElement;

namespace WindowsStore.BLL.Services
{
    public class SubElementService(BlazorWindowStoreContext context) : ISubElementService
    {
        private readonly IMapper _mapper = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile())).CreateMapper();

        public async Task<List<SubElementDTO>> GetSubElements()
        {
            var subElements = await context.SubElements
                .OrderBy(o => o.Element)
                .ToListAsync();

            var result = _mapper.Map<List<SubElementDTO>>(subElements);

            return result;
        }

        public async Task<SubElementDTO> CreateSubElementAsync(SubElementCreateDTO subElementCreateDTO)
        {
            var subElement = _mapper.Map<SubElement>(subElementCreateDTO);

            await context.SubElements.AddAsync(subElement);

            await context.SaveChangesAsync();

            var dto = _mapper.Map<SubElementDTO>(subElement);

            return dto;
        }

        public async Task<SubElementDTO> UpdateSubElementAsync(SubElementUpdateDTO subElementUpdateDTO)
        {
            var subElement = await context.SubElements.FindAsync(subElementUpdateDTO.SubElementId)
                ?? throw new KeyNotFoundException($"SubElement with SubElementId = {subElementUpdateDTO.SubElementId} not found for update action");

            subElement = _mapper.Map(subElementUpdateDTO, subElement);
            context.SubElements.Update(subElement);

            await context.SaveChangesAsync();

            var dto = _mapper.Map<SubElementDTO>(subElement);

            return dto;
        }

        public async Task<bool> SubElementRemoveAsync(int subElementId)
        {
            var subElement = await context.SubElements.FindAsync(subElementId)
                ?? throw new KeyNotFoundException($"SubElement with SubElementId = {subElementId} not found for remove action");

            context.SubElements.Remove(subElement);

            return await context.SaveChangesAsync() > 0;
        }

        public async Task<int> GetOrdersCountBySubElementIdAsync(int subElementId)
        {
            var count = await context.Orders
                .Include(r => r.OrderedWindows).ThenInclude(g => g.OrderedWindowSubElements)
                .CountAsync(o => o.OrderedWindows.Any(f => f.OrderedWindowSubElements.Any(w => w.SubElementId == subElementId)));

            return count;
        }
    }
}
