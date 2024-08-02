using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniProject2.Interfaces;
using MiniProject2.Model;

namespace MiniProject2.Controllers
{
    [Route("api/menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        /// <summary>
        /// Menambahkan menu baru.
        /// </summary>
        /// <param name="menu">Detail menu yang akan ditambahkan.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>
        [HttpPost]
        public IActionResult AddMenu(Menu menu)
        {
            _menuService.AddMenu(menu);
            return Ok("Data menu Berhasil ditambah");
            
        }

        /// <summary>
        /// Mendapatkan semua menu.
        /// </summary>
        /// <returns>Daftar semua menu.</returns>

        [HttpGet]
        public IEnumerable<Menu> GetAllMenu()
        {
            return _menuService.GetAllMenu();
        }

        /// <summary>
        /// Mendapatkan menu berdasarkan ID.
        /// </summary>
        /// <param name="id">ID menu.</param>
        /// <returns>Detail menu jika ditemukan.</returns>
        [HttpGet("{id}")]
        public IActionResult GetMenuById(int id)
        {
            var menu = _menuService.GetMenuById(id);
            if (menu == null)
            {
                return NotFound("Tidak ditemukan");
            }
            return Ok(menu);
        }

        /// <summary>
        /// Memperbarui menu berdasarkan ID.
        /// </summary>
        /// <param name="id">ID menu yang akan diperbarui.</param>
        /// <param name="menu">Detail menu yang diperbarui.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>

        [HttpPut("{id}")]
        public IActionResult UpdateMenu(int id, Menu menu)
        {
            menu.Id = id;
            var result = _menuService.UpdateMenu(menu);
            if (result == "Menu tidak ditemukan")
            {
                return NotFound(result);
            }
            return Ok(result);
        }

        /// <summary>
        /// Menghapus menu berdasarkan ID.
        /// </summary>
        /// <param name="id">ID menu yang akan dihapus.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMenu(int id)
        {
            var result = _menuService.DeleteMenu(id);
            if (result == "Menu tidak ditemukan")
            {
                return NotFound(result);
            }
            return Ok("berhasil di hapus");
        }

        /// <summary>
        /// Menambahkan rating pada menu berdasarkan ID.
        /// </summary>
        /// <param name="id">ID menu yang akan diberi rating.</param>
        /// <param name="rating">Rating yang akan ditambahkan.</param>
        /// <returns>Pesan yang menunjukkan hasil operasi.</returns>
        [HttpPost("{id}/rating")]
        public IActionResult AddRating(int id, [FromBody] int rating)
        {
            var result = _menuService.AddRating(id, rating);
            if (result == "Menu tidak ditemukan")
            {
                return NotFound(result);
            }
            return Ok(result);
        }

    }
}
