using MiniProject2.Interfaces;
using MiniProject2.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniProject2.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public CustomerService(List<Customer> customers)
        {
            _customers = customers;
        }

        public string AddCustomer(Customer customer)
        {
            customer.CustomerId = _customers.Count > 0 ? _customers.Max(c => c.CustomerId) + 1 : 1;
            customer.RegistrationDate = DateTime.Now;
            _customers.Add(customer);
            return "Data customer berhasil ditambah";
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customers;
        }

        public Customer GetCustomerById(int id)
        {
            return _customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public string UpdateCustomer(Customer customer)
        {
            var existingCustomer = _customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
            if (existingCustomer != null)
            {
                existingCustomer.CustomerName = customer.CustomerName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Address = customer.Address;
                return "Data customer berhasil di update";
            }
            return "Customer tidak ditemukan";
        }

        public string DeleteCustomer(int id)
        {
            var customer = _customers.FirstOrDefault(c => c.CustomerId == id);
            if (customer != null)
            {
                _customers.Remove(customer);
                return "Customer berhasil dihapus";
            }
            return "Customer tidak ditemukan";
        }
    }
}