using ShipBobDataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShipBobDataAccess.Utilities;

namespace ShipBobDataAccess
{
    public class UserDataAccess : ShipBobDataAccess
    {
        private Action<SqlDataReader> mapUserToPOCO;
        private List<UserDetailsVm> list = new List<UserDetailsVm>();
        public UserDataAccess()
        {
            mapUserToPOCO = MapUserToPOCO;
        }
        public void CreateUser(UserDetails userDetails)
        {
            Dictionary<string, object> newUserData =new Dictionary<string, object>();
            newUserData.Add("@firstname", userDetails.firstName);
            newUserData.Add("@lastname", userDetails.lastName);
            ModifyEntity("insert into dbo.users2(firstname, lastname) values(@firstname,@lastname);", newUserData);
        }

        public List<UserDetailsVm> ViewUser()
        {

            list = GetEntityAll("Select * from dbo.users2");
            return list;
        }

        private void MapUserToPOCO(SqlDataReader data)
        {
            UserDetailsVm urs = new UserDetailsVm();
            urs.firstName = data["firstname"].ToString();
            urs.lastName = data["lastname"].ToString();
            urs.userId = data["userid"].ToString();
            list.Add(urs);
        }

    }
}
