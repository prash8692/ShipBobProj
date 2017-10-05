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
    public class UserDataAccess : ShipBobDataAccess, IUserDataAccess
    {
        private Action<SqlDataReader> mapUserToPOCO;
        private List<UserDetails> list = new List<UserDetails>();
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

            GetEntity("Select * from dbo.users2", null, mapUserToPOCO);
            return list.AsQueryable().Select(Mapper.MaptoUserDetailsVm).ToList();
        }

        private void MapUserToPOCO(SqlDataReader data)
        {
            UserDetails urs = new UserDetails();
            urs.firstName = data["firstname"].ToString();
            urs.lastName = data["lastname"].ToString();
            urs.userId = data["userid"].ToString();
            list.Add(urs);
        }

    }
}
