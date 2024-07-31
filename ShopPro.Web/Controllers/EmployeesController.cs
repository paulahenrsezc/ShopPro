using Microsoft.AspNetCore.Mvc;
using ShopPro.Web.Interfaces;
using ShopPro.Web.Models.Employees;

namespace ShopPro.Web.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesService _employeesService;

        public EmployeesController(IEmployeesService employeesService)
        {
            _employeesService = employeesService;
        }

        // GET: EmployeesController
        public async Task<ActionResult> Index()
        {
            var employeesGetResult = await _employeesService.GetList();
            if (!employeesGetResult.success)
            {
                ViewBag.Message = employeesGetResult.message;
                return View();
            }
            return View(employeesGetResult.data);
        }

        // GET: EmployeesController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var employeesGetResult = await _employeesService.GetById(id);
            if (!employeesGetResult.success)
            {
                ViewBag.Message = employeesGetResult.message;
                return View();
            }
            return View(employeesGetResult.data);
        }

        // GET: EmployeesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeesSaveModel employeesSave)
        {
            var employeesSaveResult = await _employeesService.Save(employeesSave);
            if (!employeesSaveResult.success)
            {
                ViewBag.Message = employeesSaveResult.message;
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: EmployeesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var employeesUpdateModel = await _employeesService.GetUpdateModelById(id);
            if (employeesUpdateModel == null)
            {
                ViewBag.Message = "Error al obtener los empleados";
                return View();
            }

            return View(employeesUpdateModel);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeesUpdateModel employeesUpdate)
        {
            try
            {
                var employeesUpdateResult = await _employeesService.Update(employeesUpdate);

                if (!employeesUpdateResult.success)
                {
                    ViewBag.Message = employeesUpdateResult.message;
                    return View(employeesUpdate);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Message = "Error inesperado.";
                return View(employeesUpdate);
            }
        }

    }
}
