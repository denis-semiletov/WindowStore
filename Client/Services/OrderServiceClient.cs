using System.Net.Http.Json;
using WindowStore.Shared.Order;
using WindowStore.Shared.OrderedWindow;
using WindowStore.Shared.OrderedWindowSubElement;

namespace WindowStore.Client.Services
{
	public class OrderServiceClient(HttpClient httpClient) : IOrderServiceClient
	{
		public async Task<OrderedWindowSubElementDTO?> AddSubElementToOrderAsync(AddSubElementToOrderedWindowDTO addSubElementToOrderedWindowDTO)
		{
			var response = await httpClient.PostAsJsonAsync("/api/orders/subElement", addSubElementToOrderedWindowDTO);

			return await response.Content.ReadFromJsonAsync<OrderedWindowSubElementDTO>();
		}

		public async Task<OrderedWindowDTO?> AddWindowToOrderAsync(AddWindowToOrderDTO addWindowToOrderDTO)
		{
			var response = await httpClient.PostAsJsonAsync("/api/orders/window", addWindowToOrderDTO);

			return await response.Content.ReadFromJsonAsync<OrderedWindowDTO>();
		}

		public async Task<OrderDTO?> CreateOrderAsync(OrderCreateDTO orderCreteDTO)
		{
			var response = await httpClient.PostAsJsonAsync("/api/orders", orderCreteDTO);

			return await response.Content.ReadFromJsonAsync<OrderDTO>();
		}

		public async Task<List<OrderDTO>?> GetOrders()
		{
			return await httpClient.GetFromJsonAsync<List<OrderDTO>>("/api/orders/all");
		}

		public async Task<bool> RemoveOrderAsync(int orderId)
		{
			var response = await httpClient.DeleteAsync($"/api/orders/{orderId}");

			return await response.Content.ReadFromJsonAsync<bool>();
		}

		public async Task<bool> RemoveSubElementFromOrderAsync(int orderedSubElementId)
		{
			var response = await httpClient.DeleteAsync($"/api/orders/subElement/{orderedSubElementId}");

			return await response.Content.ReadFromJsonAsync<bool>();
		}

		public async Task<bool> RemoveWindowFromOrderAsync(int orderedWindowId)
		{
			var response = await httpClient.DeleteAsync($"/api/orders/window/{orderedWindowId}");

			return await response.Content.ReadFromJsonAsync<bool>();
		}

		public async Task<OrderDTO?> UpdateOrderAsync(OrderUpdateDTO orderUpdateDTO)
		{
			var response = await httpClient.PutAsJsonAsync("/api/orders", orderUpdateDTO);

			return await response.Content.ReadFromJsonAsync<OrderDTO>();
		}
		public Dictionary<string, string> States
		{
			get
			{
				return new()
						{
							{ "ALABAMA", "AL" },
							{ "ALASKA", "AK" },
							{ "AMERICAN SAMOA", "AS" },
							{ "ARIZONA", "AZ" },
							{ "ARKANSAS", "AR" },
							{ "CALIFORNIA", "CA" },
							{ "COLORADO", "CO" },
							{ "CONNECTICUT", "CT" },
							{ "DELAWARE", "DE" },
							{ "DISTRICT OF COLUMBIA", "DC" },
							{ "FLORIDA", "FL" },
							{ "GEORGIA", "GA" },
							{ "GUAM", "GU" },
							{ "HAWAII", "HI" },
							{ "IDAHO", "ID" },
							{ "ILLINOIS", "IL" },
							{ "INDIANA", "IN" },
							{ "IOWA", "IA" },
							{ "KANSAS", "KS" },
							{ "KENTUCKY", "KY" },
							{ "LOUISIANA", "LA" },
							{ "MAINE", "ME" },
							{ "MARYLAND", "MD" },
							{ "MASSACHUSETTS", "MA" },
							{ "MICHIGAN", "MI" },
							{ "MINNESOTA", "MN" },
							{ "MISSISSIPPI", "MS" },
							{ "MISSOURI", "MO" },
							{ "MONTANA", "MT" },
							{ "NEBRASKA", "NE" },
							{ "NEVADA", "NV" },
							{ "NEW HAMPSHIRE", "NH" },
							{ "NEW JERSEY", "NJ" },
							{ "NEW MEXICO", "NM" },
							{ "NEW YORK", "NY" },
							{ "NORTH CAROLINA", "NC" },
							{ "NORTH DAKOTA", "ND" },
							{ "NORTHERN MARIANA IS", "MP" },
							{ "OHIO", "OH" },
							{ "OKLAHOMA", "OK" },
							{ "OREGON", "OR" },
							{ "PENNSYLVANIA", "PA" },
							{ "PUERTO RICO", "PR" },
							{ "RHODE ISLAND", "RI" },
							{ "SOUTH CAROLINA", "SC" },
							{ "SOUTH DAKOTA", "SD" },
							{ "TENNESSEE", "TN" },
							{ "TEXAS", "TX" },
							{ "UTAH", "UT" },
							{ "VERMONT", "VT" },
							{ "VIRGINIA", "VA" },
							{ "VIRGIN ISLANDS", "VI" },
							{ "WASHINGTON", "WA" },
							{ "WEST VIRGINIA", "WV" },
							{ "WISCONSIN", "WI" },
							{ "WYOMING", "WY"}
						};
			}
		}
	}
}
