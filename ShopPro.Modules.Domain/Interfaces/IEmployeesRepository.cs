using ShopPro.Common.Data.Repository;

namespace ShopPro.Modules.Domain.Interfaces
{
    public interface IEmployeesRepository : IBaseRepository<Entities.Employees, int>
    {
        List<Modules.Domain.Entities.Employees> GetEmployeesById(int empid);
    }
}
