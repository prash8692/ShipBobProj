
using ShipBobDataAccess.ViewModels;
using ShipBobDataAccess.Utilities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace ShipBobDataAccess
{
    public class OrderDataAccesss : ShipBobDataAccess, IOrderDataAccess
    {
        private List<OrderDetails> listOrder = new List<OrderDetails>();
        private Action<SqlDataReader> mapToOrderDetailsPOCO;

        public OrderDataAccesss()
        {
               mapToOrderDetailsPOCO = MapToOrderDetailsPOCO;
        }
        public List<OrderDetailsVm> GetOrders(string userId)
        {

            Dictionary<string, object> paramaters = new Dictionary<string, object>();
            paramaters.Add("@userId", userId);
            GetEntity("Select * from dbo.orders where userid=@userid;", paramaters, mapToOrderDetailsPOCO);
    
            return listOrder.AsQueryable().Select(Mapper.MaptoOrderDetailsVm).ToList();
        }

        public List<OrderDetailsVm> GetOrdersAll()
        {
            GetEntityAllOrders("Select * from dbo.orders;", mapToOrderDetailsPOCO);
            return listOrder.AsQueryable().Select(Mapper.MaptoOrderDetailsVm).ToList();
        }

        public void UpdateOrder(OrderDetails orderDetailsVm)
        {
            Dictionary<string, object> orderParams = new Dictionary<string, object>();

            orderParams.Add("@name", orderDetailsVm.name);
            orderParams.Add("@street", orderDetailsVm.street);
            orderParams.Add("@address", orderDetailsVm.address);
            orderParams.Add("@city", orderDetailsVm.city);
            orderParams.Add("@state", orderDetailsVm.state);
            orderParams.Add("@zipcode", orderDetailsVm.zipcode);
            orderParams.Add("@trackingId", orderDetailsVm.trackingId);
            ModifyEntity("update dbo.orders set Name=@name, Street=@street, Address=@address, City=@city, State=@state, ZipCode=@zipcode where TrackingId=@trackingId;",
                        orderParams);
        }

        public void DeleteOrder(string trackingId)
        {
            Dictionary<string, object> orderParams = new Dictionary<string, object>();
            orderParams.Add("@trackingId", trackingId);
            ModifyEntity("delete from orders where TrackingId=@trackingId;", orderParams);
        }

        public void CreateOrder(OrderDetails orderDetails)
        {
            Dictionary<string, object> orderParams = new Dictionary<string, object>();
            
            orderParams.Add("@trackingId", orderDetails.trackingId);
            orderParams.Add("@name", orderDetails.name);
            orderParams.Add("@street", orderDetails.street);
            orderParams.Add("@address", orderDetails.address);
            orderParams.Add("@city", orderDetails.city);
            orderParams.Add("@state", orderDetails.state);
            orderParams.Add("@zipcode", orderDetails.zipcode);
            orderParams.Add("@userid", orderDetails.userid);
            ModifyEntity("insert into dbo.orders (TrackingId, Name, Street, Address, City, State, ZipCode, userid) values(@trackingId, @name, @street, @address, @city, @state, @zipcode, @userid);", orderParams);
        }
 

        private void MapToOrderDetailsPOCO(SqlDataReader data)
        {
            OrderDetails ord = new OrderDetails();
            ord.trackingId = data["TrackingId"].ToString();
            ord.name = data["Name"].ToString();
            ord.street = data["Street"].ToString();
            ord.address = data["Address"].ToString();
            ord.city = data["city"].ToString();
            ord.state = data["State"].ToString();
            ord.zipcode = data["ZipCode"].ToString();
            listOrder.Add(ord);
        }

         

       
    }
}
