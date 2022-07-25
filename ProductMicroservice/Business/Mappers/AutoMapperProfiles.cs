using AutoMapper;
using Common.MessageQueue.EventMessages;
using ProductMicroservice.Business.Dtos;
using ProductMicroservice.DataAccess.Entities;

namespace ProductMicroservice.Business.Mappers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductCreateEvent>().ReverseMap();
        }
    }
}
