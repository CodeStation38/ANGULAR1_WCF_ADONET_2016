using System;
using System.Data.SqlClient;
using System.Reflection;

namespace Infraestructure.DataPersistencia
{
    public interface IConector : IDisposable
    {
        SqlCommand Command { get; set; }

        SqlTransaction Transaction { get; set; }

        object Execute_Query_Scalar(string SQL_String_Instrucction);

        void Execute_NonQuery(string SQL_String_Instrucction);

        object Execute_Query_Table(string SQL_String_Instrucction);

        object Execute_Query_DataSet(string SQL_String_Instrucction);

        object Execute_Reader(string SQL_String_Instrucction);

        void Execute_NonQuery_MultipleTrans(string SQL_String_Instrucction);

        object Execute_Reader_MultipleTrans(string SQL_String_Instrucction);

        object Execute_Query_Table_MultipleTrans(string SQL_String_Instrucction);

        object Execute_Query_Scalar_MultipleTrans(string SQL_String_Instrucction);

        void Open_Connection();

        SqlTransaction Open_Transaction();

    }

    public class Conector: IConector, IDisposable
    {
                #region PRIVATE OBJECTS DEFINITION

        private bool IsDisposed = false;

        private SqlConnection Connector = new SqlConnection();

        private SqlCommand command = new SqlCommand();

        private SqlDataAdapter DataAdapter = new SqlDataAdapter();

        private SqlTransaction transaction;

        #endregion

        #region PUBLIC ENUM DEFINITION

        public enum Data_Base_Connection
        {
            SOMECOMPANY_FRONT = 1,
        }

        #endregion

        #region PUBLIC STATIC METHODS

        public static string GetStringValue(Enum value)
        {
            string output = null;
            Type type = value.GetType();

            System.Collections.Hashtable _stringValues = new System.Collections.Hashtable();

            if (_stringValues.ContainsKey(value))
            {
                output = (_stringValues[value] as StringValueAttribute).Value;
            }
            else
            {
                FieldInfo fi = type.GetField(value.ToString());
                StringValueAttribute[] attrs = fi.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
                if (attrs.Length > 0)
                {
                    _stringValues.Add(value, attrs[0]);
                    output = attrs[0].Value;
                }
            }

            return output;
        }

        #endregion

        #region PUBLIC METHODS

        public SqlCommand Command
        {
            get { return command; }
            set { command = value; }
        }

        public SqlTransaction Transaction
        {
            get { return transaction; }
            set { transaction = value; }
        }
        #endregion

        #region CONSTRUCTORS


        public Conector(SqlConnection Base_Connect)
        {
            try
            {
                command.CommandTimeout = 30;
                Connector = Base_Connect;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Conector()
        {
            // TODO: Complete member initialization
        }

        #endregion CONSTRUCTORS

        #region PUBLIC SQL METHODS

        public object Execute_Query_Scalar(string SQL_String_Instrucction)
        {
            object Result;
            try
            {
                Connector.Open();
                command.Connection = Connector;

                command.CommandText = SQL_String_Instrucction;
                Result = command.ExecuteScalar();
                return Result;

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Connector.Close();
            }
        }

        public void Execute_NonQuery(string SQL_String_Instrucction)
        {
            SqlTransaction Transaction;
            try
            {
                Connector.Open();

                Transaction = Connector.BeginTransaction();
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                command.Connection = Connector;
                command.CommandText = SQL_String_Instrucction;
                command.Transaction = Transaction;
                command.ExecuteNonQuery();
                Transaction.Commit();
            }
            catch (Exception e)
            {
                Transaction.Rollback();
                throw e;
            }
            finally
            {
                Connector.Close();
                Transaction.Dispose();
            }
        }

        public object Execute_Query_Table(string SQL_String_Instrucction)
        {
            System.Data.DataTable Return_Table = new System.Data.DataTable();

            try
            {
                command.Connection = Connector;
                //command.CommandType = System.Data.CommandType.Text;

                command.CommandText = SQL_String_Instrucction;
                DataAdapter.SelectCommand = command;
                DataAdapter.Fill(Return_Table);
                return Return_Table;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Connector.Close();
            }

        }

        public object Execute_Query_DataSet(string SQL_String_Instrucction)
        {
            System.Data.DataSet Return_Ds = new System.Data.DataSet();

            try
            {
                command.Connection = Connector;
                //command.CommandType = System.Data.CommandType.Text;

                command.CommandText = SQL_String_Instrucction;
                DataAdapter.SelectCommand = command;
                DataAdapter.Fill(Return_Ds);
                return Return_Ds;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Connector.Close();
            }

        }

        public object Execute_Reader(string SQL_String_Instrucction)
        {
            SqlDataReader Reader;

            try
            {
                if (Connector.State == System.Data.ConnectionState.Closed)
                {
                    Connector.Open();
                }
                command.Connection = Connector;

                command.CommandText = SQL_String_Instrucction;
                Reader = command.ExecuteReader();
                return Reader;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Execute_NonQuery_MultipleTrans(string SQL_String_Instrucction)
        {
            try
            {
                if (Connector.State == System.Data.ConnectionState.Closed)
                {
                    Connector.Open();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            try
            {
                command.CommandText = SQL_String_Instrucction;

                command.Connection = Connector;
                command.Transaction = Transaction;
                command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Execute_Reader_MultipleTrans(string SQL_String_Instrucction)
        {
            object Result;

            try
            {
                if (Connector.State == System.Data.ConnectionState.Closed)
                {
                    Connector.Open();
                }

                command.CommandText = SQL_String_Instrucction;

                command.Connection = Connector;
                command.Transaction = Transaction;
                Result = command.ExecuteReader();

                return Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Execute_Query_Table_MultipleTrans(string SQL_String_Instrucction)
        {
            System.Data.DataTable Return_Table = new System.Data.DataTable();
            try
            {
                if (Connector.State == System.Data.ConnectionState.Closed)
                {
                    Connector.Open();
                }
                this.Command.Dispose();
                command.CommandText = SQL_String_Instrucction;

                command.Connection = Connector;
                command.Transaction = Transaction;
                DataAdapter.SelectCommand = command;
                DataAdapter.Fill(Return_Table);

                return Return_Table;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public object Execute_Query_Scalar_MultipleTrans(string SQL_String_Instrucction)
        {
            object Result;
            try
            {
                if (Connector.State == System.Data.ConnectionState.Closed)
                {
                    Connector.Open();
                }

                command.CommandText = SQL_String_Instrucction;
                command.Connection = Connector;
                command.Transaction = Transaction;
                Result = command.ExecuteScalar();

                return Result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Open_Connection()
        {
            try
            {
                Connector.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SqlTransaction Open_Transaction()
        {
            try
            {
                if (this.Connector.State != System.Data.ConnectionState.Open)
                {
                    this.Open_Connection();
                }

                return this.Connector.BeginTransaction();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        #region DESTRUCTOR METHODS

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool Diposing)
        {
            if (!IsDisposed)
            {
                if (Diposing)
                {
                    this.Connector.Close();
                    this.Command.Dispose();
                    this.Connector.Dispose();
                    this.DataAdapter.Dispose();
                }
            }

            IsDisposed = true;
        }

        ~Conector()
        {
            Dispose(false);
        }

        #endregion
    }

        public class StringValueAttribute : System.Attribute
    {

        private string _value;

        public StringValueAttribute(string value)
        {
            _value = value;
        }

        public string Value
        {
            get { return _value; }
        }
    }

}
