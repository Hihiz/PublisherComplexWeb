using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PublisherComplexWeb.Application.Dto.Device;
using PublisherComplexWeb.Application.Dto.Format;
using PublisherComplexWeb.Application.Dto.Material;
using PublisherComplexWeb.Application.Dto.Order;
using PublisherComplexWeb.Application.Dto.TypeWork;
using PublisherComplexWeb.Application.Dto.Work;
using PublisherComplexWeb.Application.Interfaces;
using PublisherComplexWeb.Application.Services;
using PublisherComplexWeb.Application.Validations;
using PublisherComplexWeb.Application.Validations.FluentValidations.Device;
using PublisherComplexWeb.Application.Validations.FluentValidations.Format;
using PublisherComplexWeb.Application.Validations.FluentValidations.Material;
using PublisherComplexWeb.Application.Validations.FluentValidations.Order;
using PublisherComplexWeb.Application.Validations.FluentValidations.TypeWork;
using PublisherComplexWeb.Application.Validations.FluentValidations.Work;
using PublisherComplexWeb.Domain.Entities;
using System.Reflection;

namespace PublisherComplexWeb.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddValidatorsFromAssemblies(new[] { Assembly.GetExecutingAssembly() });

            services.ServicesInit();
            services.ValidatorsDtoInit();
            services.FluentValidatorInit();

            return services;
        }

        private static void ServicesInit(this IServiceCollection services)
        {
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddScoped<IFormatService, FormatService>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ITypeWorkService, TypeWorkService>();
            services.AddScoped<IWorkService, WorkService>();
            services.AddScoped<IUserService<OrderDto>, UserService>();
        }

        private static void ValidatorsDtoInit(this IServiceCollection services)
        {
            services.AddScoped<IValidatorDto<Device>, DeviceValidator>();
            services.AddScoped<IValidatorDto<Format>, FormatValidator>();
            services.AddScoped<IValidatorDto<Material>, MaterialValidator>();
            services.AddScoped<IValidatorDto<TypeWork>, TypeWorkValidator>();
        }

        private static void FluentValidatorInit(this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateDeviceDto>, CreateDeviceValidator>();
            services.AddScoped<IValidator<UpdateDeviceDto>, UpdateDeviceValidator>();

            services.AddScoped<IValidator<CreateFormatDto>, CreateFormatValidator>();
            services.AddScoped<IValidator<UpdateFormatDto>, UpdateFormatValidator>();

            services.AddScoped<IValidator<CreateMaterialDto>, CreateMaterialValidator>();
            services.AddScoped<IValidator<UpdateMaterialDto>, UpdateMaterialValidator>();

            services.AddScoped<IValidator<CreateOrderDto>, CreateOrderValidator>();
            services.AddScoped<IValidator<UpdateOrderDto>, UpdateOrderValidator>();

            services.AddScoped<IValidator<CreateTypeWorkDto>, CreateTypeWorkValidator>();
            services.AddScoped<IValidator<UpdateTypeWorkDto>, UpdateTypeWorkValidator>();

            services.AddScoped<IValidator<CreateWorkDto>, CreateWorkValidator>();
            services.AddScoped<IValidator<UpdateWorkDto>, UpdateWorkValidator>();
        }
    }
}
