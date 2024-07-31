using ShopPro.Web.Models.Employees;
using ShopPro.Web.Models.Employees.Results;
using ShopPro.Web.Models.OrderDetails;

namespace ShopPro.Web.Interfaces
{
    public interface IEmployeesService
    {
        Task<EmployeesListGetResult> GetList();
        Task<EmployeesGetResult> GetById(int id);
        Task<EmployeesGetResult> Save(EmployeesSaveModel employeesSave);
        Task<EmployeesGetResult> Update(EmployeesUpdateModel employeesUpdate);
        Task<EmployeesUpdateModel> GetUpdateModelById(int id);
    }
}
