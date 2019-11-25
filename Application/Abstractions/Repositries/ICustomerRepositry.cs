using AlintaEnergy.Core.DomainModel;
using System.Collections.Generic;
using System.Linq;

namespace AlintaEnergy.Application.Abstractions.Repositries
{
    public interface ICustomerRepositry
    {
        IQueryable<Customer> GetAllCustomer();
        bool CreateCustomer(Customer customer);
        bool RemoveCustomer(int id);

        bool UpdateCustomer(Customer customer);

        Customer GetCustomer(int id);
        IQueryable<Customer> GetCustomerBySearchText(string searchText);
        
    }
}
