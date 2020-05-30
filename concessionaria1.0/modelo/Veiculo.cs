using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using concessionaria1._0.util;

namespace concessionaria1._0.modelo
{
    class Veiculo
    {
        public int ID { get; set; }
        public string Placa { get; set; }
        public string Fabricante { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public double PrecoTabela { get; set; }

        //Construtor vazio (Boas praticas)
        public Veiculo()
        {

        }

        //Construtor
        public Veiculo(int id, string placa, string fabricante, string modelo, int ano, double preco)
        {
            this.ID = id;
            this.Placa = placa;
            this.Fabricante = fabricante;
            this.Modelo = modelo;
            this.Ano = ano;
            this.PrecoTabela = preco;
        }

        //Cadastro de Veiculo
        public void CadastrarVeiculo()
        {
            try
            {
                //chamada do metodo que retorna o id do fabricante
                Fabricante fabricante = new Fabricante();
                int fabricante_id = fabricante.getId(this.Fabricante);

                //Abre conexão
                NpgsqlConnection conect = new ConectaBD().getConexao();

                // Strinsg de comando do insert no sql
                string insert = $"INSERT INTO veiculo (placa, id_fabricante, modelo, ano, preco_tabela) " +
                                $"VALUES ('{this.Placa}','{fabricante_id}','{this.Modelo}','{this.Ano}','{this.PrecoTabela}')";

                //Envia a string e as informações de conexão
                NpgsqlCommand comand = new NpgsqlCommand(insert, conect);

                //Executa o camando
                comand.ExecuteNonQuery();

                //Fecha conexão
                conect.Close();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Veiculo> Listar()
        {
            //Abre conexão
            NpgsqlConnection conect = new ConectaBD().getConexao();

            try
            {
                // Strinsg de comando para selecionar o id do fabricante
                string select = "Select veiculo.codigo, veiculo.placa, veiculo.modelo, veiculo.ano, veiculo.preco_tabela, fabricante.nome " +
                                "from veiculo, fabricante " +
                                "Where veiculo.id_fabricante = fabricante.codigo";

                //Cria o comando passando a string e as informações de conexão
                NpgsqlCommand comand = new NpgsqlCommand(select, conect);

                //Executa o comando e atribui a variavel id
                NpgsqlDataReader dr = comand.ExecuteReader();

                //Lista que vai retornar o select
                List<Veiculo> listaVeiculo = new List<Veiculo>();

                while (dr.Read())
                {
                    Veiculo novoVeiculo = new Veiculo();

                    //Atribui cada valor do select
                    novoVeiculo.ID = Convert.ToInt32(dr["codigo"]);
                    novoVeiculo.Ano = Convert.ToInt32(dr["ano"]);
                    novoVeiculo.Fabricante = dr["nome"].ToString();
                    novoVeiculo.Placa = dr["placa"].ToString();
                    novoVeiculo.PrecoTabela = Convert.ToDouble(dr["preco_tabela"]);
                    novoVeiculo.Modelo = dr["modelo"].ToString();

                    //adiciona o objeto na lista
                    listaVeiculo.Add(novoVeiculo);
                }

                return listaVeiculo;
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
        public void Alterar()
        {
            NpgsqlConnection conect = new ConectaBD().getConexao();
            try
            {
                //chamada do metodo que retorna o id do fabricante
                Fabricante fabricante = new Fabricante();
                int fabricante_id = fabricante.getId(this.Fabricante);

                //String de comando SQL
                string update = $"Update veiculo set placa = '{this.Placa}' ,modelo = '{this.Modelo}' ,ano = '{this.Ano}',preco_tabela = '{this.PrecoTabela}'" +
                             $"where codigo = '{this.ID}'";

                NpgsqlCommand cmd = new NpgsqlCommand(update, conect);

                cmd.ExecuteNonQuery();

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
        public void Excluir()
        {
            NpgsqlConnection conexao = new ConectaBD().getConexao();
            try
            {
                string sql = $"DELETE from veiculo  where codigo = '{this.ID}'";

                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);

                cmd.ExecuteNonQuery();



            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

    }
}
