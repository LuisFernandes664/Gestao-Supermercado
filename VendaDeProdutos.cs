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

        int escolhaDoUtilizador = -1;

        public void VenderProduto()
        {
            Console.WriteLine("Indique a categoria: ");
            string Categoria = Console.ReadLine();
            Console.WriteLine("Indique o nome: ");
            string NomeProduto = Console.ReadLine();
            Console.WriteLine("Indique a quantidade: ");
            int Quantidade = Convert.ToInt32(Console.ReadLine());

            RemoverDaLista();
        }
        public void RemoverDaLista()
        {
            /*
            //MUDAR ALGO PARA REMOVER APENAS A QUANTIDADE SELECIONADA
            listaDeProdutos.Remove(EncontrarProduto(Console.ReadLine()));
            Console.WriteLine("Comprado!");
            LerListaProduto();*/

            var tw = File.Open(@"D:\faturas.txt", FileMode.Append);
            tw.Write("Text1");


            // fazer a conta do que esta la atualmente menos o que a quantidade que o utilizador quer comprar
            // e basicamente   ||
            //                \  /
            /*                 \/
             * eu tenho x, o armazem tem y
             * y-x=h
             * atualizar o ficheiro para o resultado de h
            */
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
        public void MenuStock()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Comprar Produto");
                Console.WriteLine("2 - Ver Lista de Produtos");
                // falta adicionar linhas a fatura conforme os produtos serem adicionados

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
