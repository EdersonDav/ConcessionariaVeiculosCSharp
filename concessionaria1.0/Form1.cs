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
        //instanciando um objeto do tipo veiculo para utilizar em todos os metodos
        Veiculo objVeiculo = new Veiculo();
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
                //Capturando as informações de cadastro
                objVeiculo.Placa = txtPlaca.Text;
                objVeiculo.Modelo = txtModelo.Text;
                objVeiculo.PrecoTabela = double.Parse(txtPreco.Text);
                objVeiculo.Ano = int.Parse(txtAno.Text);
                objVeiculo.Fabricante = txtFabricante.Text;

                objVeiculo.CadastrarVeiculo();

                //Mensagem para quando o cadastro é efetuado com sucesso
                MessageBox.Show("Cadastrado com Sucesso!!");

                //Limpando os campos depois de cadastrar
                txtPlaca.Text = "";
                txtModelo.Text = "";
                txtPreco.Text = "";
                txtAno.Text = "";
                txtFabricante.Text = "";
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
            //Se o texto do lbl id for igual a ID é pq o usuario não clicou em nenhum item da grid para atualizar
            if (lblid.Text == "ID")
            {
                MessageBox.Show("Por favor clicar em carregar e selecionar um veiculo da view para ser feita a atualização");
            }
            else
            {
                try
                {
                    objVeiculo.ID = Convert.ToInt32(lblid.Text);
                    objVeiculo.Placa = txtPlaca.Text;
                    objVeiculo.Modelo = txtModelo.Text;
                    objVeiculo.PrecoTabela = double.Parse(txtPreco.Text);
                    objVeiculo.Ano = int.Parse(txtAno.Text);
                    objVeiculo.Fabricante = txtFabricante.Text;

                    MessageBox.Show("Atualizado com Sucesso!!");
                    dtGrid.DataSource = objVeiculo.Listar();

                    //Limpando os campos depois de cadastrar
                    txtPlaca.Text = "";
                    txtModelo.Text = "";
                    txtPreco.Text = "";
                    txtAno.Text = "";
                    txtFabricante.Text = "";

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao cadastrar. " + ex.Message);
                }
            }
            

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            moveSidePanel(btnExcluir);
            //Se o texto do lbl id for igual a ID é pq o usuario não clicou em nenhum item da grid para atualizar
            if (lblid.Text == "ID")
            {
                MessageBox.Show("Por favor clicar em carregar e selecionar um veiculo da view para ser feita a atualização");
            }
            else
            {
                try
                {
                    objVeiculo.ID = Convert.ToInt32(lblid.Text);
                    objVeiculo.Excluir();

                    //Limpando os campos depois de cadastrar
                    txtPlaca.Text = "";
                    txtModelo.Text = "";
                    txtPreco.Text = "";
                    txtAno.Text = "";
                    txtFabricante.Text = "";

                }
                catch (Exception ex)
                {
                    throw new Exception("Erro ao cadastrar. " + ex.Message);
                }
                
            }

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

            dtGrid.DataSource = objVeiculo.Listar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dtGrid.RowCount; i++)
            {
                dtGrid.Rows[i].DataGridView.Columns.Clear();
            }
        }

        private void dtGrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Colocando valores da grid nos campos
            lblid.Text = txtPlaca.Text = dtGrid.CurrentRow.Cells[0].Value.ToString();
            txtPlaca.Text = dtGrid.CurrentRow.Cells[1].Value.ToString();
            txtModelo.Text = dtGrid.CurrentRow.Cells[3].Value.ToString();
            txtPreco.Text = dtGrid.CurrentRow.Cells[5].Value.ToString();
            txtAno.Text = dtGrid.CurrentRow.Cells[4].Value.ToString();
            txtFabricante.Text = dtGrid.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
