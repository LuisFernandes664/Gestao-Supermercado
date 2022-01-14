using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class ListaDeUtilizadores
    {
        public List<Utilizador> listaDeUtilizadores;

        public ListaDeUtilizadores()
        {
            this.listaDeUtilizadores = new List<Utilizador>();
        }


        /*LER LISTA*/
        public void LerLista()
        {
            foreach (Utilizador c in this.listaDeUtilizadores)
            {
                Console.WriteLine(c);
            }
        }

        /*ADICIONAR UM NOVO UTILIZADOR*/
        public void AddUtilizador()
        {
            Console.WriteLine("Indique o nome: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Indique o Email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Defina a Password: ");
            string password = Console.ReadLine();

            listaDeUtilizadores.Add(new Utilizador(nome, email, password));
        }

        public Utilizador EncontrarUtilizador(string nome)
        {
            foreach (Utilizador c in this.listaDeUtilizadores)
            {
                if (c.Nome == nome)
                {
                    return c;
                }
            }
            return null;
        }

        public void EliminarUtilizador()
        {
            listaDeUtilizadores.Remove(EncontrarUtilizador(Console.ReadLine()));
            Console.WriteLine("Restantes da Lista: ");
            LerLista();
        }

        public void EditaUtilizador()
        {
            EditaUtilizador();
            AddUtilizador();
            Console.WriteLine("Adicionado com sucesso!!");
            LerLista();
        }

        public void EliminarTodos()
        {
            string path = "C:\\Users\\Win10\\Desktop\\Linguagem de Programação\\Projeto final\\Login\\Login\\bin\\Debug\\net5.0\\Utilizadores.txt";
            bool resultado = File.Exists(path);

            if(resultado == true)
            {
                Console.WriteLine("Apagando...");
                //Apaga o ficheiro
                File.Delete(path);
                Console.WriteLine("Lista Apagada Com Sucesso!");
            }
            else
            {
                Console.WriteLine("Não consegui apagar.");
            }
            escreverListaFicheiro();
        }


        //////////////////ESCREVER EM FICHEIRO///////////////////////////////
  
        public void escreverListaFicheiro()
        {
            //Directory.GetCurrentDirectory() da a pasta onde o programa foi compilado
            string path = Directory.GetCurrentDirectory();
            string fileName = "/Utilizadores.txt";

            //O boll diz se estamos a gravar por cima ou a adicionar
            StreamWriter streamWriter = new StreamWriter(path + fileName, true);

            foreach (Utilizador utilizador in listaDeUtilizadores)
            {
                streamWriter.WriteLine(utilizador.ToString());
            }

            streamWriter.Close();
        }


        public void lerFicheiro()
        {
            string path = Directory.GetCurrentDirectory();
            string fileName = "/Utilizadores.txt";
            string caminho = "C:\\Users\\Win10\\Desktop\\Linguagem de Programação\\Projeto final\\Login\\Login\\bin\\Debug\\net5.0\\Utilizadores.txt";
            bool resultado = File.Exists(caminho);

            //Verifica se o caminho existe senao executa else
            if(resultado == true)
            {
                StreamReader streamReader = new StreamReader(caminho);

                string[] lines = File.ReadAllLines("Utilizadores.txt");

                foreach (var line in lines) Console.WriteLine(line);
                if(lines.Length == 0)
                {
                    Console.WriteLine("A Lista esta vazia.");
                }
                streamReader.Close();
            }
            else
            {
                StreamReader streamReader = new StreamReader(path + fileName);
                string[] lines = File.ReadAllLines("Utilizadores.txt");

                foreach (var line in lines) Console.WriteLine(line);
                streamReader.Close();
            }
        }

        //toString
        public override string ToString()
        {
            string result = "";
            foreach (Utilizador utilizador in listaDeUtilizadores)
            {
                result += utilizador.ToString() + "\n";
            }
            return result;
        }


        //////////////////////VER VER ///////////////////////
        public void ListagemDeOpcoes()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                // MENU
                Console.WriteLine("0 - Sair");
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
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        AddUtilizador();
                        escreverListaFicheiro();
                        break;
                    case 2:
                        lerFicheiro();
                        break;
                    case 3:
                        EliminarUtilizador();
                        break;
                    case 4:
                        EliminarTodos();
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
            } while (escolhaDoUtilizador1 != 0);
        }
    }
}
