using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FusionServices.DataSource
{
    public abstract class AbstractMapper : IDisposable
    {
        protected SqlConnection Connection;
        private static string _connectionString;

        private static readonly object ConnectionLock = new object();
        private static void GetConnectionString()
        {
            if (null != _connectionString)
                return;

            lock (ConnectionLock)
            {
                if (null != _connectionString)
                    return;

                _connectionString = (string) ConfigurationManager.AppSettings["AzureConnection"];
            }
        }

        protected AbstractMapper()
        {
            GetConnectionString();
            Connection = new SqlConnection(_connectionString);
        }

        private void InternalOpen()
        {
            if (null == Connection)
                throw new ApplicationException("Connection null.");

            if (Connection.State != ConnectionState.Open)
                Connection.Open();
        }

        protected bool SetFederation = false;

        private void SetConnectionKey(int key, string federation, string column)
        {
            if (SetFederation) return;
            var command =
                new SqlCommand(
                    string.Format("USE FEDERATION {0} ({1} = {2}) WITH RESET, FILTERING = ON", federation, column,
                        key), Connection);

            try
            {
                command.ExecuteNonQuery();
                SetFederation = true;
            }
            finally
            {
                command.Dispose();
            }
        }

        protected void OpenAndSetKey(int key, string federation, string federationColumn)
        {
            // open the connection if needed
            InternalOpen();

            SetConnectionKey(key, federation, federationColumn);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool _disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (null != Connection)
                    {
                        if (Connection.State == ConnectionState.Open)
                            Connection.Close();

                        Connection.Dispose();
                    }
                }

                // There are no unmanaged resources to release, but
                // if we add them, they need to be released here.
            }
            _disposed = true;
        }
    }
}
