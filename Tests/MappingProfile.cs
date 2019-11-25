using AlintaEnergy.Application.Dto;
using AutoMapper;
using EF = AlintaEnergy.Infrastructure.Model;

namespace AlintaEnergy.IntergrationTests
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CustomerDto, Core.DomainModel.Customer>();
            CreateMap<Core.DomainModel.Customer, CustomerDto>();

            CreateMap<AlintaEnergy.Core.DomainModel.Customer, EF.Customer>();
            CreateMap<EF.Customer, Core.DomainModel.Customer>();
        }
    }
}
