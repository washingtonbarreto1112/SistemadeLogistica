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
    public partial class TelaCadastrarProdutos : Form
    {
        public TelaCadastrarProdutos()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Produtos.NomeProduto = tbxNomeProduto.Text;
            Produtos.EmpresaProduto = tbxEmpresa.Text;
            Produtos.PesoProduto = tbxPeso.Text;
            Produtos.TamanhoProduto = tbxTamanho.Text;

            ManipulaProdutos manipulaProdutos = new ManipulaProdutos();
            manipulaProdutos.cadastroProdutos();

            if (Produtos.Retorno == "Sim")
            {
                limparTela();
                return;
            }
            else
            {
                fecharCadastro();
                return;
            }
        }

        public void abrirCadastro()
        {
            this.ShowDialog();
        }
        public void fecharCadastro()
        {
            this.Close();
        }



        public void limparTela()
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox)
                {
                    ctl.Text = string.Empty;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
