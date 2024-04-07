using AutoMapper;

namespace PublisherComplexWeb.CQRS.Application.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Order, UpdateOrderCommand>().ReverseMap();
            CreateMap<Order, CreateOrderCommand>().ReverseMap();

        }
    }
}
