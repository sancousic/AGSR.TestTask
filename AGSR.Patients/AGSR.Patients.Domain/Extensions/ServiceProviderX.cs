using AGSR.Patients.Domain.Context;
using Microsoft.Extensions.DependencyInjection;

namespace AGSR.Patients.Domain.Extensions
{
    public static class ServiceProviderX
    {
        public static void AddConfigDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ConfigContext>();
        }
    }
}
