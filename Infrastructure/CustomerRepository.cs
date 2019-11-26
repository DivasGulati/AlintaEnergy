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

            var customerDomainModel = (from x in _sampleInMemoryDbContext.Customers                                       
                                       select new Customer
                                       {
                                           Id = x.Id,
                                           FirstName = x.FirstName,
                                           LastName = x.LastName,
                                           DateOfBirth = x.DateOfBirth

                                       });

            return customerDomainModel;

        }

        public Customer GetCustomer(int id)
        {
            var customerEntityModel = (from x in _sampleInMemoryDbContext.Customers
                            where x.Id == id
                            select x).FirstOrDefault();

            var customerDomainModel = _mapper.Map<Customer>(customerEntityModel);

            return customerDomainModel;

        }

        public IQueryable<Customer> SearchCustomer(string searchText)
        {
            var customerDomainModel = (from x in _sampleInMemoryDbContext.Customers
                                       where x.FirstName.Contains(searchText, StringComparison.OrdinalIgnoreCase) || x.LastName.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                                       select new Customer
                                       {
                                           Id = x.Id,
                                           FirstName = x.FirstName,
                                           LastName = x.LastName,
                                           DateOfBirth = x.DateOfBirth

                                       });


            return customerDomainModel;
        }

        public bool RemoveCustomer(int id)
        {
            var success = false;

            var customerEntityModel = (from x in _sampleInMemoryDbContext.Customers
                                       where x.Id == id
                                       select x).FirstOrDefault();

            _sampleInMemoryDbContext.Customers.Remove(customerEntityModel);
            var numberOfItemsDeleted= _sampleInMemoryDbContext.SaveChanges();
            if (numberOfItemsDeleted == 1) success = true;

            return success;

        }

        public  bool UpdateCustomer(Customer customer)
        {
            _sampleInMemoryDbContext.Entry(_sampleInMemoryDbContext.Customers.FirstOrDefault(x => x.Id == customer.Id)).CurrentValues.SetValues(customer);
            return (_sampleInMemoryDbContext.SaveChanges()) > 0;
        }
    }
}
