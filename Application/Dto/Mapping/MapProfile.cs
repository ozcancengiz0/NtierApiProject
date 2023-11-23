using AutoMapper;
using DomainModel.Entities;

using Dto.Request.Agent;
using Dto.Request.Customer;
using Dto.Request.Hotel;
using Dto.Request.HotelOrder;
using Dto.Request.Manager;
using Dto.Request.Room;
using Dto.Request.Rotation;
using Dto.Request.Tour;
using Dto.Request.TourOrder;
using Dto.Request.Vehicle;

using Dto.Response.Agent;
using Dto.Response.Customer;
using Dto.Response.Hotel;
using Dto.Response.HotelOrder;
using Dto.Response.Manager;
using Dto.Response.Room;
using Dto.Response.Rotation;
using Dto.Response.Tour;
using Dto.Response.TourOrder;
using Dto.Response.Vecihle;

namespace Dto.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<AgentAddRequest, Agent>();
            CreateMap<Agent, AgentGetResponse>();
            CreateMap<AgentUpdateRequest, Agent>();

            CreateMap<CustomerAddRequest, Customer>();
            CreateMap<Customer, CustomerGetResponse>();
            CreateMap<CustomerUpdateRequest, Customer>();

            CreateMap<HotelAddRequest, Hotel>();
            CreateMap<Hotel, HotelGetResponse>();
            CreateMap<HotelUpdateRequest, Hotel>();
                
            CreateMap<HotelOrderAddRequest, HotelOrder>();
            CreateMap<HotelOrder, HotelOrderGetResponse>();
            CreateMap<HotelOrderUpdateRequest, HotelOrder>();

            CreateMap<ManagerAddRequest, Manager>();
            CreateMap<Manager, ManagerGetResponse>();
            CreateMap<ManagerUpdateRequest, Manager>();

            CreateMap<RoomAddRequest, Room>();
            CreateMap<Room, RoomGetResponse>();
            CreateMap<RoomUpdateRequest, Room>();

            CreateMap<RotationAddRequest, Rotation>();
            CreateMap<Rotation, RotationGetResponse>();
            CreateMap<RotationUpdateRequest, Rotation>();

            CreateMap<TourAddRequest, Tour>();
            CreateMap<Tour, TourGetResponse>();
            CreateMap<TourUpdateRequest, Tour>();

            CreateMap<TourOrderAddRequest, TourOrder>();
            CreateMap<TourOrder, TourOrderGetResponse>();
            CreateMap<TourOrderUpdateRequest, TourOrder>();

            CreateMap<TransferOrderAddRequest, TransferOrder>();
            CreateMap<TransferOrder, TransferGetResponse>();
            CreateMap<TransferOrderUpdateRequest, TransferOrder>();

            CreateMap<VehicleAddRequest, Vehicle>();
            CreateMap<Vehicle, VehicleGetResponse>();
            CreateMap<VehicleUpdateRequest, Vehicle>();
        }
    }
}
