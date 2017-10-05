using ShipBobDataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ShipBobDataAccess
{
    public interface IShipBobDataAccess
    {
         void ModifyEntity(string statement, Dictionary<string, object> parameters);
         SqlDataReader GetEntity(string statement, Dictionary<string, object> parameters, Action<SqlDataReader> mapResult);


    }
}