using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using WindowStore.Client.Pages.Dialogs;
using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;

namespace WindowStore.Client.Pages
{
    public partial class Orders
	{
		private List<OrderDTO>? orders;
		protected override async Task OnInitializedAsync()
		{
			orders = await _orderService.GetOrders();
		}

		private void ShowOrderDetails(OrderDTO order)
		{
			if (order != null)
			{
				order.IsExpanded = !order.IsExpanded;
			}
		}
		private void ShowWindowDetails(OrderedWindowDTO orderedWindowDTO)
		{
			if (orderedWindowDTO != null)
			{
				orderedWindowDTO.IsExpanded = !orderedWindowDTO.IsExpanded;
			}
		}

		async Task DeleteOrder(OrderDTO order)
		{
			var parameters = new DialogParameters<DeleteOrderConfirm_Dialog> { { x => x.order, order } };

			var dialog = await DialogService.ShowAsync<DeleteOrderConfirm_Dialog>("Delete Order", parameters);
			var result = await dialog.Result;

			if (!result.Canceled)
			{
				if (int.TryParse(result.Data.ToString(), out int orderId))
				{
					orders?.RemoveAll(item => item.OrderId == orderId);
				}
			}
		}
		async Task AddOrder()
		{
			var options = new DialogOptions { CloseOnEscapeKey = true };
			var dialog = await DialogService.ShowAsync<AddNewOrder_Dialog>("Add New Order", options);
			var result = await dialog.Result;

			if (!result.Canceled)
			{
				if (result.Data is OrderDTO newOrder)
				{
					orders?.Add(newOrder);
				}
			}
		}

		async Task RemoveWindow(OrderDTO order, int orderedWindowId)
		{
			var result = await _orderService.RemoveWindowFromOrderAsync(orderedWindowId);
			if (result)
			{
				order.OrderedWindows?.RemoveAll(ow => ow.OrderedWindowId == orderedWindowId);
			}
		}
		async Task RemoveSubElement(OrderedWindowDTO orderedWindow, int orderedSubElementId)
		{
			var result = await _orderService.RemoveSubElementFromOrderAsync(orderedSubElementId);
			if (result)
			{
				orderedWindow.OrderedWindowSubElements?.RemoveAll(ow => ow.Id == orderedSubElementId);
			}
		}

		async Task AddWindowToOrder(OrderDTO order)
		{
			var parameters = new DialogParameters<AddWindowToOrder_Dialog> { { x => x.order, order } };

			var options = new DialogOptions { CloseOnEscapeKey = true };
			var dialog = await DialogService.ShowAsync<AddWindowToOrder_Dialog>("Add window to order", parameters, options);
			var result = await dialog.Result;

			if (!result.Canceled)
			{
				if (result.Data is OrderedWindowDTO orderedWindow)
				{
					order.OrderedWindows?.Add(orderedWindow);
				}
			}
		}

		async Task AddSubElementToOrderedWindow(OrderedWindowDTO orderedWindow)
		{
			var parameters = new DialogParameters<AddSubElementToOrderedWindow_Dialog> { { x => x.orderedWindow, orderedWindow } };

			var options = new DialogOptions { CloseOnEscapeKey = true };
			var dialog = await DialogService.ShowAsync<AddSubElementToOrderedWindow_Dialog>("Add subelement to ordered window", parameters, options);
			var result = await dialog.Result;

			if (!result.Canceled)
			{
				if (result.Data is OrderedWindowSubElementDTO orderedWindowSubElement)
				{
					orderedWindow.OrderedWindowSubElements?.Add(orderedWindowSubElement);
				}
			}
		}
	}
}
