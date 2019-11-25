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

        bool Update(CustomerDto customer);

        CustomerDto GetCustomer(int id);

    }
}
