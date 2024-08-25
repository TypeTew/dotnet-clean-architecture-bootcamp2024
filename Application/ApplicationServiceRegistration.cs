﻿using Application.Profiles;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application {
    public static class ApplicationServiceRegistration {
        public static IServiceCollection AddApplicationService(this IServiceCollection services) {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddAutoMapper(cfg => cfg.AddProfileRegistration());

            return services;
        }

        public static IMapperConfigurationExpression AddProfileRegistration(this IMapperConfigurationExpression mapper) {
            mapper.AddProfile<CategoryProfile>();
            mapper.AddProfile<BlogPostsProfile>();
            mapper.AddProfile<BlogImageProfile>();
            return mapper;
        }
    }
}
