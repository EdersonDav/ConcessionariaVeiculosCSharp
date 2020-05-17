using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using concessionaria1._0.util;

namespace concessionaria1._0.modelo
{
    class Fabricante
    {
        public int ID { get; set; }
        public string Nome { get; set; }

        //Construtor vazio (Boas praticas)
        public Fabricante()
        {

        }

        //Construtor
        public Fabricante(int id, string nome)
        {
            this.ID = id;
            this.Nome = nome;
        }

        //Cadastro de Fabricante
        public int CadastrarFabricante(string fabricante)
        {
            try
            {
                //Abre conexão
                NpgsqlConnection conect = new ConectaBD().getConexao();

                // Strinsg de comando do insert no sql
                string insert = $"INSERT INTO fabricante (nome) VALUES ('{fabricante}')";

                //Cria o comando passando a string e as informações de conexão
                NpgsqlCommand comand = new NpgsqlCommand(insert, conect);

                //Executa o comando
                comand.ExecuteNonQuery();

                //Fecha conexão
                conect.Close();

                //Retorna o codigo do fabricante que foi cadastrado
                int codigo = getId(fabricante);

                return codigo;

            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public int getId(string fabricante)
        {
            //Abre conexão
            NpgsqlConnection conect = new ConectaBD().getConexao();

            try
            {
                // Strinsg de comando para selecionar o id do fabricante
                string select = $"SELECT codigo from fabricante WHERE nome = ('{fabricante}')";

                //Cria o comando passando a string e as informações de conexão
                NpgsqlCommand comand = new NpgsqlCommand(select, conect);

                //Executa o comando e atribui a variavel id
                NpgsqlDataReader dr = comand.ExecuteReader();

                // Variavel para guardar o codigo capturado no select
                int codigo = 0;

                if (dr.Read())
                {
                    //Se o fabricante que foi recebido no metodo for encontrado no banco, a variavel codigo recebe esse mesmo codi encontrado no banco
                     codigo = Convert.ToInt32(dr["codigo"]);
                }
                else
                {
                    //Se não for encontrado o codigo no banco, é feita a chamada do metodo cadastrar e faz o cadastro do fornecedor informado
                    //Para que isso funcione, o metodo "CadastrarFabricante" chama esse mesmo metodo que estamos e faz o cadastro desse fabricante e retorna para esse mesmo metodo 
                    codigo = CadastrarFabricante(fabricante);
                }

                //retorna o id que foi capturado no select
                return codigo;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                //Fecha conexão
                if (conect != null)
                {
                    conect.Close();
                }
            }
            
        }
    }
}
