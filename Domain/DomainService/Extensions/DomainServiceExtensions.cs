using DomainService.Abstrack;
using DomainService.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DomainService.Extensions
{
    public static class DomainServiceExtensions
    {
        public static IServiceCollection LoadDomainServiceExtension(this IServiceCollection services)
        {
            services.AddScoped<IAgentService, AgentService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IHotelService, HotelService>();
            services.AddScoped<IHotelOrderService, HotelOrderService>();
            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<IRotationService, RotationService>();
            services.AddScoped<ITourService, TourService>();
            services.AddScoped<ITourOrderService, TourOrderService>();
            services.AddScoped<ITransferOrderService, TransferOrderService>();
            services.AddScoped<IVehicleService, VehicleService>();

            return services;
        }
    }
}
