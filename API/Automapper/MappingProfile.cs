using AlintaEnergy.Application.Dto;
using AlintaEnergy.Core.DomainModel;
using AutoMapper;
using EF = AlintaEnergy.Infrastructure.Model;

namespace AlintaEnergy.API.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CustomerDto, Customer>().ForMember(dst => dst.Id, act => act.Ignore());
            CreateMap<Customer, CustomerDto>();

            CreateMap<Customer, EF.Customer>();
            CreateMap<EF.Customer, Customer>();
        }
    }
}
