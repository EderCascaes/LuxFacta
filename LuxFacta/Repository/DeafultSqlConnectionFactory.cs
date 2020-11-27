using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LuxFacta.Repository
{
    public class DeafultSqlConnectionFactory : IConnectionFactory
    {
        private SqlConnection _connection;
        public IConfiguration _configuration;

        public IDbConnection Connection()
        {
            return new SqlConnection(_configuration["ConnString"]);
        }

        public SqlConnection ObjetoConnection
        {
            get { return this._connection; }
            set { this._connection = value; }
        }

        public void OpemConection()
        {
            try
            {
                this._connection.Open();
                System.Console.WriteLine("**********Conexão realizada com Sucesso ***********");
            }
            catch (SqlException ex)
            {
                throw new Exception("Falha na conexão : " + ex.Message);
            }
        }

        public void OpemClose()
        {
            this._connection.Close();
        }



    }
}
