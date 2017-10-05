using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShipBobProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Configuration;
using ShipBobApp.Models;
using ShipBobDataAccess;
using ShipBobDataAccess.ViewModels;

namespace ShipBobApp.Controllers
{
    public class OrderController : Controller
    {
        private OrderDataAccesss _ordDataAccess;
        public OrderController()
        {
            _ordDataAccess = new OrderDataAccesss();
        }
        
        public JsonResult GetOrder(UserDetails userDetails)
        {
            return Json(_ordDataAccess.GetOrders(userDetails.userId));
            
        }
        public void UpdateOrder(OrderDetails orderDetails)
        {

            _ordDataAccess.UpdateOrder(orderDetails);
        }

        public void CretaeOrder(OrderDetails orderDetails)
        {
            _ordDataAccess.CreateOrder(orderDetails);
            
        }

        public void DeleteOrder(string trackingId)
        {
            _ordDataAccess.DeleteOrder(trackingId);
            
        }
        
        public JsonResult GetAllOrders()
        {
            return Json(_ordDataAccess.GetOrdersAll(), JsonRequestBehavior.AllowGet) ;
        }



    }
}