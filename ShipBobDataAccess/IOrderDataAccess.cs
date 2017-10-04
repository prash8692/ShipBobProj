using ShipBobDataAccess.ViewModels;
using System.Collections.Generic;

namespace ShipBobDataAccess
{
    internal interface IOrderDataAccess
    {
        List<OrderDetailsVm> GetOrders(string userId);
        void UpdateOrder(OrderDetails orderDetailsVm);

    }
}