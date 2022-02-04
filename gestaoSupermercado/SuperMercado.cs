using System;
using System.Collections.Generic;
using System.Linq;
namespace Gestao_Supermercado
{
    [Serializable]

    public class SuperMercado
    {
        public string nome;
        public List<Produto> listaDeProdutos;
        public List<Utilizador> listaDeUtilizadores;
        public List<Fatura> listaDeCompras;

        public SuperMercado(string nome)
        {
            this.nome = nome;
            this.listaDeProdutos = new List<Produto>();
            this.listaDeUtilizadores = new List<Utilizador>();
            this.listaDeCompras = new List<Fatura>();
        }

        //METODOS LISTA DE PRODUTOS

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

        public void AdicionarProdutos(Produto p)
        {
            listaDeProdutos.Add(p);
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
                if (p.categoria == Categoria.Congelados)
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
                        Compras();
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
                Console.WriteLine("||||GESTÂO STOCK|||| \n");
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

        //METODOS LISTA DE UTILIZADORES

        public void AdicionarUtilizador()
        {
            Console.WriteLine("Indique o tipo de funcionário: \n");
            Console.WriteLine("\t 1 - Gerente;");
            Console.WriteLine("\t 2 - Repositor;");
            Console.WriteLine("\t 3 - Caixa;");
            string grupoDeUtilizador = Console.ReadLine();
            Console.WriteLine("Indique o nome: ");
            string NomeUtilizador = Console.ReadLine();
            Console.WriteLine("Indique o email: ");
            string Email = Console.ReadLine();
            Console.WriteLine("Indique a passowrd: ");
            string Password = Console.ReadLine();

            listaDeUtilizadores.Add(new Utilizador(grupoDeUtilizador, NomeUtilizador, Email, Password));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Novo utilizador criado com sucesso!");
            Console.ResetColor();
        }

        public void LerListaUtilizadores()
        {
            foreach (Utilizador u in this.listaDeUtilizadores)
            {
                Console.WriteLine(u);
            }
        }

        public Utilizador EncontrarUtilizador(string nome)
        {
            foreach (Utilizador u in this.listaDeUtilizadores)
            {
                if (u.NomeUtilizador == nome)
                {
                    return u;
                }
            }
            return null;
        }

        public void EliminarUtilizador()
        {
            Console.WriteLine("Escolha o utilizador que quer eliminar: ");
            listaDeUtilizadores.Remove(EncontrarUtilizador(Console.ReadLine()));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Utilizador eliminado com sucesso");
            Console.ResetColor();
            LerListaUtilizadores();
        }

        public void EditaUtilizador()
        {
            EliminarUtilizador();
            AdicionarUtilizador();
        }

        public void MenuGestaoUtilizadores()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("||||GESTÂO DE UTILIZADORES|||| \n");
                Console.ResetColor();
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Criar Utilizador");
                Console.WriteLine("2 - Ver Lista de Utilizadores");
                Console.WriteLine("3 - Editar Utilizador");
                Console.WriteLine("4 - Eliminar Utilizador");

                bool consegui1 = false;

                while (!consegui1)
                {
                    consegui1 = int.TryParse(Console.ReadLine(), out escolhaDoUtilizador1);
                }

                switch (escolhaDoUtilizador1)
                {
                    case 0:
                        MenuGerente();
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****CRIAR UTILIZADOR**** \n");
                        Console.ResetColor();
                        AdicionarUtilizador();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****LISTA DE UTILIZADORES*** \n");
                        Console.ResetColor();
                        LerListaUtilizadores();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****EDITAR UTILIZADOR**** \n");
                        Console.ResetColor();
                        EditaUtilizador();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****ELIMINAÇÃO DE PRODUTO**** \n");
                        Console.ResetColor();
                        EliminarUtilizador();
                        break;
                    default:
                        Console.WriteLine("Sem seleção!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            } while (escolhaDoUtilizador1 != 0);
        }

        public void MenuGerente()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("||||BEM VINDO|||| \n");
                Console.ResetColor();
                Console.WriteLine("0 - Sair");
                Console.WriteLine("1 - Gestão de Utilizadores");
                Console.WriteLine("2 - Registar Compras");

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
                        MenuGestaoUtilizadores();
                        break;
                    case 2:
                        Compras();
                        break;
                    default:
                        Console.WriteLine("Sem seleção!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            } while (escolhaDoUtilizador1 != 0);
        }

        public Utilizador EscreverLogin(string nome, string password)
        {
            foreach (Utilizador u in this.listaDeUtilizadores)
            {
                if (u.NomeUtilizador == nome && u.Password == password && u.grupoDeUtilizador == GrupoDeUtilizador.Gerente)
                {
                    MenuGerente();
                }
                else if (u.NomeUtilizador == nome && u.Password == password && u.grupoDeUtilizador == GrupoDeUtilizador.Repositor)
                {
                    MenuStock();
                }
                else if (u.NomeUtilizador == nome && u.Password == password && u.grupoDeUtilizador == GrupoDeUtilizador.Caixa)
                {
                    Compras();
                }
                /*else if (u.NomeUtilizador != nome || u.Password != password)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Login errado!");
                    Console.ResetColor();
                }*/
            }
            return null;
        }

        public void Login()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("||||BEM VINDO|||| \n");
            Console.WriteLine("Intruduza o seu login \n");
            Console.ResetColor();
            Console.WriteLine("Insira o user name e password: ");
            EscreverLogin(Console.ReadLine(), Console.ReadLine());
        }

        public void AdicionarUtilizadores(Utilizador u)
        {
            listaDeUtilizadores.Add(u);
        }

        //METODOS COMPRAS/FATURA

        public void AdicionarLinhaFatura()
        {
            string NomeCliente = " ";
            string categoria = "";
            Console.WriteLine("Indique o nome do produto que deseja comprar: ");
            string NomeProduto = Console.ReadLine();
            Console.WriteLine("Indique a quantidade de compra: ");
            float Quantidade = float.Parse(Console.ReadLine());
            Console.WriteLine("Indique o tipo de quantidade: \n");
            Console.WriteLine("\t 1 - Kilos;");
            Console.WriteLine("\t 2 - Litros;");
            Console.WriteLine("\t 3 - Unidades;");
            string tipoQuantidade = Console.ReadLine();
            Console.WriteLine("Indique o preço: ");
            float Preco = Quantidade * float.Parse(Console.ReadLine());

            listaDeCompras.Add(new Fatura(NomeCliente, categoria, NomeProduto, Quantidade, tipoQuantidade, Preco));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Novo produto criado com sucesso!");
            Console.ResetColor();
        }

        public void LerListaCompras()
        {
            foreach (Fatura f in this.listaDeCompras)
            {
                Console.WriteLine(f);
            }
        }

        public void ValorTotal()
        {
            foreach (Fatura f in this.listaDeCompras)
            {
                float total =+ f.Preco;
                Console.WriteLine(total + "€");
            }
        }

        public void VerCarrinho()
        {
            LerListaCompras();
            Console.WriteLine("VALOR TOTAL: ");
            ValorTotal();
        }

        public Fatura AlterarNomeCliente(string nome)
        {
            foreach (Fatura f in this.listaDeCompras)
            {
                if (f.NomeCliente == " ")
                {
                    Console.WriteLine("Nome do Cliente: ");
                    string novoNome = Console.ReadLine();
                    f.NomeCliente = novoNome;
                }
                else if (f.NomeProduto != nome)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Produto não encontrado no carrinho");
                    Console.ResetColor();
                }
            }
            return null;
        }

