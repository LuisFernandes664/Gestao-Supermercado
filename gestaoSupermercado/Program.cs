using System;


namespace Gestao_Supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Utilizador u1 = new Utilizador("Gerente", "Apu", "apu@mercado.pt", "apu");
            Utilizador u2 = new Utilizador("Repositor", "Jose", "jose@mercado.pt", "jose");
            Utilizador u3 = new Utilizador("Caixa", "Maria", "maria@mercado.pt", "maria");

            Produto p1 = new Produto("Congelados", "Robalo", 10, "Kg", 3);
            Produto p2 = new Produto("Enlatados", "Feijão Enlatado", 20, "Kg", 1);
            Produto p3 = new Produto("Prateleira", "Bolachas", 20, "Kg", 2);

            SuperMercado s1 = new SuperMercado("Mercadinho");
            s1.AdicionarUtilizadores(u1);
            s1.AdicionarUtilizadores(u2);
            s1.AdicionarUtilizadores(u3);
            s1.AdicionarProdutos(p1);
            s1.AdicionarProdutos(p2);
            s1.AdicionarProdutos(p3);

            Gravador.GravarSM(s1);

            s1.Login();

            Gravador.GravarSM(s1);
            Gravador.GravarDuasListas(s1);*/

            SuperMercado s1 = Gravador.LerFicheiro();
            Gravador.GravarSM(s1);
            s1.Login();
        }
    }
}
