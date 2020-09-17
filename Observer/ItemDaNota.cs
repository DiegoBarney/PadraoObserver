using System;

namespace Observer
{
    public class ItemDaNota
    {
        private string nome;
        private double valor;


		public ItemDaNota(String nome, double valor)
		{
			this.nome = nome;
			this.valor = valor;
		}

		public String getNome()
		{
			return nome;
		}

		public double getValor()
		{
			return valor;
		}

	}
}