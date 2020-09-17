using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class Impressora : AcaoAposGerarNota
    {
        public void executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("imprimindo notaFiscal");
        }
    }
}
