using Microsoft.AspNetCore.Mvc;
using ShopPro.Web.Interfaces;
using ShopPro.Web.Models.OrderDetails;

namespace ShopPro.Web.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly IOrderDetailsService _orderDetailsService;

        public OrderDetailsController(IOrderDetailsService orderDetailsService)
        {
            _orderDetailsService = orderDetailsService;
        }

        // GET: OrderDetailsController
        public async Task<ActionResult> Index()
        {
            var orderDetailsGetResult = await _orderDetailsService.GetList();
            if (!orderDetailsGetResult.success)
            {
                ViewBag.Message = orderDetailsGetResult.message;
                return View();
            }
            return View(orderDetailsGetResult.data);
        }

        // GET: OrderDetailsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var orderDetailsGetResult = await _orderDetailsService.GetById(id);
            if (!orderDetailsGetResult.success)
            {
                ViewBag.Message = orderDetailsGetResult.message;
                return View();
            }
            return View(orderDetailsGetResult.data);
        }

        // GET: OrderDetailsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetailsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(OrderDetailsSaveModel orderDetailsSave)
        {
            var orderDetailsGetResult = await _orderDetailsService.Save(orderDetailsSave);
            if (!orderDetailsGetResult.success)
            {
                ViewBag.Message = orderDetailsGetResult.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: OrderDetailsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var orderDetailsUpdateModel = await _orderDetailsService.GetUpdateModelById(id);
            if (orderDetailsUpdateModel == null)
            {
                ViewBag.Message = "Error al obtener los detalles de la orden.";
                return View();
            }

            return View(orderDetailsUpdateModel);
        }

        // POST: OrderDetailsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(OrderDetailsUpdateModel orderDetailsUpdate)
        {
            try
            {
                var orderDetailsGetResult = await _orderDetailsService.Update(orderDetailsUpdate);
                if (!orderDetailsGetResult.success)
                {
                    ViewBag.Message = orderDetailsGetResult.message;
                    return View(orderDetailsUpdate);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = "Error inesperado.";
                return View(orderDetailsUpdate);
            }
        }

    }
}
