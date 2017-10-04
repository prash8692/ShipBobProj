using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipBobDataAccess.ViewModels
{
    public class OrderDetails
    {
        public string trackingId { get; set; }
        public string name { get; set; }
        public string street { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set;  }
        public string zipcode { get; set; }
        public string userid { get; set; }
    }
}