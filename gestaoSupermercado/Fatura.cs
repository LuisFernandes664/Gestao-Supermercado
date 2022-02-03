using System;
using System.Collections.Generic;
using System.Text;
namespace Gestao_Supermercado
{
    [Serializable]

    public class Fatura : Produto
    {
        private string nomeCliente;

        public Fatura(string nomeCliente, string categoria, string NomeDoProduto, float Quantidade, string tipoDeQuantidade, float Preco) : base(categoria, NomeDoProduto, Quantidade, tipoDeQuantidade, Preco)
        {
            this.nomeCliente = nomeCliente;
        }

        public string NomeCliente
        {
            get { return nomeCliente; }
            set { nomeCliente = value; }
        }

        public override string ToString()
        {
            return "Nome: " + NomeProduto + " -> " + Quantidade + " " + tipoQuantidade + "..........................Preço: " + Preco + "€";
        }
    }
}
