using MiniProject2.Model;

namespace MiniProject2.Interfaces
{
    public interface IOrderService
    {
        int PlaceOrder(Order order);
        Order DisplayOrderDetails(int orderId);
        void CancelOrder(int orderId);
        void UpdateOrderStatus(int orderId, string status);
        string GetOrderStatus(int orderId);
    }
}
