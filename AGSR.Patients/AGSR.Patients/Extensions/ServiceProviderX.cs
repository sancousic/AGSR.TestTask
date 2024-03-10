using AGSR.Patients.Services;
using AGSR.Patients.Services.Implementations;
using AGSR.Patients.Validators;
using AutoMapper;
using FluentValidation;
using System.Reflection;
using PatientEntity = AGSR.Patients.Domain.Entities.Patient;

namespace AGSR.Patients.Extensions
{
    public static class ServiceProviderX
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPatientService, PatientService>();
            services.AddAutoMapperProfiles();
            services.AddValidators();
        }

        public static void AddAutoMapperProfiles(this IServiceCollection services)
        {
            var domainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            var definedTypes = domainAssemblies
                .Where(a => a.DefinedTypes.Any(t => typeof(Profile).GetTypeInfo().IsAssignableFrom(t)))
                .SelectMany(a => a.DefinedTypes).Distinct().ToList();

            var assemblies = definedTypes.Select(t => t.Assembly).Distinct();
            services.AddAutoMapper(assemblies);
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining(typeof(SearchByDateRequestValidator), includeInternalTypes: true);
        }
    }
}
