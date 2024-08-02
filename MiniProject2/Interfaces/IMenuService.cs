using MiniProject2.Model;
using System.Collections.Generic;

namespace MiniProject2.Interfaces
{
    public interface IMenuService
    {
        string AddMenu(Menu menu);
        IEnumerable<Menu> GetAllMenu();
        Menu GetMenuById(int id);
        string UpdateMenu(Menu menu);
        string DeleteMenu(int id);
        string AddRating(int id, int rating);
    }
}
