using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gestao_Supermercado
{
    class ListaDeProdutos
    {
        public List<Produto> listaDeProdutos;

        public ListaDeProdutos()
        {
            this.listaDeProdutos = new List<Produto>();
        }

        int escolhaDoUtilizador = -1;

        public void AdicionarCategoria()
        {
            int escolhaDoUtilizador2 = -1;
            do
            {
                Console.WriteLine("1 - Congelados");
                Console.WriteLine("2 - Prateleira");
                Console.WriteLine("3 - Enlatados");

                bool consegui2 = false;

                while (!consegui2)
                {
                    consegui2 = int.TryParse(Console.ReadLine(), out escolhaDoUtilizador2);
                }

                switch (escolhaDoUtilizador2)
                {
                    case 1:
                        categoria = Categoria.Congelados;
                        break;
                    case 2:
                         = Categoria.Prateleira;
                        break;
                    case 3:
                        categoria = Categoria.Enlatados;
                        break;

                    default:
                        Console.WriteLine("Sem seleção!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            } while (escolhaDoUtilizador2 != 0);
        }

        public void AdicionarProduto()
        {
            Console.WriteLine("Indique a categoria: ");
            AdicionarCategoria();
            Console.WriteLine("Indique o nome: ");
            string NomeProduto = Console.ReadLine();
            Console.WriteLine("Indique a quantidade inicial: ");
            float Quantidade = float.Parse(Console.ReadLine());
            Console.WriteLine("Indique o tipo de quantidade: ");
            TipoQuantidade tipoQuantidade = Console.ReadLine();
            Console.WriteLine("Indique o preço: ");
            float Preco = float.Parse(Console.ReadLine());

            listaDeProdutos.Add(new Produto(categoria, NomeProduto, Quantidade, tipoQuantidade, Preco));
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
            }
            return null;
        }

        public Produto EncontrarCategoria(string categoria)
        {
            foreach (Produto p in this.listaDeProdutos)
            {
                do
                {
                    Console.WriteLine("1 - Congelados");
                    Console.WriteLine("2 - Prateleira");
                    Console.WriteLine("3 - Enlatados");

                    bool escolhi = false;

                    while (!escolhi)
                    {
                        escolhi = int.TryParse(Console.ReadLine(), out escolhaDoUtilizador);
                    }

                    switch (escolhaDoUtilizador)
                    {
                        case 1:
                            return p.categoria == ;
                            break;
                        case 2:
                            return p.categoria == Prateleira;
                            break;
                        case 3:
                            return p.categoria == Enlatados;
                            break;

                        default:
                            Console.WriteLine("Sem selecção");
                            break;
                    }

                    Console.ReadLine();
                    Console.Clear();
                } while (escolhaDoUtilizador != 0);
            }
        }

        public void AdicionarQuantidade(Produto produto)
        {
            Console.WriteLine("Indique a quantidade que quer adicionar ao stock: ");
            int Quantidade = produto.Quantidade + Convert.ToInt32(Console.ReadLine());
        }

        public void AdicionarStock()
        {
            EncontrarProduto(Console.ReadLine());
        }

        public void EliminarProduto()
        {
            listaDeProdutos.Remove(EncontrarProduto(Console.ReadLine()));
            LerListaProduto();
        }

        public void MenuStock()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                // MENU
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
                        AdicionarProduto();
                        break;
                    case 2:
                        LerListaProduto();
                        break;
                    case 3:
                        AdicionarStock();
                        break;
                    case 4:
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
