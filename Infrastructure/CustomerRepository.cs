using AlintaEnergy.Application.Abstractions.Repositries;
using AlintaEnergy.Core.DomainModel;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlintaEnergy.Infrastructure
{
    public class CustomerRepository : ICustomerRepositry
    {
        SampleInMemoryDbContext _sampleInMemoryDbContext;

        private readonly IMapper _mapper;

        public CustomerRepository(IServiceProvider services, IMapper mapper)
        {
            var scope = services.CreateScope();
            _sampleInMemoryDbContext = scope.ServiceProvider.GetRequiredService<SampleInMemoryDbContext>();

            _mapper = mapper;
        }
        public bool CreateCustomer(Customer customer)
        {
            var success = false;

            var entityModel = _mapper.Map<Model.Customer>(customer);    
            _sampleInMemoryDbContext.Add(entityModel);
            var numberOfItemsCreated = _sampleInMemoryDbContext.SaveChanges();
            if (numberOfItemsCreated == 1) success =  true;

            return success;
        }

        public IQueryable<Customer> GetAllCustomer()
        {
            var customers = from x in _sampleInMemoryDbContext.Customers
                            select x;
            return null;

        }

        public Customer GetCustomer(int id)
        {
            var customerEntityModel = (from x in _sampleInMemoryDbContext.Customers
                            where x.Id == id
                            select x).FirstOrDefault();

            var customerDomainModel = _mapper.Map<Customer>(customerEntityModel);

            return customerDomainModel;

        }

        public IQueryable<Customer> GetCustomerBySearchText(string searchText)
        {
            throw new NotImplementedException();
        }

        public bool RemoveCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
