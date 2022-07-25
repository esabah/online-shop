using AutoMapper;
using Common.MessageQueue.EventMessages;
using CustomerMicroservice.Business.Dtos;
using CustomerMicroservice.DataAccess.Entities;

namespace CustomerMicroservice.Business.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap(); 
            CreateMap<Customer, CustomerCreateEvent>().ReverseMap();
        }
    }
}
