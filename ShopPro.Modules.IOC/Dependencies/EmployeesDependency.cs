using Microsoft.Extensions.DependencyInjection;
using ShopPro.Modules.Application.Interfaces;
using ShopPro.Modules.Domain.Interfaces;
using ShopPro.Modules.Persistence.Repositories;
using ShopPro.Modules.Application.Services;

namespace ShopPro.Modules.IOC.Dependencies
{
    public static class EmployeesDependency
    {
        public static void AddEmployeesDependency(this IServiceCollection service)
        {
            #region "Repositorios"
            service.AddScoped<IEmployeesRepository, EmployeesRepository>();
            #endregion

            #region "Services"
            service.AddTransient<IEmployeesService, EmployeesService>();
            #endregion
        }
    }
}
