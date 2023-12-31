using AutoMapper;
using WindowsStore.DAL.Order;
using WindowsStore.DAL.OrderedWindow;
using WindowsStore.DAL.OrderedWindowSubElement;
using WindowsStore.DAL.SubElement;
using WindowsStore.DAL.Window;
using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;
using WindowStore.Shared.SubElement;
using WindowStore.Shared.Window;

namespace WindowsStore.BLL
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderUpdateDTO, Order>();
            CreateMap<OrderCreateDTO, Order>();

            CreateMap<OrderedWindow, OrderedWindowDTO>();
            CreateMap<OrderedWindowSubElement, OrderedWindowSubElementDTO>();
            CreateMap<AddSubElementToOrderedWindowDTO, OrderedWindowSubElement>().ForMember(r => r.Id, opt => opt.Ignore());
            CreateMap<AddWindowToOrderDTO, OrderedWindow>().ForMember(r => r.OrderedWindowId, opt => opt.Ignore());

            CreateMap<SubElement, SubElementDTO>();
            CreateMap<SubElementCreateDTO, SubElement>();
            CreateMap<SubElementUpdateDTO, SubElement>();

            CreateMap<Window, WindowDTO>();
            CreateMap<WindowCreateDTO, Window>();
            CreateMap<WindowUpdateDTO, Window>();
        }
    }
}
