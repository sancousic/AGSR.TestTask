using AGSR.Patients.Domain.Context;
using AGSR.Patients.Domain.Repositories;
using AGSR.Patients.Domain.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace AGSR.Patients.Domain.Extensions
{
    public static class ServiceProviderX
    {
        public static void AddConfigDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ConfigContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IPatientRepository, PatientRepository>();
        }
    }
}
