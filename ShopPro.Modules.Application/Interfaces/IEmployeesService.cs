using ShopPro.Modules.Application.Core;
using ShopPro.Modules.Application.Dtos.Employees;

namespace ShopPro.Modules.Application.Interfaces
{
    public interface IEmployeesService
    {
        ServiceResult GetEmployees();
        ServiceResult GetEmployees(int id);
        ServiceResult UpdateEmployees(EmployeesUpdateDto employeesUpdate);
        ServiceResult RemoveEmployees(EmployeesRemoveDto employeesRemove);
        ServiceResult SaveEmployees(EmployeesSaveDto employeesSave);

    }
}
