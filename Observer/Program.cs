using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            List<AcaoAposGerarNota> acoes = new List<AcaoAposGerarNota>();
            acoes.Add(new EnviadorDeEmail());
            acoes.Add(new NotaFiscalDao());
            acoes.Add(new EnviadorDeSms());
            acoes.Add(new Impressora());

            NotaFiscal notafiscal = new NotaFiscalBuilder(acoes).paraEmpresa("Diego Pimentel")
                  .comCnpj("XXX.XXX.XXX/0001-XX")
                  .comItemAdd(new ItemDaNota("Teclado", 45.0))
                  .comItemAdd(new ItemDaNota("Mouse", 12.0))
                  .comItemAdd(new ItemDaNota("Monitor", 300.0))
                  .comObservacao("Entregar nota fiscal em maos")
                  .construir();


            Console.WriteLine("Razao Social: " + notafiscal.getRazaoSocial() + "CNPJ: "+notafiscal.getCnpj() + "Valor: " + notafiscal.getValorBruto());
            Console.ReadLine();
        }
    }
}
