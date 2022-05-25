using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemadeLogistica.controller;
using SistemadeLogistica.model;
using System.IO;


namespace SistemadeLogistica.view
{
    public partial class TelaPesquisarProdutos : Form
    {
        public TelaPesquisarProdutos()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxCodigo.Text == "")
                {
                    MessageBox.Show("Digite um codigo valido");
                    return;
                }
                else
                {
                    Produtos.CodProduto = Convert.ToInt32(tbxCodigo.Text);



                    tbxNome.Text = string.Empty;
                    tbxEmpresa.Text = string.Empty;
                    tbxPeso.Text = string.Empty;
                    tbxTamanho.Text = string.Empty;
                }



                ManipulaProdutos manipulaProdutos = new ManipulaProdutos();
                manipulaProdutos.pesquisarCodigoProdutos();


                tbxNome.Text = Produtos.NomeProduto;
                tbxEmpresa.Text = Produtos.EmpresaProduto;
                tbxPeso.Text = Produtos.PesoProduto;
                tbxTamanho.Text = Produtos.TamanhoProduto;

            }
            catch (Exception)
            {

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (tbxCodigo.Text == "")
            {
                MessageBox.Show("Digite um código válido!", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                tbxNome.Text = string.Empty;
                tbxEmpresa.Text = string.Empty;
                tbxPeso.Text = string.Empty;
                tbxTamanho.Text = string.Empty;
                return;
            }



            var resposta = MessageBox.Show("Deseja fazer alterações no produto " + tbxCodigo.Text + " ?",
            "Alteração", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);



            if (resposta == DialogResult.Yes)
            {
                Produtos.NomeProduto = tbxNome.Text;
                Produtos.EmpresaProduto = tbxEmpresa.Text;
                Produtos.PesoProduto = tbxPeso.Text;
                Produtos.TamanhoProduto = tbxTamanho.Text;

                ManipulaProdutos manipulaProdutos = new ManipulaProdutos();
                manipulaProdutos.alterarProdutos();
            }
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (tbxCodigo.Text == "")
            {
                MessageBox.Show("Digite um número válido!");
                return;
            }


            var resposta = MessageBox.Show("Deseja excluir o produto " + tbxCodigo.Text + " ?",
            "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);


            if (resposta == DialogResult.Yes)
            {
                Produtos.CodProduto = Convert.ToInt32(tbxCodigo.Text);

                ManipulaProdutos manipulaProdutos = new ManipulaProdutos();
                manipulaProdutos.deletarProdutos();
            }

            tbxNome.Text = string.Empty;
            tbxEmpresa.Text = string.Empty;
            tbxPeso.Text = string.Empty;
            tbxTamanho.Text = string.Empty;
        }
    }
}
