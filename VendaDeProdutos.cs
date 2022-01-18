using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Gestao_Supermercado
{
    class VendaDeProdutos
    {
        public List<Produto> listaDeProdutos;

        public VendaDeProdutos()
        {
            this.listaDeProdutos = new List<Produto>();
        }

        int escolhaDoUtilizador = -1;

        /*public void VenderProduto()
        {
            Console.WriteLine("Indique a categoria: ");
            string Categoria = Console.ReadLine();
            Console.WriteLine("Indique o nome: ");
            string NomeProduto = Console.ReadLine();
            Console.WriteLine("Indique a quantidade inicial: ");
            int Quantidade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Indique o preço: ");
            float Preco = float.Parse(Console.ReadLine());

               // AQUI FICA REMOVE EM VEZ DE ADD??
         
            listaDeProdutos.Add(new Produto(Categoria, NomeProduto, Quantidade, Preco));
        }*/

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

        public void AdicionarQuantidade(Produto produto)
        {
            Console.WriteLine("Indique a quantidade que quer comprar: ");
            int Quantida = produto.Quantidade - Convert.ToInt32(Console.ReadLine());

            //fazer um if sobre se tiver um numero maior do que a quantidade, dá erro!
        }

        public void MenuStock()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Comprar Produto");
                Console.WriteLine("2 - Ver Lista de Produtos");

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
                        VenderProduto();
                        break;
                    case 2:
                        LerListaProduto();
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
