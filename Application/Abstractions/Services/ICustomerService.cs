using AlintaEnergy.Application.Dto;
using System.Collections.Generic;

namespace AlintaEnergy.Application.Abstractions.Services
{
    public interface ICustomerService
    {
        IEnumerable<CustomerDto> GetAllCustomer();
        bool CreateCustomer(CustomerDto customer);
        bool RemoveCustomer(int id);
        IEnumerable<CustomerDto> GetCustomerBySearchText(string searchText);

        CustomerDto GetCustomer(int id);

    }
}
