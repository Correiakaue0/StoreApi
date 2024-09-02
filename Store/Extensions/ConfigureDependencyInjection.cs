using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infra;
using Infra.Repositories;
using Service.Services;

namespace Store.Extensions
{
    public static class ConfigureDependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //Dependency Injection Service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<IProductService, ProductService>();

            //Dependency Injection Repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            //Dependency Injection SqlContext
            services.AddScoped<Context, Context>();

            return services;
        }
    }
}