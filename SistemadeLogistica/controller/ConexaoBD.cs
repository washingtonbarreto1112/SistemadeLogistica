using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemadeLogistica.controller
{
    class ConexaoBD
    {
        public static string conectar()
        {
            return @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\washington.bpjunior\source\repos\SistemadeLogistica\SistemadeLogistica\BDLogistica.mdf;Integrated Security=True";
        }
    }
}
