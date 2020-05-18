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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            moveSidePanel(btnCadastrar);
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
        private void moveSidePanel(Control c)
        {
            sidePanel.Height = c.Height;
            sidePanel.Top = c.Top;

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnCadastrar);
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

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtPlaca_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnAtualizar);

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnExcluir);

        }

        // Evento de click para sair do programa 
        private void btnSair_Click(object sender, EventArgs e)
        {
            //mover sidePainel para o botão sair
            moveSidePanel(btnSair);
            // Desabilitar qualquer outra função do botão
            btnSair.Enabled = false;
            // Fechar o formulario Principal
            Close();
        }

        private void btnCarregar_Click_1(object sender, EventArgs e)
        {
            Veiculo objVeiculo = new Veiculo();

            dtGrid.DataSource = objVeiculo.Listar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < dtGrid.RowCount; i++)
            {
                dtGrid.Rows[i].DataGridView.Columns.Clear();
            }
        }
    }
}
