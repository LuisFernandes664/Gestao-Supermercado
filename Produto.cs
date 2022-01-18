using System;
namespace Gestao_Supermercado
{
    public enum Categoria
    {
        Congelados = 1,
        Prateleira = 2,
        Enlatados = 3
    }

    public enum TipoQuantidade
    {
        Kg = 1,
        L = 2,
        Unidades = 3
    }

    public class Produto
    {
        public Categoria categoria;
        private string nomeProduto;
        private float quantidade;
        public TipoQuantidade tipoQuantidade;
        private float preco;

        public Produto(Categoria categoria, string nomeProduto, float quantidade, TipoQuantidade tipoQuantidade, float preco)
        {
            this.categoria = categoria;
            this.nomeProduto = nomeProduto;
            this.quantidade = quantidade;
            this.tipoQuantidade = tipoQuantidade;
            this.preco = preco;
        }

        public string NomeProduto
        {
            get { return nomeProduto; }
            set { nomeProduto = value; }
        }

        public float Quantidade
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
            return "Categoria: " + categoria + " | Nome: " + NomeProduto + " | Quantidade em stock: " + Quantidade + tipoQuantidade + " | Preço: " + Preco;
        }
    }
}
