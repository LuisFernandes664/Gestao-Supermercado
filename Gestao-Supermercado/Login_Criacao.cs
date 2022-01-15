using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    enum grupoDeUtilizador
    {
        Gerente = 1,
        Repositor = 2,
        Caixa = 3
    }
    class Login_Criacao
    {
        private string nome;
        private string password;

        public Login_Criacao(string nome, string password)
        {
            this.nome = nome;
            this.password = password;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Password { get => password; set => password = value; }


        public void EscreveLogin()
        {
            Console.Clear();
            Console.WriteLine("Coloque o seu Nome: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Coloque a password: ");
            string pass = Console.ReadLine();

            //(usr == ("admin") && pass ==("admin"))
            if (usr == nome && pass == password)
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Utilizador ou Password errada!");
                //Para fechar tudo
                Environment.Exit(0);
            }
        }

    }
}
