using MiniProject2.Interfaces;
using MiniProject2.Model;
using System;
using System.Collections.Generic;
using System.Linq;

public class OrderService : IOrderService
{
    private readonly List<Order> _orders = new List<Order>();
    private readonly List<Customer> _customers;
    private readonly List<Menu> _menus;

    public OrderService(List<Customer> customers, List<Menu> menus)
    {
        _customers = customers;
        _menus = menus;
    }

    public int PlaceOrder(Order order)
    {

        order.OrderedMenus = new List<Menu>();

        foreach (var menuId in order.OrderedMenuIds)
        {
            var menuItem = _menus.FirstOrDefault(m => m.Id == menuId);
            if (menuItem == null || !menuItem.IsAvailable)
            {
                throw new Exception($"Menu item dengan ID {menuId} tidak tersedia");
            }
            order.OrderedMenus.Add(menuItem);
        }

        order.CalculateTotalOrder();
        order.OrderDate = DateTime.Now;
        order.OrderStatus = "Processed";
        order.Id = _orders.Count > 0 ? _orders.Max(o => o.Id) + 1 : 1;

        _orders.Add(order);
        return order.Id;
    }

    public Order DisplayOrderDetails(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            throw new Exception("Order tidak ditemukan");
        }
        return order;
    }

    public void CancelOrder(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            throw new Exception("Order tidak ditemukan");
        }
        order.OrderStatus = "Canceled";
    }

    public void UpdateOrderStatus(int orderId, string status)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            throw new Exception("Order tidak ditemukan");
        }
        order.OrderStatus = status;
    }

    public string GetOrderStatus(int orderId)
    {
        var order = _orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            throw new Exception("Order tidak ditemukan");
        }
        return order.OrderStatus;
    }
}

