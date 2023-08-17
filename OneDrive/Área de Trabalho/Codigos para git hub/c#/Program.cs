using System;
using System.IO;

namespace ApuracaoVotos
{
    class Program
    {
        static string[] candidatos = { "Perna-Longa", "Mickey", "Pluto", "Cebolinha", "Pateta" };

        static void Main(string[] args)
        {
            bool continuar = true;
            int[] candidatosVotos = new int[candidatos.Length];
            int votosNulos = 0;

            Console.WriteLine("Bem-vindo à votação de personagens animados favoritos!");

            while (continuar)
            {
                Console.WriteLine("Escolha o candidato digitando o número correspondente, digite 5 para finalizar a votação ou qualquer outro número maior que 5 para votar nulo:");

                for (int i = 0; i < candidatos.Length; i++)
                {
                    Console.WriteLine($"{i} : {candidatos[i]}");
                }

                int votos = int.Parse(Console.ReadLine());

                if (votos >= 0 && votos < candidatos.Length)
                {
                    GravarVotos(votos);
                    candidatosVotos[votos]++;
                    Console.WriteLine("Voto registrado com sucesso");
                }
                else if (votos > 5)
                {
                    GravarVotos(votos);
                    Console.WriteLine("Voto nulo registrado com sucesso");
                    votosNulos++;
                }
                else
                {
                    Console.WriteLine("Fim da votação");
                    Console.WriteLine("Apuração da votação");
                    CandidatoMaisVotado(candidatosVotos, out int maisVotado, out string nome);
                    Console.WriteLine($"O candidato mais votado é {nome} com {maisVotado} votos válidos");
                    Console.WriteLine($"Total de votos nulos: {votosNulos}");
                    break;
                }
            }
        }

        static void GravarVotos(int votos)
        {
            string arquivonome = "Votos.txt";

            using (StreamWriter writer = new StreamWriter(arquivonome, true))
            {
                try
                {
                    writer.WriteLine(votos);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Erro ao gravar mensagem : {e.Message}");
                }
            }
        }

        static void CandidatoMaisVotado(int[] candidatosVotos, out int maisVotado, out string nome)
        {
            maisVotado = 0;
            nome = "a";

            for (int i = 0; i < candidatos.Length; i++)
            {
                if (candidatosVotos[i] > maisVotado)
                {
                    maisVotado = candidatosVotos[i];
                    nome = candidatos[i];
                }
            }
        }
    }
}
