using ShopPro.Web.Interfaces;
using ShopPro.Web.Services;

namespace ShopPro.Web
{
    public static class Dependencies
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            #region "HttClient"
            service.AddHttpClient<IOrderDetailsService, OrderDetailsService>();
            service.AddHttpClient<IEmployeesService, EmployeesService>();
            #endregion

            #region "AddScope"
            service.AddScoped<IOrderDetailsService, OrderDetailsService>();
            service.AddScoped<IEmployeesService, EmployeesService>();
            #endregion

        }
    }
}
