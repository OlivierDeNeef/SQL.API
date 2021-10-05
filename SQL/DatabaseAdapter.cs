using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SQL
{
    public class DatabaseAdapter
    {
        private string ConnectionString { get; }

        /// <summary>
        /// Set the connections string for upcoming connection.
        /// </summary>
        /// <param name="connectionString"></param>
        public DatabaseAdapter(string connectionString)
        {
            ConnectionString = connectionString;
        }


        /// <summary>
        /// Returns the data from the entered SQL Select Query.
        /// </summary>
        /// <param name="sqlQuery">a Select Query</param>
        /// <returns>Data</returns>
        public DataTable GetDataTable(string sqlQuery)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new NullReferenceException(
                    "The connection could not be established because connection string was empty");
            try
            {
                var dt = new DataTable();
                using var con = new SqlConnection(ConnectionString);
                var da = new SqlDataAdapter { SelectCommand = new SqlCommand(sqlQuery, con) };
                da.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw new DataException("The data could not be received", e);
            }
        }


        /// <summary>
        /// Returns the data from the entered SQL Select Query in async manner.
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns></returns>
        public async Task<DataTable> GetDataTableAsync(string sqlQuery)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new NullReferenceException(
                    "The connection could not be established because connection string was empty");
            try
            {
                var dt = new DataTable();
                await using var con = new SqlConnection(ConnectionString);
                var sqlCommand =  con.CreateCommand();
                sqlCommand.CommandText = sqlQuery;
                var reader = await sqlCommand.ExecuteReaderAsync();
                dt.Load(reader);
                return dt;
            }
            catch (Exception e)
            {
                throw new DataException("The data could not be received", e);
            }
        }


        /// <summary>
        /// Returns the data from the entered SQL Select Query.
        /// </summary>
        /// <param name="sqlQuery">a Select Query</param>
        /// <returns>Data</returns>
        public DataSet GetDataSet(string sqlQuery)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new NullReferenceException(
                    "The connection could not be established because connection string was empty");
            try
            {
                var ds = new DataSet();
                using var con = new SqlConnection(ConnectionString);
                var da = new SqlDataAdapter { SelectCommand = new SqlCommand(sqlQuery, con) };
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw new DataException("The data could not be received", e);
            }
        }


        /// <summary>
        /// Manipulate data from a database (Insert/Update/Delete/..)
        /// </summary>
        /// <param name="sqlQuery">a Select, Update or Delete Query</param>
        public int ChangeData(string sqlQuery)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new NullReferenceException(
                    "The connection could not be established because connection string was empty");

            int affectedRows;

            try
            {
                using var con = new SqlConnection(ConnectionString);
                con.Open();
                var cmd = new SqlCommand(sqlQuery, con);
                affectedRows = cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw new DataException("The change could not be established", e);
            }

            return affectedRows;
        }


        /// <summary>
        /// Manipulate data from a database (Insert/Update/Delete/..) en returns one value via OUTPUT clause.
        /// </summary>
        /// <param name="sqlQuery">Query with syntax: "INSERT INTO MyTable OUTPUT INSERTED.[columnName] VALUES (MyValue1,MyValue2,..  )"</param>
        /// <returns>A value of the altered row</returns>
        public object ChangeAndGetValue(string sqlQuery)
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new NullReferenceException(
                    "The connection could not be established because connection string was empty");

            object result;

            try
            {
                using var con = new SqlConnection(ConnectionString);
                con.Open();
                var cmd = new SqlCommand(sqlQuery, con);
                result = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                throw new DataException("The change could not be established", e);
            }

            return result;
        }



       
      
    }
}
