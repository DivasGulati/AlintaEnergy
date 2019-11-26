using AlintaEnergy.Application;
using AlintaEnergy.Application.Abstractions.Repositries;
using AlintaEnergy.Application.Abstractions.Services;
using AlintaEnergy.Application.Dto;
using AlintaEnergy.Infrastructure;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlintaEnergy.IntergrationTests
{
    public class BaseTest
    {
        protected ServiceProvider _serviceProvider;

        public BaseTest()
        {
            _serviceProvider = ConfigureServices();

            Initialize();
        }

        protected ServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddSingleton<ICustomerRepositry, CustomerRepository>();

            services.AddDbContext<SampleInMemoryDbContext>(options =>
               options.UseInMemoryDatabase("CustomerDB"));


            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services.BuildServiceProvider();

        }

        public void Initialize()
        {
            var customerService = _serviceProvider.GetService<ICustomerService>();

            var john = new CustomerDto()
            {
                FirstName = "John",
                LastName = "Martin",
                DateOfBirth = new DateTime(1975, 1, 1)
            };



            var ryan = new CustomerDto()
            {
                FirstName = "Ryan",
                LastName = "Vilton",
                DateOfBirth = new DateTime(1979, 1, 1)
            };


            var roy = new CustomerDto()
            {
                FirstName = "Roy",
                LastName = "Vilton",
                DateOfBirth = new DateTime(1999, 10, 1)
            };

            var rick = new CustomerDto()
            {
                FirstName = "Ricky",
                LastName = "Martin",
                DateOfBirth = new DateTime(1975, 1, 1)
            };

            customerService.CreateCustomer(john);
            customerService.CreateCustomer(ryan);
            customerService.CreateCustomer(roy);
            customerService.CreateCustomer(rick);

        }
    }
}
