using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public class EnviadorDeSms : AcaoAposGerarNota
    {
        public void executa(NotaFiscal notaFiscal)
        {
            Console.WriteLine("enviando por sms");
        }
    }
}
