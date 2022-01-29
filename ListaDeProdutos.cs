using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gestao_Supermercado
{
    [Serializable]

    class ListaDeProdutos
    {
        public string nome;
        public List<Produto> listaDeProdutos;

        public ListaDeProdutos(string nome)
        {
            this.nome = nome;
            this.listaDeProdutos = new List<Produto>();
        }

        public void AdicionarProduto()
        {
            Console.WriteLine("Indique a categoria: \n");
            Console.WriteLine("\t 1 - Congeldos;");
            Console.WriteLine("\t 2 - Prateleira;");
            Console.WriteLine("\t 3 - Enlatados;");
            string categoria = Console.ReadLine();
            Console.WriteLine("Indique o nome: ");
            string NomeProduto = Console.ReadLine();
            Console.WriteLine("Indique a quantidade inicial: ");

            float Quantidade = float.Parse(Console.ReadLine());
            Console.WriteLine("Indique o tipo de quantidade: \n");
            Console.WriteLine("\t 1 - Kilos;");
            Console.WriteLine("\t 2 - Litros;");
            Console.WriteLine("\t 3 - Unidades;");
            string tipoQuantidade = Console.ReadLine();
            Console.WriteLine("Indique o preço (€): ");
            float Preco = float.Parse(Console.ReadLine());

            listaDeProdutos.Add(new Produto(categoria, NomeProduto, Quantidade, tipoQuantidade, Preco));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Novo produto criado com sucesso!");
            Console.ResetColor();
        }

        public void LerListaProduto()
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                Console.WriteLine(p);
            }
        }

        public Produto EncontrarProduto(string nome)
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                if (p.NomeProduto == nome)
                {
                    return p;
                }
                else if (p.NomeProduto != nome)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Produto não encontrado");
                    Console.ResetColor();
                }
            }
            return null;
        }

        public Produto AdicionarQuantidade(string nome)
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                if (p.NomeProduto == nome)
                {
                    Console.WriteLine("Escolha o a quantidade que quer adicionar: ");
                    float novaQuantidade = float.Parse(Console.ReadLine());
                    p.Quantidade = novaQuantidade + p.Quantidade;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nova quantidade em stock: " + p.NomeProduto + " -> " + p.Quantidade + " " + p.tipoQuantidade);
                    Console.ResetColor();
                }
                else if (p.NomeProduto != nome)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Produto não encontrado");
                    Console.ResetColor();
                }
            }
            return null;
        }

        public void AdicionarStock()
        {
            Console.WriteLine("Escolha o produto que quer adicionar stock: ");
            AdicionarQuantidade(Console.ReadLine());
        }

        public void EliminarProduto()
        {
            Console.WriteLine("Escolha o produto que quer eliminar: ");
            listaDeProdutos.Remove(EncontrarProduto(Console.ReadLine()));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto eliminado com sucesso");
            LerListaProduto();
            Console.ResetColor();
        }

        public void MenuStock()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("||||STOCK MENU|||| \n");
                Console.ResetColor();
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Criar Produto");
                Console.WriteLine("2 - Ver Lista de Produtos");
                Console.WriteLine("3 - Adicionar stock");
                Console.WriteLine("4 - Eliminar Produto");

                bool consegui1 = false;

                while (!consegui1)
                {
                    consegui1 = int.TryParse(Console.ReadLine(), out escolhaDoUtilizador1);
                }

                switch (escolhaDoUtilizador1)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****CRIAR PRODUTO**** \n");
                        Console.ResetColor();
                        AdicionarProduto();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****LISTA DE PRODUTOS*** \n");
                        Console.ResetColor();
                        LerListaProduto();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****ADICIONAR STOCK**** \n");
                        Console.ResetColor();
                        AdicionarStock();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****ELIMINAÇÃO DE PRODUTO**** \n");
                        Console.ResetColor();
                        EliminarProduto();
                        break;

                    default:
                        Console.WriteLine("Sem seleção!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            } while (escolhaDoUtilizador1 != 0);
        }
    }
}
