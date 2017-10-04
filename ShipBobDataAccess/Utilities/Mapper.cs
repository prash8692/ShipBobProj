using ShipBobDataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShipBobDataAccess.Utilities
{
    public static class Mapper
    {
        public static Expression<Func<OrderDetails, OrderDetailsVm>> MaptoOrderDetailsVm = order =>
           new OrderDetailsVm
           {
               trackingId = order.trackingId,
               name = order.name,
               street = order.street,
               address = order.address,
               city = order.city,
               state = order.state,
               userid = order.userid,
               zipcode = order.zipcode
           };


        public static Expression<Func<UserDetails, UserDetailsVm>> MaptoUserDetailsVm = user =>
                new UserDetailsVm
                {
                    firstName = user.firstName,
                    lastName = user.lastName,
                    userId = user.userId

                };
    }
}

