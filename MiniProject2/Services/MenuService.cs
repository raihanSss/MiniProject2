using System;
using System.Collections.Generic;
using System.Linq;
using MiniProject2.Interfaces;
using MiniProject2.Model;



namespace MiniProject2.Services
{
    public class MenuService : IMenuService
    {
        private readonly List<Menu> _menus = new List<Menu>();

        public MenuService(List<Menu> menus)
        {
            _menus = menus;
        }

        public string AddMenu(Menu menu)
        {
            menu.Id = _menus.Count > 0 ? _menus.Max(m => m.Id) + 1 : 1;
            menu.CreatedDate = DateTime.Now;
            menu.Rating = 0;
            menu.IsAvailable = true;
            _menus.Add(menu);
            return "Data menu berhasil ditambah";
        }

        public IEnumerable<Menu> GetAllMenu()
        {
            return _menus;
        }

        public Menu GetMenuById(int id)
        {
            return _menus.FirstOrDefault(m => m.Id == id);
        }

        public string UpdateMenu(Menu menu)
        {
            var existingMenu = _menus.FirstOrDefault(m => m.Id == menu.Id);
            if (existingMenu != null)
            {
                existingMenu.Name = menu.Name;
                existingMenu.Price = menu.Price;
                existingMenu.Category = menu.Category;
                existingMenu.IsAvailable = menu.IsAvailable;
                return "Data menu berhasil di update";
            }
            return "Menu tidak ditemukan";
        }

        public string DeleteMenu(int id)
        {
            var menu = _menus.FirstOrDefault(m => m.Id == id);
            if (menu != null)
            {
                _menus.Remove(menu);
                return "Menu berhasil dihapus";
            }
            return "Menu tidak ditemukan";
        }

        public string AddRating(int id, int rating)
        {
            var menu = _menus.FirstOrDefault(m => m.Id == id);
            if (menu != null)
            {
                if (menu.Rating == 0)
                {
                    menu.Rating = rating;
                }
                else
                {
                    menu.Rating = (menu.Rating + rating) / 2;
                }
                return "Rating berhasil ditambah";
            }
            return "Menu tidak ditemukan";
        }
    }
}