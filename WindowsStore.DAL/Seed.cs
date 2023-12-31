using Microsoft.EntityFrameworkCore;
using WindowStore.Shared.SubElement;

namespace WindowsStore.DAL
{
    public static class Seed
    {
        public static async Task TestingSeedData(BlazorWindowStoreContext context)
        {
            if (!context.SubElements.Any())
            {
                await context.SubElements.AddRangeAsync([
                    new SubElement.SubElement
                    {
                        Element = 1,
                        Width = 1200,
                        Hight = 1850,
                        Type = SubElementType.Doors
                    },
                    new SubElement.SubElement
                    {
                        Element = 2,
                        Width = 800,
                        Hight = 1850,
                        Type = SubElementType.Window
                    },
                    new SubElement.SubElement
                    {
                        Element = 3,
                        Width = 700,
                        Hight = 1850,
                        Type = SubElementType.Window
                    },
                    new SubElement.SubElement
                    {
                        Element = 1,
                        Width = 1500,
                        Hight = 2000,
                        Type = SubElementType.Window
                    },
                    new SubElement.SubElement
                    {
                        Element = 1,
                        Width = 1400,
                        Hight = 2200,
                        Type = SubElementType.Doors
                    },
                    new SubElement.SubElement
                    {
                        Element = 2,
                        Width = 600,
                        Hight = 2200,
                        Type = SubElementType.Window
                    }
                ]);
                await context.SaveChangesAsync();
            }


            if (!context.Orders.Any())
            {
                var subElements = await context.SubElements.ToDictionaryAsync(e => e.SubElementId, e => e);

                context.Orders.AddRange([
                    new Order.Order
                    {
                        OrderName = "New York Building 1",
                        State = "NY",
                        OrderedWindows = [
                            new()
                            {
                                Window = new Window.Window
                                {
                                    WindowName = "A51",
                                    QuantityOfWindows = 4
                                },
                                OrderedWindowSubElements =
                                [
                                    new OrderedWindowSubElement.OrderedWindowSubElement
                                    {
                                        SubElement = subElements[1]
                                    },
                                    new OrderedWindowSubElement.OrderedWindowSubElement
                                    {
                                        SubElement = subElements[2]
                                    },
                                    new OrderedWindowSubElement.OrderedWindowSubElement
                                    {
                                        SubElement = subElements[3]
                                    },
                                ]
                            },
                            new()
                            {
                                Window = new Window.Window
                                {
                                    WindowName = "C Zone 5",
                                    QuantityOfWindows = 2
                                },
                                OrderedWindowSubElements =
                                [
                                    new OrderedWindowSubElement.OrderedWindowSubElement
                                    {
                                        SubElement = subElements[4]
                                    }
                                ]
                            }
                        ]
                    },
                    new Order.Order
                    {
                        OrderName = "California Hotel AJK",
                        State = "CA",
                        OrderedWindows = [
                            new()
                            {
                                Window = new Window.Window
                                {
                                    WindowName = "GLB",
                                    QuantityOfWindows = 3
                                },
                                OrderedWindowSubElements =
                                [
                                    new OrderedWindowSubElement.OrderedWindowSubElement
                                    {
                                        SubElement = subElements[5]
                                    },
                                    new OrderedWindowSubElement.OrderedWindowSubElement
                                    {
                                        SubElement = subElements[6]
                                    }
                                ]
                            },
                            new()
                            {
                                Window = new Window.Window
                                {
                                    WindowName = "OHF",
                                    QuantityOfWindows = 10
                                },
                                OrderedWindowSubElements =
                                [
                                    new OrderedWindowSubElement.OrderedWindowSubElement
                                    {
                                        SubElement = subElements[4]
                                    },
                                    new OrderedWindowSubElement.OrderedWindowSubElement
                                    {
                                        SubElement = subElements[4]
                                    },
                                ]
                            }
                        ]
                    }]);

                await context.SaveChangesAsync();
            }
        }
    }
}
