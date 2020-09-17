using System;
using System.Collections.Generic;

namespace Observer
{
    /// <summary>
    /// Classe Builder onde retira a complexibilidade de criação da classe NotaFiscal
    /// </summary>
    class NotaFiscalBuilder
    {
        private String razaoSocial;
        private String cnpj;
        private double valorBruto;
        private double impostos;
        private DateTime data;
        private String observacoes;
        private List<ItemDaNota> todosItens = new List<ItemDaNota>();
        private List<AcaoAposGerarNota> todasAcoesASeremExecutadas;

        public NotaFiscalBuilder(List<AcaoAposGerarNota> lista)
        {
            this.todasAcoesASeremExecutadas = lista;
        }

        /// <summary>
        /// Padrao Method Chain
        /// </summary>
        /// <param name="razaoSocial">Entrar com o nome da Empresa</param>
        /// <returns>retorna NotaFiscalBuilder, o próprio builder, para que o cliente continue ligando outros metodos na implementação</returns>
        public NotaFiscalBuilder paraEmpresa(String razaoSocial)
        {
            this.razaoSocial = razaoSocial;
            return this; 
        }

        /// <summary>
        /// Padrao Method Chain
        /// </summary>
        /// <param name="cnpj">Entrar com o CNPJ da empresa</param>
        /// <returns>retorna NotaFiscalBuilder, o próprio builder, para que o cliente continue ligando outros metodos na implementação</returns>
        public NotaFiscalBuilder comCnpj(String cnpj)
        {
            this.cnpj = cnpj;
            return this;
        }

        /// <summary>
        /// Padrao Method Chain, esse metodo pode ser chamado mais de uma vez, o mesmo adiciona o item a uma lista de item.
        /// </summary>
        /// <param name="item">Entrar com um item da nota Fiscal</param>
        /// <returns>retorna NotaFiscalBuilder, o próprio builder, para que o cliente continue ligando outros metodos na implementação</returns>
        public NotaFiscalBuilder comItemAdd(ItemDaNota item)
        {
            todosItens.Add(item);
            valorBruto += item.getValor();
            impostos += item.getValor() * 0.05;
            return this;
        }

        /// <summary>
        /// Padrao Method Chain 
        /// </summary>
        /// <param name="obs"></param>
        /// <returns>retorna NotaFiscalBuilder, o próprio builder, para que o cliente continue ligando outros metodos na implementação</returns>
        public NotaFiscalBuilder comObservacao(String obs)
        {
            this.observacoes = obs;
            return this;
        }

        /// <summary>
        /// Padrao Method Chain 
        /// </summary>
        /// <param name="obs"></param>
        /// <returns></returns>
        private DateTime comData()
        {
            this.data = DateTime.Now;
            return data;
        }

        /// <summary>
        /// Controi uma nota fiscal
        /// </summary>
        /// <returns>retorna NotaFiscal</returns>
        public NotaFiscal construir()
        {
            NotaFiscal nota = new NotaFiscal(razaoSocial, cnpj, comData(), valorBruto, impostos, todosItens, observacoes);

            if (todasAcoesASeremExecutadas != null)
            {
                foreach (AcaoAposGerarNota acao in todasAcoesASeremExecutadas)
                {
                    acao.executa(nota);
                }
            }

            return nota;
        }
    }
}
