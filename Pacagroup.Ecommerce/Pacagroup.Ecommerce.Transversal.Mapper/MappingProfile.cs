using AutoMapper;
using System;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Domain.Entity;

namespace Pacagroup.Ecommerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customers, CustomersDto>().ReverseMap();     
            CreateMap<Users,UsersDTO>().ReverseMap();
        }
    }
}
