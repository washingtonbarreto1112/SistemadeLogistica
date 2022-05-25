using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeLogistica.model
{
    class Produtos
    {
        private static int codProduto;
        private static string nomeProduto;
        private static string empresaProduto;
        private static string pesoProduto;
        private static string tamanhoProduto;
        private static string retorno;

        public static int CodProduto { get => codProduto; set => codProduto = value; }
        public static string NomeProduto { get => nomeProduto; set => nomeProduto = value; }
        public static string EmpresaProduto { get => empresaProduto; set => empresaProduto = value; }
        public static string PesoProduto { get => pesoProduto; set => pesoProduto = value; }
        public static string TamanhoProduto { get => tamanhoProduto; set => tamanhoProduto = value; }
        public static string Retorno { get => retorno; set => retorno = value; }
    }
}
