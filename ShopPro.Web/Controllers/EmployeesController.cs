using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ShopPro.Web.Models;
using ShopPro.Web.Models.Employees;
using System.Text;
using static System.Net.WebRequestMethods;

namespace ShopPro.Web.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: EmployeesController

        HttpClientHandler httpClientHandler = new HttpClientHandler();

        public EmployeesController()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }

        public async Task<ActionResult> Index()
        {
            EmployeesListGetResult employeesGetResult = new EmployeesListGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = "http://localhost:40947/api/Employees/GetEmployees";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        employeesGetResult = JsonConvert.DeserializeObject<EmployeesListGetResult>(apiResponse);

                        if (!employeesGetResult.success)
                        {
                            ViewBag.Message = employeesGetResult.message;
                            return View();
                        }
                    }

                }
            }

            return View(employeesGetResult.data);
        }

        // GET: EmployeesController/Details/5
        public async Task<ActionResult> Details(int id)
        {

            EmployeesGetResult employeesGetResult = new EmployeesGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:40947/api/Employees/GetEmployeesById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        employeesGetResult = JsonConvert.DeserializeObject<EmployeesGetResult>(apiResponse);

                        if (!employeesGetResult.success)
                        {
                            ViewBag.Message = employeesGetResult.message;
                            return View();
                        }
                    }

                }
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
            try
            {
                EmployeesSaveResult employeesSaveResult = new EmployeesSaveResult();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:40947/api/Employees/SaveEmployees";

                    using (var response = await httpClient.PostAsJsonAsync<EmployeesSaveModel>(url, employeesSave))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            employeesSaveResult = JsonConvert.DeserializeObject<EmployeesSaveResult>(apiResponse);

                            if (!employeesSaveResult.success)
                            {
                                ViewBag.Message = employeesSaveResult.message;
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag["Message"] = employeesSaveResult.message;
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

        // GET: EmployeesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {

            EmployeesGetResult employeesGetResult = new EmployeesGetResult();

            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"http://localhost:40947/api/Employees/GetEmployeesById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();

                        employeesGetResult = JsonConvert.DeserializeObject<EmployeesGetResult>(apiResponse);

                        if (!employeesGetResult.success)
                        {
                            ViewBag.Message = employeesGetResult.message;
                            return View();
                        }
                    }

                }
            }
            return View(employeesGetResult.data);
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeesUpdateModel employeesUpdate)
        {
            try
            {
                EmployeesUpdateResult employeesUpdateResult = new EmployeesUpdateResult();

                using (var httpClient = new HttpClient(this.httpClientHandler))
                {
                    var url = "http://localhost:40947/api/Employees/UpdateEmployees";

                    using (var response = await httpClient.PutAsJsonAsync<EmployeesUpdateModel>(url, employeesUpdate))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            employeesUpdateResult = JsonConvert.DeserializeObject<EmployeesUpdateResult>(apiResponse);

                            if (!employeesUpdateResult.success)
                            {
                                ViewBag.Message = employeesUpdateResult.message;
                                return View();
                            }
                        }
                        else
                        {
                            ViewBag["Message"] = employeesUpdateResult.message;
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

    }
}
