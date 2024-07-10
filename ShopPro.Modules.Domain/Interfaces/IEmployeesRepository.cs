using ShopPro.Common.Data.Repository;

namespace ShopPro.Modules.Domain.Interfaces
{
    public interface IEmployeesRepository : IBaseRepository<Domain.Entities.Employees, int>
    {
        List<Modules.Domain.Entities.Employees> GetEmployees(int employeesId);
    }
}
