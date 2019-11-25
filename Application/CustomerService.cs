using AlintaEnergy.Application.Abstractions.Repositries;
using AlintaEnergy.Application.Abstractions.Services;
using AlintaEnergy.Application.Dto;
using AlintaEnergy.Core.DomainModel;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlintaEnergy.Application
{
    public class CustomerService : ICustomerService
    {
        ICustomerRepositry _customerRepo;

        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepositry customerRepo, IMapper mapper)
        {
            _customerRepo = customerRepo;
            _mapper = mapper;
        }

        public bool CreateCustomer(CustomerDto customer)
        {    
           var domainModel = _mapper.Map<CustomerDto,Customer>(customer);            
            _customerRepo.CreateCustomer(domainModel);
            return true;
        }

        public IEnumerable<CustomerDto> GetAllCustomer()
        {
            throw new NotImplementedException();
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerDTO = _mapper.Map<CustomerDto>(customer);
            return customerDTO;


        }

        public IEnumerable<CustomerDto> GetCustomerBySearchText(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer(int id)
        {
            throw new NotImplementedException();
        }
    }
}
