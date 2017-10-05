using ShipBobDataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipBobDataAccess
{
    public abstract class ShipBobDataAccess : IShipBobDataAccess
    {
        readonly string sqlConnection = ConfigurationManager.ConnectionStrings["shipbob"].ConnectionString;
        private SqlConnection conn;
        public SqlDataReader GetEntity(string statement, Dictionary<string, object> parameters, Action<SqlDataReader> mapResult)
        {
            SqlDataReader reader;
            try
            {
                SqlCommand cmd = SetUpConnection(statement, parameters);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    mapResult?.Invoke(reader);
                }
                return reader;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
                return null;
            }
            finally
            {
                conn.Close();
            }
            
        }
        /// <summary>
        /// Create Update or Delete Entity
        /// </summary>
        /// <param name="statement"></param>
        /// <param name="parameters"></param>
        public void ModifyEntity(string statement, Dictionary<string, object> parameters)
        {
            try
            {
                SqlCommand cmd = SetUpConnection(statement, parameters);
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }
            finally
            {
                conn.Close();
            }
        }

        #region private Helpers 
        private SqlCommand SetUpConnection(string statement, Dictionary<string, object> parameters)
        {
            conn = new SqlConnection(sqlConnection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);
            if (parameters != null)
            {
                foreach (var param in parameters)
                {
                    cmd.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
            
            return cmd;
        }
        private SqlCommand SetUpConnectionWithoutParams(string statement)
        {
            conn = new SqlConnection(sqlConnection);
            conn.Open();
            SqlCommand cmd = new SqlCommand(statement, conn);

            return cmd;
        }
        
        #endregion
    }
}
