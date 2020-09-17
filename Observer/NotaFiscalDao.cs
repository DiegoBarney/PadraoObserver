using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class NotaFiscalDao : AcaoAposGerarNota
    {
        public void executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("salvando no banco");
        }
    }
}
