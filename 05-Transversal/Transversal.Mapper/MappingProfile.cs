using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domain.Entity;
using Application.DTO;

namespace Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Cuando el mapeo entre la entidad y el DTO son iguales
            CreateMap<Customers, CustomersDto>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();

            //Cuando el mapeo se hace campo por campo entre la entidad y el DTO porque no coinciden se realiza por expresion lambda 
            //CreateMap<Customers, CustomerDto>().ReverseMap()
            //    .ForMember(destination => destination.CustomerId, source => source.MapFrom(src => src.CustomerId))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
            //    .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
            //    .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
            //    .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
            //    .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
            //    .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
            //    .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
            //    .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
            //    .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
            //    .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax)).ReverseMap();
        }
    }
}
