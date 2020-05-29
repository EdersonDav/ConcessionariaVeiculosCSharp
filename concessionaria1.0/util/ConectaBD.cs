using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace concessionaria1._0.util
{
    class ConectaBD
    {

        //dados de conexão
        private static string serverName = "localhost";
        private static string port = "5432";
        private static string userName = "postgres";
        private static string password = "";
        private static string dataBaseName = "dbveiculos";

        public NpgsqlConnection getConexao()
        {
            try
            {
                //String de conexão
                string stgConexao = String.Format($"Server={serverName}; Port={port}; User Id={userName}; Password={password}; Database={dataBaseName}");


                //Classe de conexão
                NpgsqlConnection conexao = new NpgsqlConnection(stgConexao);

                //abre conexão
                conexao.Open();

                return conexao;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
