using System;
namespace Gestao_Supermercado
{
    [Serializable]

    public enum Categoria
    {
        Congelados = 1,
        Prateleira = 2,
        Enlatados = 3
    }

    [Serializable]

    public enum TipoQuantidade
    {
        Kg = 1,
        L = 2,
        Unidades = 3
    }

    [Serializable]

    public class Produto
    {
        public Categoria categoria;
        private string nomeProduto;
        private float quantidade;
        public TipoQuantidade tipoQuantidade;
        private float preco;

        public Produto(string categoria, string nomeProduto, float quantidade, string tipoQuantidade, float preco)
        {
            if (!Enum.TryParse(categoria, out this.categoria))
            {
                this.categoria = Categoria.Prateleira;
            }
            this.nomeProduto = nomeProduto;
            this.quantidade = quantidade;
            if (!Enum.TryParse(tipoQuantidade, out this.tipoQuantidade))
            {
                this.tipoQuantidade = TipoQuantidade.Unidades;
            }
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
            return "Categoria: " + categoria + " | Nome: " + NomeProduto + " | Quantidade em stock: " + Quantidade + " " + tipoQuantidade + " | Preço: " + Preco + "€";
        }
    }
}
