using AlintaEnergy.Application.Abstractions.Repositries;
using AlintaEnergy.Application.Abstractions.Services;
using AlintaEnergy.Application.Dto;
using AlintaEnergy.Core.DomainModel;
using AutoMapper;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AlintaEnergy.Application
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepositry _customerRepo;
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
            var results = _customerRepo.GetAllCustomer().ToList();
            var customers = _mapper.Map<List<CustomerDto>>(results);
            return customers;
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _customerRepo.GetCustomer(id);
            var customerDTO = _mapper.Map<CustomerDto>(customer);
            return customerDTO;
        }

        public IEnumerable<CustomerDto> SearchCustomer(string searchText)
        {
            var results = _customerRepo.SearchCustomer(searchText).ToList();
            var customers = _mapper.Map<List<CustomerDto>>(results);
            return customers;

        }

        public bool RemoveCustomer(int id)
        {
            var retVal = _customerRepo.RemoveCustomer(id);
            return retVal;
        }

        public bool Update(CustomerDto customer)
        {
            var domainModel = _mapper.Map<CustomerDto, Customer>(customer);
           var retVal =  _customerRepo.UpdateCustomer(domainModel);
            return retVal;
        }
    }
}
