using MiniProject2.Model;
using System.Collections;

namespace MiniProject2.Interfaces
{
    public interface ICustomerService
    {
        string AddCustomer(Customer customer);
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerById(int id);
        string UpdateCustomer(Customer customer);
        string DeleteCustomer(int id);
    }
}
