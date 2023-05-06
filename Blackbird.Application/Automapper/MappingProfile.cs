using AutoMapper;
using Blackbird.Application.Dtos;
using Blackbird.Domain.Entities;

namespace Blackbird.Application.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
        }
    }
}
