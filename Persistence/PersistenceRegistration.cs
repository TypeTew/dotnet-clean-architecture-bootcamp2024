using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.DatabaseContext;
using Persistence.Repositories;

namespace Persistence {
    public static class PersistenceRegistration {
        public static IServiceCollection AddPersistenceService(this IServiceCollection services, string connection) {


            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBlogPostRepository, BlogPostRepository>();
            services.AddScoped<IBlogImageRepository, BlogImageRepository>();
            //AddScoped => 1 Request => จะถูกสร้างขึ้นมาแล้วส่งจะหายไป
            //Signleton run service จะอยู่ตลอด
            //Transient ถูกสร้างใหม่ทุกครั้ง

            return services;
        }
    }
}
