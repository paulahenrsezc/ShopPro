using Newtonsoft.Json;
using ShopPro.Web.Interfaces;
using ShopPro.Web.Models.Employees;
using ShopPro.Web.Models.Employees.Results;
using System.Text;

namespace ShopPro.Web.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly HttpClientHandler httpClientHandler;
        private const string Url = "http://localhost:40947/api/Employees/";

        public EmployeesService()
        {
            this.httpClientHandler = new HttpClientHandler();
            this.httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        public async Task<EmployeesGetResult> GetById(int id)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{Url}GetEmployeesById?id={id}";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeesGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new EmployeesGetResult { success = false, message = "Error al obtener el empleado." };
                    }
                }
            }
        }

        public async Task<EmployeesListGetResult> GetList()
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{Url}GetEmployees";

                using (var response = await httpClient.GetAsync(url))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeesListGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new EmployeesListGetResult { success = false, message = "Error al obtener la lista de empleados." };
                    }
                }
            }
        }

        public async Task<EmployeesGetResult> Save(EmployeesSaveModel employeesSave)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{Url}SaveEmployees";
                var content = new StringContent(JsonConvert.SerializeObject(employeesSave), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeesGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new EmployeesGetResult { success = false, message = "Error al guardar el empleado." };
                    }
                }
            }
        }

        public async Task<EmployeesGetResult> Update(EmployeesUpdateModel employeesUpdate)
        {
            using (var httpClient = new HttpClient(this.httpClientHandler))
            {
                var url = $"{Url}UpdateEmployees";
                var content = new StringContent(JsonConvert.SerializeObject(employeesUpdate), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync(url, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<EmployeesGetResult>(apiResponse);
                        return result;
                    }
                    else
                    {
                        return new EmployeesGetResult { success = false, message = "Error al actualizar el empleado." };
                    }
                }
            }
        }

        public async Task<EmployeesUpdateModel> GetUpdateModelById(int id)
        {
            var employeesGetResult = await GetById(id);
            if (!employeesGetResult.success)
            {
                return null;
            }

            var employeesUpdateModel = new EmployeesUpdateModel
            {
                empid = employeesGetResult.data.id,
                lastname = employeesGetResult.data.lastname,
                firstname = employeesGetResult.data.firstname,
                title = employeesGetResult.data.title,
                titleofcourtesy = employeesGetResult.data.titleofcourtesy,
                birthdate = employeesGetResult.data.birthdate,
                hiredate = employeesGetResult.data.hiredate,
                address = employeesGetResult.data.address,
                city = employeesGetResult.data.city,
                region = employeesGetResult.data.region,
                postalcode = employeesGetResult.data.postalcode,
                country = employeesGetResult.data.country,
                phone = employeesGetResult.data.phone,
                mgrid = employeesGetResult.data.mgrid
            };

            return employeesUpdateModel;
        }

    }
}
