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
                else if(p.NomeProduto != nome)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Produto não existe");
                    Console.ResetColor();
                }
            }
            return null;
        }

        public void EncontrarCongelados()
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                if(p.categoria == Categoria.Congelados)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public void EncontrarPrateleira()
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                if (p.categoria == Categoria.Prateleira)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public void EncontrarEnlatados()
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                if (p.categoria == Categoria.Enlatados)
                {
                    Console.WriteLine(p);
                }
            }
        }

        public void ListarPorCategoria()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Ver Lista de artigos Congelados");
                Console.WriteLine("2 - Ver Lista de artigos Prateleira");
                Console.WriteLine("3 - Ver Lista de artigos Enlatados");

                bool consegui1 = false;

                while (!consegui1)
                {
                    consegui1 = int.TryParse(Console.ReadLine(), out escolhaDoUtilizador1);
                }

                switch (escolhaDoUtilizador1)
                {
                    case 0:
                        MenuStock();
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****LISTA DE PRODUTOS CONGELADOS**** \n");
                        Console.ResetColor();
                        EncontrarCongelados();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****LISTA DE PRODUTOS PRATELEIRA*** \n");
                        Console.ResetColor();
                        EncontrarPrateleira();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****LISTA DE PRODUTOS ENLATADOS**** \n");
                        Console.ResetColor();
                        EncontrarEnlatados();
                        break;
                    default:
                        Console.WriteLine("Sem seleção!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            } while (escolhaDoUtilizador1 != 0);
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
                    Console.WriteLine("Foi adicionado ao produto a seguinte quantidade: " + novaQuantidade + " " + p.tipoQuantidade);
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

        public Produto QuantidadeZero(string nome)
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                if (p.NomeProduto == nome)
                {
                    p.Quantidade = 0;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Nova quantidade em stock: " + p.NomeProduto + " -> " + p.Quantidade + " " + p.tipoQuantidade);
                    Console.WriteLine("O stock do produto foi zerado com sucesso!");
                    Console.ResetColor();
                }
            }
            return null;
        }

        public void LimparStock()
        {
            Console.WriteLine("Escolha o produto que quer por o stock a zero: ");
            QuantidadeZero(Console.ReadLine());
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
                Console.WriteLine("4 - Limpar Stock");
                Console.WriteLine("5 - Eliminar Produto");

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
                        Console.WriteLine("****LIMPAR STOCK**** \n");
                        Console.ResetColor();
                        LimparStock();
                        break;
                    case 5:
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

        public Produto RetirarQuantidade(string nome)
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                if (p.NomeProduto == nome)
                {
                    Console.WriteLine("Quantidade que quer comprar: ");
                    float novaQuantidade = float.Parse(Console.ReadLine());
                        if (p.Quantidade - novaQuantidade > 0)
                    {
                        p.Quantidade = p.Quantidade - novaQuantidade;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Foi comprado com sucesso: " + novaQuantidade + " " + p.tipoQuantidade);
                        Console.WriteLine("Nova quantidade em stock: " + p.NomeProduto + " -> " + p.Quantidade + " " + p.tipoQuantidade);
                        Console.ResetColor();
                    }
                        else if (p.Quantidade - novaQuantidade < p.Quantidade)
                    {
                        p.Quantidade = p.Quantidade;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não foi possivel comprar a seguinte quantidade: " + novaQuantidade + " " + p.tipoQuantidade);
                        Console.WriteLine("Quantidade Existente em stock: " + p.NomeProduto + " -> " + p.Quantidade + " " + p.tipoQuantidade);
                        Console.ResetColor();
                    }
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

        public void RetirarStock()
        {
            Console.WriteLine("Escolha o produto que quer comprar: ");
            RetirarQuantidade(Console.ReadLine());
        }
    }
}
