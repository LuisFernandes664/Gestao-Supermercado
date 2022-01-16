using System;
namespace Gestao_Supermercado
{
    public class Produto
    {
        private string categoria;
        private string nomeProduto;
        private int quantidade;
        private float preco;

        public Produto(string categoria, string nomeProduto, int quantidade, float preco)
        {
            this.categoria = categoria;
            this.nomeProduto = nomeProduto;
            this.quantidade = quantidade;
            this.preco = preco;
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        public int Quantidade
        {
            get { return quantidade; }
            set { quantidade = value; }
        }

        public float Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public override string ToString()
        {
            return "Categoria: " + Categoria + " | Nome: " + NomeProduto + " | Qauntidade em stock: " + Quantidade + " | Preço: " + Preco;
        }
    }
}
