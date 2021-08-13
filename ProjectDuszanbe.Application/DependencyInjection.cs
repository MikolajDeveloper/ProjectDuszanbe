using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ProjectDuszanbe.Application.Interfaces;
using ProjectDuszanbe.Application.Services;

namespace ProjectDuszanbe.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ILanguageService, LanguageService>();
            services.AddScoped<ITranslationService, TranslationService>();
            return services;
        }
    }
}