using System;


namespace Gestao_Supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaDeUtilizadores lista1 = new ListaDeUtilizadores();

            Login_Criacao login1 = new Login_Criacao("admin", "admin");

            int escolhaDoUtilizador = -1;
            Console.WriteLine("1 - Já tem conta?");
            Console.WriteLine("2 - Quer criar uma conta?");

            bool consegui = false;

            while (!consegui)
            {
                consegui = int.TryParse(Console.ReadLine(), out escolhaDoUtilizador);
                ///////////MOSTRA SE CONSEGUIU OU NAO EM BOLL PROCESSAR O QUE O UTILIZADOR SELECIONOU////////////
                ///Console.WriteLine(consegui);
            }
            switch (escolhaDoUtilizador)
            {
                case 1:
                    login1.EscreveLogin();
                    lista1.ListagemDeOpcoes();
                    break;
                case 2:
                    Console.WriteLine("Coloque o seu Nome: ");
                    string user = Console.ReadLine();
                    Console.WriteLine("Coloque a password: ");
                    string pass = Console.ReadLine();
                    //lista1.escreverListaFicheiro(user, pass);
                    break;
                default:
                    Console.WriteLine("Sem seleção!");

                    break;
            }

            /*int escolhaDoUtilizador1 = -1;
            do
            {
                // MENU
                Console.WriteLine("1 - Adicionar");
                Console.WriteLine("2 - Consultar");
                Console.WriteLine("3 - Eliminar");
                Console.WriteLine("4 - Eliminar tudo");
                Console.WriteLine("5 - Editar");

                bool consegui1 = false;

                while (!consegui1)
                {
                    consegui1 = int.TryParse(Console.ReadLine(), out escolhaDoUtilizador1);
                    ///////////MOSTRA SE CONSEGUIU OU NAO EM BOLL PROCESSAR O QUE O UTILIZADOR SELECIONOU////////////
                    ///Console.WriteLine(consegui);
                }

                switch (escolhaDoUtilizador1)
                {
                    case 1:
                        lista1.AddUtilizador();
                        lista1.escreverListaFicheiro();
                        break;
                    case 2:
                        lista1.lerFicheiro();
                        break;
                    case 3:
                        lista1.EliminarUtilizador();
                        break;
                    case 4:
                        lista1.EliminarTodos();
                        break;
                    case 5:////EDITAR
                        ///////lista1.EditaUtilizador();
                        break;

                    default:
                        Console.WriteLine("Sem seleção!");
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            } while (escolhaDoUtilizador1 != 0);*/
        }
    }
}
