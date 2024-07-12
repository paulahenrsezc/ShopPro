using Microsoft.Extensions.DependencyInjection;
using ShopPro.Modules.Application.Interfaces;
using ShopPro.Modules.Application.Services;
using ShopPro.Modules.Domain.Interfaces;
using ShopPro.Modules.Persistence.Repositories;

namespace ShopPro.Modules.IOC.Dependencies
{
    public static class OrderDetailsDependency
    {
        public static void AddOrderDetailsDependency(this IServiceCollection service)
        {
            #region "Repositorios"
            service.AddScoped<IOrderDetailsRepository, OrderDetailsRepository>();
            #endregion

            #region "Services"
            service.AddTransient<IOrderDetailsService, OrderDetailsService>();
            #endregion
        }
    }
}
