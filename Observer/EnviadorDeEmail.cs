using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class EnviadorDeEmail : AcaoAposGerarNota
    {
        public void executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("enviando por e-mail");
        }
    }
}
