

using ShipBobDataAccess.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShipBobDataAccess
{
    public interface IUserDataAccess
    {
        void CreateUser(UserDetails userDetails);
        List<UserDetailsVm> ViewUser();
        
    }
}
