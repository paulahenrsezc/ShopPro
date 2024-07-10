using ShopPro.Modules.Domain.Entities;
using ShopPro.Modules.Domain.Interfaces;
using System.Linq.Expressions;

namespace ShopPro.Modules.Persistence.Repositories
{
    internal class EmployeesRepository : IEmployeesRepository
    {
        public bool Exist(Expression<Func<Employees, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Employees> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Employees> GetEmployees(int employeesId)
        {
            throw new NotImplementedException();
        }

        public Employees GetEntityBy(int Id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Employees entity)
        {
            throw new NotImplementedException();
        }

        public void Save(Employees entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Employees entity)
        {
            throw new NotImplementedException();
        }
    }
}
