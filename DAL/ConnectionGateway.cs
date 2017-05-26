using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnneshProject.DAL
{
    public class ConnectionGateway : IDisposable
    {
        private static string localConnectionString = ConfigurationManager.ConnectionStrings["OnneshDbConnectionString"].ConnectionString;

        private static readonly SqlConnectionStringBuilder liveConnectionString = new SqlConnectionStringBuilder
        {
            ApplicationName = "LiveConnection",
            DataSource = "143.95.230.6",
            InitialCatalog = "bdvouche_onnesh",
            UserID = "bdvouche_onnesh",
            Password = "zgjM$402",
            IntegratedSecurity = false,
            PersistSecurityInfo = false,
            Pooling = true
        };

        private SqlConnection _databaseConnection;
        public IDbConnection GetConnection()
        {
            //_databaseConnection = new SqlConnection(localConnectionString);
            _databaseConnection = new SqlConnection(liveConnectionString.ConnectionString);
            try
            {
                _databaseConnection.Open();
            }
            catch (Exception ex)
            {
                //ignore exception
            }
            return _databaseConnection;
        }
        public void Dispose()
        {
            try
            {
                if (_databaseConnection.State != ConnectionState.Closed)
                {
                    _databaseConnection.Close();
                }
            }
            catch (Exception ex)
            {
                //ignore exception
            }
            SqlConnection.ClearPool(_databaseConnection);
        }
    }
}