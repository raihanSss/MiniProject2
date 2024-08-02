using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject2.Interfaces;
using MiniProject2.Model;

namespace MiniProject2.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Membuat pesanan baru.
        /// </summary>
        /// <param name="order">Detail pesanan yang akan dibuat.</param>
        /// <returns>Detail pesanan yang dibuat.</returns>
        [HttpPost]
        public IActionResult PlaceOrder([FromBody] Order order)
        {
            try
            {
                var orderId = _orderService.PlaceOrder(order);
                var createdOrder = _orderService.DisplayOrderDetails(orderId);
                return Ok(createdOrder);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Mendapatkan status pesanan berdasarkan ID.
        /// </summary>
        /// <param name="id">ID pesanan.</param>
        /// <returns>Status pesanan.</returns>
        [HttpGet("{id}/status")]
        public IActionResult GetOrderStatus(int id)
        {
            try
            {
                var status = _orderService.GetOrderStatus(id);
                return Ok(new { Status = status });
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        /// Memperbarui status pesanan berdasarkan ID.
        /// </summary>
        /// <param name="id">ID pesanan yang akan diperbarui.</param>
        /// <param name="status">Status baru untuk pesanan.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>
        [HttpPut("{id}/status")]
        public IActionResult UpdateOrderStatus(int id, [FromBody] string status)
        {
            try
            {
                _orderService.UpdateOrderStatus(id, status);
                return Ok("Status order berhasil diperbarui");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Membatalkan pesanan berdasarkan ID.
        /// </summary>
        /// <param name="id">ID pesanan yang akan dibatalkan.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>
        [HttpPut("{id}/cancel")]
        public IActionResult CancelOrder(int id)
        {
            try
            {
                _orderService.CancelOrder(id);
                return Ok("Order berhasil dibatalkan");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
