using ShipBobDataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShipBobDataAccess
{
    public interface IShipBobDataAccess
    {
         void ModifyEntity(string statement, Dictionary<string, object> parameters);
         void GetEntity(string statement, Dictionary<string, object> parameters, Action<SqlDataReader> mapResult);


    }
}