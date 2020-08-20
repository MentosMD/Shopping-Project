using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ShoppingOnline.Models;
using ShoppingOnline.Repository;
using ShoppingOnline.Repository.ProductRepository;
using ShoppingOnline.Repository.ProfileRepository;
using ShoppingOnline.Repository.UserRepository;
using ShoppingOnline.Services;
using ShoppingOnline.Services.ProductService;
using ShoppingOnline.Services.ProfileService;

namespace ShoppingOnline.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void LoadAllServices(this IServiceCollection services)
        {
            services.AddCors();
            services.AddRepositories();
            services.AddServices();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<IProductService, ProductService>();
        }
    }
}