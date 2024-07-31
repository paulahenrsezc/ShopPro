using Newtonsoft.Json;
using ShopPro.Web.Interfaces;
using ShopPro.Web.Models.OrderDetails;
using ShopPro.Web.Models.OrderDetails.Results;
using System.Net.Http;
using System.Text;

namespace ShopPro.Web.Services
{
    public class OrderDetailsService : IOrderDetailsService
    {
        private readonly HttpClientHandler httpClientHandler;
        private const string Url = "http://localhost:40947/api/OrderDetails/";

        public OrderDetailsService()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        public async Task<OrderDetailsGetResult> GetById(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{Url}GetOrderDetailsById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<OrderDetailsGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new OrderDetailsGetResult { success = false, message = "Error al obtener los detalles de la orden." };
                    }
                }
            }
        }

        public async Task<OrderDetailsListGetResult> GetList()
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{Url}GetOrderDetails";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<OrderDetailsListGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new OrderDetailsListGetResult { success = false, message = "Error al obtener la lista de detalles de ordenes." };
                    }
                }
            }
        }

        public async Task<OrderDetailsGetResult> Save(OrderDetailsSaveModel orderDetailsSave)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{Url}SaveOrderDetails";
                var content = new StringContent(JsonConvert.SerializeObject(orderDetailsSave), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<OrderDetailsGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new OrderDetailsGetResult { success = false, message = "Error al guardar los detalles de la orden." };
                    }
                }
            }
        }

        public async Task<OrderDetailsGetResult> Update(OrderDetailsUpdateModel orderDetailsUpdate)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{Url}UpdateOrderDetails";
                var content = new StringContent(JsonConvert.SerializeObject(orderDetailsUpdate), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<OrderDetailsGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new OrderDetailsGetResult { success = false, message = "Error al actualizar los detalles de la orden." };
                    }
                }
            }
        }

        public async Task<OrderDetailsUpdateModel> GetUpdateModelById(int id)
        {
            var orderDetailsGetResult = await GetById(id);
            if (!orderDetailsGetResult.success)
            {
                return null;
            }

            var orderDetailsUpdateModel = new OrderDetailsUpdateModel
            {
                orderid = orderDetailsGetResult.data.id,
                productid = orderDetailsGetResult.data.productid,
                unitprice = orderDetailsGetResult.data.unitprice,
                qty = orderDetailsGetResult.data.qty,
                discount = orderDetailsGetResult.data.discount
            };

            return orderDetailsUpdateModel;
        }

    }
}
