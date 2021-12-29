using Application.Facade;
using Application.Interface;
using Business.Interfaces.Repository;
using Business.Interfaces.Services;
using Business.ServicesImplementations;
using Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Configuration.DependencyInjectionConfig
{
    public static class DependencyInjection
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPhoneNumberTypeRepository, PhoneNumberTypeRepository>();
            services.AddScoped<IPersonPhoneRepository, PersonPhoneRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPhoneNumberTypeService, PhoneNumberTypeService>();
            services.AddScoped<IPhoneNumberTypeFacade, PhoneNumberTypeFacade>();

            return services;
        }
    }
}