        public void AdicionarNomeCliente()
        {
            AlterarNomeCliente(Console.ReadLine());
        }

        public Fatura AlterarQuantidade(string nome)
        {
            foreach (Fatura f in this.listaDeCompras)
            {
                if (f.NomeProduto == nome)
                {
                    Console.WriteLine("Escolha a nova quantidade: ");
                    float novaQuantidade = float.Parse(Console.ReadLine());
                    f.Preco = f.Preco / f.Quantidade;
                    f.Quantidade = novaQuantidade;
                    f.Preco = f.Preco * f.Quantidade;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Foi alterado a seguinte quantidade ao carrinho: " + f.NomeProduto + " -> " + novaQuantidade + " " + f.tipoQuantidade);
                    Console.ResetColor();
                }
                else if (f.NomeProduto != nome)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Produto não encontrado no carrinho");
                    Console.ResetColor();
                }
            }
            return null;
        }

        public void EditarQuantidade()
        {
            Console.WriteLine("Escolha o artigo para alterar a quantidade: ");
            AlterarQuantidade(Console.ReadLine());
        }

        public Fatura EncontrarArtigo(string nome)
        {
            foreach (Fatura f in this.listaDeCompras)
            {
                if (f.NomeProduto == nome)
                {
                    return f;
                }
                else if (f.NomeProduto != nome)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Produto não existe");
                    Console.ResetColor();
                }
            }
            return null;
        }

        public void RetirarArtigo()
        {
            Console.WriteLine("Escolha o produto que quer retirar do carrinho de compras: ");
            listaDeCompras.Remove(EncontrarArtigo(Console.ReadLine()));
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Produto retirado com sucesso");
            Console.ResetColor();
        }

        public void Compras()
        {
            int escolhaDoUtilizador1 = -1;
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("||||CARRINHO DE COMPRAS|||| \n");
                Console.ResetColor();
                Console.WriteLine("0 - Terminar compra");
                Console.WriteLine("1 - Ver Lista de artigos");
                Console.WriteLine("2 - Adicionar artigo ao carrinho de compras");
                Console.WriteLine("3 - Ver carrinho de compras");
                Console.WriteLine("4 - Editar quantidade de artigo");
                Console.WriteLine("5 - Retirar artigo do carrinho de compras");

                bool consegui1 = false;

                while (!consegui1)
                {
                    consegui1 = int.TryParse(Console.ReadLine(), out escolhaDoUtilizador1);
                }

                switch (escolhaDoUtilizador1)
                {
                    case 0:
                        AdicionarNomeCliente();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("||||MUITO OBRIGADO|||| \n");
                        Console.ResetColor();
                        VerCarrinho();
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****LISTA DE ARTIGOS**** \n");
                        Console.ResetColor();
                        ListarPorCategoria();
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****ADICIONAR ARTIGO AO CARRINHO DE COMPRAS*** \n");
                        Console.ResetColor();
                        AdicionarLinhaFatura();
                        break;
                    case 3:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****VER CARRINHO DE COMPRAS*** \n");
                        Console.ResetColor();
                        VerCarrinho();
                        break;
                    case 4:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****EDITAR QUANTIDADE DE ARTIGO**** \n");
                        Console.ResetColor();
                        EditarQuantidade();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("****RETIRAR ARTIGO DO CARRINHO DE COMPRAS**** \n");
                        Console.ResetColor();
                        RetirarArtigo();
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