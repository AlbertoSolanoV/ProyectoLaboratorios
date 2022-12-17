using System;
using System.Collections.Generic;
using DataAccess.DAO;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class SqlDao
    {
        private string connecionString = String.Empty;

        private static SqlDao instance = new SqlDao();


        public SqlDao()
        {
            connecionString = ConfigurationManager.ConnectionStrings["BDAzure"].ConnectionString;
        }

        //Se crea el metodo para manejar la instancia unica
        public static SqlDao GetInstance()
        {
            if (instance == null)
                instance = new SqlDao();
            return instance;
        }

        public void ExecuteProcedure(SqlOperation operation)
        {
            var connection = new SqlConnection(this.connecionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in operation.Parameters)
            {
                command.Parameters.Add(param);
            }

            connection.Open();
            command.ExecuteNonQuery();
        }
        public string ExecuteProcedureRespuesta(SqlOperation operation)
        {
            var connection = new SqlConnection(this.connecionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in operation.Parameters)
            {
                command.Parameters.Add(param);
            }

            connection.Open();
            var reader = command.ExecuteScalar();
           
                return reader.ToString(); 
            
        }
        
        public List<Dictionary<string, object>> ExecuteProcedureWithQuery(SqlOperation operation)
        {
            var lstResult = new List<Dictionary<string, object>>();

            var connection = new SqlConnection(this.connecionString);
            var command = new SqlCommand();

            command.Connection = connection;
            command.CommandText = operation.ProcedureName;
            command.CommandType = CommandType.StoredProcedure;

            foreach (var param in operation.Parameters)
            {
                command.Parameters.Add(param);
            }


            connection.Open();
            var reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var dicc = new Dictionary<string, object>();
                    for (var fieldCounter = 0; fieldCounter < reader.FieldCount; fieldCounter++)
                    {
                        dicc.Add(reader.GetName(fieldCounter), reader.GetValue(fieldCounter));
                    } 
                    
                    lstResult.Add(dicc);
                }
            }
            return lstResult;
        }

    }
}