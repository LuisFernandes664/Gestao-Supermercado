using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class Utilizador
    {
        public string nome;
        private string email;
        private string password;
        enum grupoDeUtilizador
        {
            Gerente,
            Repositor,
            Caixa
        }

        public Utilizador(string nome, string email, string password)
        {
            this.nome = nome;
            this.email = email;
            this.password = password;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }


        public Utilizador(string allInfo)
        {
            this.nome = allInfo.Split(",")[0];
            this.email = allInfo.Split(",")[1];
            this.password = allInfo.Split(",")[2];
        }


        public override string ToString()
        {
            return "Nome: " + nome + " | Email: " + email + " | Password: " + password;
        }
    }
}
