using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Supermercado
{
    class Login_Criacao : Utilizador
    {
        public Login_Criacao(string nome, string password, string grupoDeUtilizador) : base(nome, password, grupoDeUtilizador)
        {

        }

        public override string ToString()
        {
            return "Nome: " + nome + " | Password: " + Password + " | Grupo: " + grupoDeUtilizador;
        }

        public bool EscreveLogin()
        {
            
            Console.Clear();
            Console.WriteLine("Coloque o seu Nome: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Coloque a password: ");
            string pass = Console.ReadLine();

            //(usr == ("admin") && pass ==("admin"))
            if (usr == nome && pass == Password)
            {
                Console.Clear();
                return true;
            }
            else
            {
                Console.WriteLine("Utilizador ou Password errada!");
                //Para fechar tudo
                Environment.Exit(0);
                return false;
            }
        }

    }
}
