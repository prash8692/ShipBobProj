using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShipBobProject.Models
{
    public class OrderDetailsVm1
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