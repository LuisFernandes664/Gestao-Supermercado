using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Gestao_Supermercado
{
    static class Gravador
    {
        public static void GravarSM(SuperMercado s)
        {
            string nomeDoFicheiro = "Mercadinho.jl";
            BinaryFormatter b = new BinaryFormatter();
            FileStream f = File.Create(nomeDoFicheiro);
            b.Serialize(f, s);
            f.Close();
        }

        public static void GravarDuasListas(SuperMercado s)
        {
            string nomeDoFicheiro = "Mercadinho_DuasListas.jl";
            BinaryFormatter b = new BinaryFormatter();
            FileStream f = File.Create(nomeDoFicheiro);
            b.Serialize(f, s.listaDeProdutos);
            b.Serialize(f, s.listaDeUtilizadores);
            f.Close();
        }

        public static SuperMercado LerFicheiro()
        {
            SuperMercado result = new SuperMercado("Falhei");
            string nomeDoFicheiro = "Mercadinho.jl";
            BinaryFormatter b = new BinaryFormatter();

            if (File.Exists(nomeDoFicheiro))
            {
                FileStream f = File.OpenRead(nomeDoFicheiro);
                result = b.Deserialize(f) as SuperMercado;
                f.Close();
            }
            return result;
        }
    }
}