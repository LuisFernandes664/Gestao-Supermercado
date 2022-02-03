using System;
using System.Collections.Generic;
using System.Text;
namespace Gestao_Supermercado
{
    [Serializable]

    public enum GrupoDeUtilizador
    {
        Gerente = 1,
        Repositor = 2,
        Caixa = 3
    }

    [Serializable]

    public class Utilizador
    {
        public GrupoDeUtilizador grupoDeUtilizador;
        private string nomeUtilizador;
        private string email;
        private string password;

        public Utilizador(string grupoDeUtilizador, string nomeUtilizador, string email, string password)
        {
            if (!Enum.TryParse(grupoDeUtilizador, out this.grupoDeUtilizador))
            {
                this.grupoDeUtilizador = GrupoDeUtilizador.Gerente;
            }
            this.nomeUtilizador = nomeUtilizador;
            this.email = email;
            this.password = password;
        }

        public string NomeUtilizador { get => nomeUtilizador; set => nomeUtilizador = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }

        public override string ToString()
        {
            return "Nome: " + NomeUtilizador + " | Email: " + Email + " | Password: " + Password;
        }
    }
}
