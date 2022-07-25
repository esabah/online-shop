using AutoMapper;
using Common.MessageQueue.EventMessages;
using OrderMicroservice.Business.Commands.CreateCustomer;
using OrderMicroservice.Business.Commands.CreateOrder;
using OrderMicroservice.Business.Commands.CreateOrderView;
using OrderMicroservice.Business.Commands.CreateProduct;
using OrderMicroservice.Business.Dtos;
using OrderMicroservice.DataAccess.Entities;

namespace OrderMicroservice.Business.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Order, CreateOrderCommand>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailDto>().ReverseMap();

            CreateMap<Order, OrderCreateEvent>().ReverseMap();

            CreateMap<CustomerView, OrderCreateEvent>()
           .ForMember(d => d.CustomerEmail, o => o.MapFrom(s => s.Email))
           .ForMember(d => d.CustomerName, o => o.MapFrom(s => s.Name))
           .ForMember(d => d.CustomerSurName, o => o.MapFrom(s => s.Surname))
           .ForMember(d => d.CustomerPhoneNumber, o => o.MapFrom(s => s.PhoneNumber));

            CreateMap<OrderDetail, OrderDetailCreateEvent>().ReverseMap();

            CreateMap<CreateCustomerCommand, CustomerCreateEvent>().ReverseMap();
            CreateMap<CreateProductCommand, ProductCreateEvent>().ReverseMap();
            CreateMap<CreateOrderViewCommand, OrderCreateEvent>().ReverseMap();
            CreateMap<OrderDetailView, OrderDetailCreateEvent>().ReverseMap();




        }
    }
}
