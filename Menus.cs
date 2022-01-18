using System;
using System.Collections.Generic;
using System.Text;

namespace Gestao_Supermercado
{
    class Menus : VendaDeProdutos
    {
        public Menus()
        {
        }

        /*private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Escolha a opção: ");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1 - Comprar Produto: ");
            Console.WriteLine("2 - Ver Lista de Produtos: ");
            Console.WriteLine("0 - Sair");
            Console.Write("\r\nSelecione a opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    return true;
                case "2":
                    return true;
                case "3":
                    return false;
                default:
                    return true;
            }
        }*/

        private static bool MenuVendaProdutos()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("1 - Comprar Produto");
            Console.WriteLine("2 - Ver Fatura de todos os produtos");
            Console.WriteLine("0 - Sair");

            switch(Console.ReadLine())
            {
                case "1":
                    VendaDeProdutos();
                    return true;
                case "2":
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }

    }
}
