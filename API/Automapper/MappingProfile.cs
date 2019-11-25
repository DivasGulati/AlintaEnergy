using AlintaEnergy.Application.Dto;
using AlintaEnergy.Core.DomainModel;
using AutoMapper;
using System.Linq;
using EF = AlintaEnergy.Infrastructure.Model;

namespace AlintaEnergy.API.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CustomerDto, Customer>();
            CreateMap<Customer, CustomerDto>();

            CreateMap<Customer, EF.Customer>();
            CreateMap<EF.Customer, Customer>();
        }
    }
}
