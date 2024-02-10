using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infraestructure.DataPersistencia
{
    public interface IAdoRepository
    {
        List<SqlParameter> ExecuteNonQuery(string storeProcedure, List<SqlParameter> parametros);
        SqlDataReader ExecuteReader(string storeProcedure, List<SqlParameter> parametros);
        DataSet ExecuteDataSet(string storeProcedure, List<SqlParameter> parametros);
    }

    public class AdoRepository : IAdoRepository, IDisposable
    {



        private SqlCommand command = new SqlCommand();
        private readonly SqlConnection _sqlConnection;

        public AdoRepository(SqlConnection sqlConnection)
        {
            _sqlConnection = sqlConnection;
        }
        public string asSQLParameter(string parametro)
        {
            return parametro == null ? "%" : parametro;
        }
        #region IAdoRepository Members

        public List<SqlParameter> ExecuteNonQuery(string storeProcedure, List<SqlParameter> parametros)
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();

            SqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                 command = new SqlCommand(storeProcedure, _sqlConnection, transaction)
                    {
                        CommandType = CommandType.StoredProcedure,
                        CommandTimeout = 120
                    };

                command.Parameters.AddRange(parametros.ToArray());

                var test = command.ExecuteNonQuery();

                transaction.Commit();

                return
                    command.Parameters.Cast<SqlParameter>().Where(
                        param =>
                        param.Direction == ParameterDirection.InputOutput ||
                        param.Direction == ParameterDirection.Output ||
                        param.Direction == ParameterDirection.ReturnValue).ToList();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }
        public object ExecuteScalar(string storeProcedure, List<SqlParameter> parametros)
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();

            SqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                command = new SqlCommand(storeProcedure, _sqlConnection, transaction)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 120
                };

                command.Parameters.AddRange(parametros.ToArray());
                transaction.Commit();
                return command.ExecuteScalar();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                _sqlConnection.Close();
            }
        }

        public object ExecuteScalar_MultipleTrans(string storeProcedure, List<SqlParameter> parametros)
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();
            try
            {
                command = new SqlCommand(storeProcedure, _sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure,
                    CommandTimeout = 120
                };

                command.Parameters.AddRange(parametros.ToArray());
                return command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
            }
        }



        public SqlDataReader ExecuteReader(string storeProcedure, List<SqlParameter> parametros)
        {

            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();

            command = new SqlCommand(storeProcedure, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 120
            };

            command.Parameters.AddRange(parametros.ToArray());
            
            return command.ExecuteReader();
        }

        public DataSet ExecuteDataSet(string storeProcedure, List<SqlParameter> parametros)
        {
            if (_sqlConnection.State == System.Data.ConnectionState.Closed)
                _sqlConnection.Open();

            var command = new SqlCommand(storeProcedure, _sqlConnection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 120
            };

            command.Parameters.AddRange(parametros.ToArray());

            var da = new SqlDataAdapter(command);

            var ds = new DataSet();
            da.Fill(ds);

            _sqlConnection.Close();
            return ds;
        }
        #endregion

        public void Dispose()
        {
            _sqlConnection.Close();
            _sqlConnection.Dispose();
        }
    }
}