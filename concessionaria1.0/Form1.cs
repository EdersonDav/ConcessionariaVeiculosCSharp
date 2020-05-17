using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using concessionaria1._0.modelo;

namespace concessionaria1._0
{
    public partial class btnListar : Form
    {
        public btnListar()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                //instanciando um objeto do tipo veiculo para capturar as informações de cadastro e salvar no banco
                Veiculo veiculo = new Veiculo();

                //Capturando as informações de cadastro
                veiculo.Placa = txtPlaca.Text;
                veiculo.Modelo = txtModelo.Text;
                veiculo.PrecoTabela = double.Parse(txtPreco.Text);
                veiculo.Ano = int.Parse(txtAno.Text);
                veiculo.Fabricante = txtFabricante.Text;

                veiculo.CadastrarVeiculo();

                //Mensagem para quando o cadastro é efetuado com sucesso
                MessageBox.Show("Cadastrado com Sucesso!!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao cadastrar. " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Veiculo objVeiculo = new Veiculo();

            dtGrid.DataSource = objVeiculo.Listar();
        }
    }
}
