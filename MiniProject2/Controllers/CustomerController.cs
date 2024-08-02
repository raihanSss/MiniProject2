using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject2.Interfaces;
using MiniProject2.Model;
using MiniProject2.Services;

namespace MiniProject2.Controllers
{
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Menambahkan pelanggan baru.
        /// </summary>
        /// <param name="customer">Detail pelanggan yang akan ditambahkan.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>

        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            var result = _customerService.AddCustomer(customer);
            return Ok(result);
        }

        /// <summary>
        /// Mendapatkan semua pelanggan.
        /// </summary>
        /// <returns>Daftar semua pelanggan.</returns>
        [HttpGet]
        public IEnumerable<Customer> GetAllCustomer()
        {
            return _customerService.GetAllCustomer();
        }

        /// <summary>
        /// Mendapatkan pelanggan berdasarkan ID.
        /// </summary>
        /// <param name="id">ID pelanggan.</param>
        /// <returns>Detail pelanggan jika ditemukan.</returns>
        [HttpGet("{CustomerId}")]
        public IActionResult GetCustomerById(int CustomerId)
        {
            var customer = _customerService.GetCustomerById(CustomerId);
            if (customer == null)
            {
                return NotFound("Customer tidak ditemukan");
            }
            return Ok(customer);
        }

        /// <summary>
        /// Memperbarui pelanggan berdasarkan ID.
        /// </summary>
        /// <param name="id">ID pelanggan yang akan diperbarui.</param>
        /// <param name="customer">Detail pelanggan yang diperbarui.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>

        [HttpPut("{CustomerId}")]
        public IActionResult UpdateCustomer(int CustomerId, Customer customer)
        {
            customer.CustomerId = CustomerId;
            var result = _customerService.UpdateCustomer(customer);
            if (result == "Customer tidak ditemukan")
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Menghapus pelanggan berdasarkan ID.
        /// </summary>
        /// <param name="id">ID pelanggan yang akan dihapus.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>

        [HttpDelete("{CustomerId}")]
        public IActionResult DeleteCustomer(int CustomerId)
        {
            var result = _customerService.DeleteCustomer(CustomerId);
            if (result == "Customer tidak ditemukan")
            {
                return NotFound(result);
            }
            return Ok("berhasil di hapus");
        }
    }
}