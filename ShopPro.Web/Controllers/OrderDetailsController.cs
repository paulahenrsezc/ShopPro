using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopPro.Web.Models;
using ShopPro.Web.Models.OrderDetails;

namespace ShopPro.Web.Controllers
{
    public class OrderDetailsController : Controller
    {
        // GET: OrderDetailsController

        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public OrderDetailsController()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        public async Task<ActionResult> Index()
        {
            OrderDetailsListGetResult orderdetailsGetResult = new OrderDetailsListGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:40947/api/OrderDetails/GetOrderDetails";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        orderdetailsGetResult = JsonConvert.DeserializeObject<OrderDetailsListGetResult>(apiResponse);

                        if (!orderdetailsGetResult.success)
                        {
                            ViewBag.Message = orderdetailsGetResult.message;
                            return View();
                        }
                    }

                }
            }

            return View(orderdetailsGetResult.data);
        }

        // GET: OrderDetailsController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            OrderDetailsGetResult orderdetailsGetResult = new OrderDetailsGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:40947/api/OrderDetails/GetOrderDetailsById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        orderdetailsGetResult = JsonConvert.DeserializeObject<OrderDetailsGetResult>(apiResponse);

                        if (!orderdetailsGetResult.success)
                        {
                            ViewBag.Message = orderdetailsGetResult.message;
                            return View();
                        }
                    }

                }
            }

            return View(orderdetailsGetResult.data);
        }

        // GET: OrderDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderDetailsSaveModel orderdetailsSave)
        {
            try
            {
                OrderDetailsSaveResult orderdetailsSaveResult = new OrderDetailsSaveResult();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:40947/api/OrderDetails/SaveOrderDetails";

                    using (var response = await httpClient.PostAsJsonAsync<OrderDetailsSaveModel>(url, orderdetailsSave))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            orderdetailsSaveResult = JsonConvert.DeserializeObject<OrderDetailsSaveResult>(apiResponse);

                            if (!orderdetailsSaveResult.success)
                            {
                                ViewBag.Message = orderdetailsSaveResult.message;
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag["Message"] = orderdetailsSaveResult.message;
                            return View();
                        }

                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderDetailsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            OrderDetailsGetResult orderdetailsGetResult = new OrderDetailsGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:40947/api/OrderDetails/GetOrderDetailsById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        orderdetailsGetResult = JsonConvert.DeserializeObject<OrderDetailsGetResult>(apiResponse);

                        if (!orderdetailsGetResult.success)
                        {
                            ViewBag.Message = orderdetailsGetResult.message;
                            return View();
                        }
                    }
                }
            }

            OrderDetailsUpdateModel orderdetailsUpdateModel = new OrderDetailsUpdateModel
            {
                orderid = orderdetailsGetResult.data.id,
                productid = orderdetailsGetResult.data.productid,
                unitprice = orderdetailsGetResult.data.unitprice,
                qty = orderdetailsGetResult.data.qty,
                discount = orderdetailsGetResult.data.discount
            };

            return View(orderdetailsUpdateModel);
        }

        // POST: OrderDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrderDetailsUpdateModel orderdetailsUpdate)
        {

            try
            {
                OrderDetailsUpdateResult orderdetailsUpdateResult = new OrderDetailsUpdateResult();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:40947/api/OrderDetails/UpdateOrderDetails";

                    using (var response = await httpClient.PutAsJsonAsync(url, orderdetailsUpdate))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            orderdetailsUpdateResult = JsonConvert.DeserializeObject<OrderDetailsUpdateResult>(apiResponse);

                            if (!orderdetailsUpdateResult.success)
                            {
                                ViewBag.Message = orderdetailsUpdateResult.message;
                                return View(orderdetailsUpdate);
                            }
                        }
                        else
                        {
                            ViewBag.Message = "Error en la actualización de los detalles de las ordenes.";
                            return View(orderdetailsUpdate);
                        }
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = "Error inesperado.";
                return View(orderdetailsUpdate);
            }

        }

    }
}
