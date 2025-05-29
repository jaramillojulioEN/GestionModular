using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Api.Application.Interfaces;
using Api.Infrastructure.Persistence;
using Api.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.Configuration;
using Api.Application.Services;
using Api.Application.UseCases;
using Api.Web.MappingProfiles;

namespace Api.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<AuthUseCases>();

            return services;
        }
    }
}
