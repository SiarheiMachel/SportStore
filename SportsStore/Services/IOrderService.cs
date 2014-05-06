using SportsStore.Web.Models;

namespace SportsStore.Web.Services
{
    public interface IOrderService
    {
        void ProcessOrder(Cart cart, ShippingDetailsModel shippingDetails);
    }
}
