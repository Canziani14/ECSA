using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLHelper
{
    public class SQLHelper
    {
        public class SqlHelper
        {
            private static SqlHelper instance;

            private string connectionString = @"Data Source=DESKTOP-FJGOIBU\\SQLEXPRESS;Initial Catalog=ECSA;Integrated Security=True";

            private string ConnectionString => connectionString;

            public static SqlHelper GetInstance(string connectionString)
            {
                if (instance == null)
                {
                    instance = new SqlHelper(connectionString);
                }

                return instance;
            }

            private SqlHelper(string connString)
            {
                connectionString = connString;
            }

            public DataTable ExecuteDataTable(string query)
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = sqlConnection.CreateCommand();
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = query;
                    sqlCommand.Connection = sqlConnection;
                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                }

                return dataTable;
            }

            public DataTable ExecuteDataTable(string storeProcedureName, List<SqlParameter> parameters)
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandText = storeProcedureName;
                    sqlCommand.Connection = sqlConnection;
                    if (parameters != null && parameters.Count > 0)
                    {
                        sqlCommand.Parameters.AddRange(parameters.ToArray());
                    }

                    sqlConnection.Open();
                    dataTable.Load(sqlCommand.ExecuteReader());
                }

                return dataTable;
            }

            public int ExecuteNonQuery(string query)
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = query;
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }

            public int ExecuteNonQuery(string storeProcedure, List<SqlParameter> parameters)
            {
                SqlConnection sqlConnection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = storeProcedure;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                if (parameters != null && parameters.Count > 0)
                {
                    sqlCommand.Parameters.AddRange(parameters.ToArray());
                }

                sqlConnection.Open();
                return sqlCommand.ExecuteNonQuery();
            }

            public DataTable ExecuteDataTableConADODesconectado(string query)
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = query;
                sqlCommand.Connection = connection;
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }

            public DataTable ExecuteDataTableConADODesconectado(string storeProcedure, List<SqlParameter> parameters)
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                SqlConnection connection = new SqlConnection(ConnectionString);
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = storeProcedure;
                sqlCommand.Connection = connection;
                sqlDataAdapter.SelectCommand = sqlCommand;
                if (parameters != null && parameters.Count > 0)
                {
                    sqlCommand.Parameters.AddRange(parameters.ToArray());
                }

                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
        }
    }

}
