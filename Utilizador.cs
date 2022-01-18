using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestao_Supermercado
{
    [Serializable]
    enum GrupoDeUtilizador
    {
        Gerente = 1,
        Repositor = 2,
        Caixa = 3
    }
    [Serializable]
    class Utilizador
    {
        public string nome;
        private string password;
        public GrupoDeUtilizador grupoDeUtilizador;

        public Utilizador(string nome, string password, string grupoDeUtilizador)
        {
            this.nome = nome;
            this.password = password;
            //this.grupoDeUtilizador = grupoDeUtilizador;
            if (!Enum.TryParse(grupoDeUtilizador, out this.grupoDeUtilizador))
            {
                this.grupoDeUtilizador = GrupoDeUtilizador.Caixa;
            }
        }

        public string Nome { get => nome; set => nome = value; }
        public string Password { get => password; set => password = value; }


        public Utilizador(string allInfo)
        {
            this.nome = allInfo.Split(",")[0];
            this.password = allInfo.Split(",")[1];
            this.grupoDeUtilizador = (GrupoDeUtilizador)Convert.ToInt32(allInfo.Split(",")[2]);
        }

        public override string ToString()
        {
            return "Nome: " + nome + " | Password: " + password+ " | Grupo: "+grupoDeUtilizador;
        }
    }
}
