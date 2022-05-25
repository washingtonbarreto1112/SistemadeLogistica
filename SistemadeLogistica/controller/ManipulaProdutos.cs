using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SistemadeLogistica.model;
using System.Windows.Forms;

namespace SistemadeLogistica.controller
{
    class ManipulaProdutos
    {
        public void cadastroProdutos()
        {
            SqlConnection cn = new SqlConnection(ConexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pInserirProdutos", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@NomeProduto", Produtos.NomeProduto);
                cmd.Parameters.AddWithValue("@EmpresaProduto", Produtos.EmpresaProduto);
                cmd.Parameters.AddWithValue("@PesoProduto", Produtos.PesoProduto);
                cmd.Parameters.AddWithValue("@TamanhoProduto", Produtos.TamanhoProduto);

                SqlParameter nv = cmd.Parameters.Add("@CodProduto", SqlDbType.Int);
                nv.Direction = ParameterDirection.Output;

                cn.Open();
                cmd.ExecuteNonQuery();

                var resposta = MessageBox.Show("Cadastro do Produto efetuado com sucesso. Deseja Cadastrar um novo produto?",
                    "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (resposta == DialogResult.Yes)
                {
                    Produtos.Retorno = "Sim";
                    return;
                }
                else
                {
                    Produtos.Retorno = "Não";
                    return;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }    
        public void pesquisarCodigoProdutos()
        {
            SqlConnection cn = new SqlConnection(ConexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pBuscaCodigoProdutos", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@CodProduto", Produtos.CodProduto);
                cn.Open();
                var arrayDados = cmd.ExecuteReader();



                if (arrayDados.Read())
                {
                    Produtos.CodProduto = Convert.ToInt32(arrayDados["CodProduto"]);
                    Produtos.NomeProduto = arrayDados["NomeProduto"].ToString();
                    Produtos.EmpresaProduto = arrayDados["EmpresaProduto"].ToString();
                    Produtos.PesoProduto = arrayDados["PesoProduto"].ToString();
                    Produtos.TamanhoProduto = arrayDados["TamanhoProduto"].ToString();
                    Produtos.Retorno = "Sim";
                }
                else
                {
                    MessageBox.Show("Código não localizado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Produtos.Retorno = "Não";
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void deletarProdutos()
        {
            SqlConnection cn = new SqlConnection(ConexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pDeletarProdutos", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@CodProduto", Produtos.CodProduto);
                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto excluido com sucesso", "Exclusão",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            catch (Exception)
            {
                MessageBox.Show("O produto não foi excluido", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }
        public void alterarProdutos()
        {
            SqlConnection cn = new SqlConnection(ConexaoBD.conectar());
            SqlCommand cmd = new SqlCommand("pAlterarProdutos", cn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.AddWithValue("@CodProduto", Produtos.CodProduto);
                cmd.Parameters.AddWithValue("@NomeProduto", Produtos.NomeProduto);
                cmd.Parameters.AddWithValue("@EmpresaProduto", Produtos.EmpresaProduto);
                cmd.Parameters.AddWithValue("@PesoProduto", Produtos.PesoProduto);
                cmd.Parameters.AddWithValue("@TamanhoProduto", Produtos.TamanhoProduto);

                cn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Produto alterado com sucesso", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("O produto não foi alterado", "Atenção",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

    }
}
