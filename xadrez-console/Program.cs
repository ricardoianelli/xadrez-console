using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaXadrez partidaAtual = new PartidaXadrez();
                while(!partidaAtual.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partidaAtual);

                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partidaAtual.validarPosicaoDeOrigem(origem);

                        bool[,] possibilidades = partidaAtual.tab.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.imprimirTabuleiro(partidaAtual.tab, possibilidades);

                        Console.Write("\nDestino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partidaAtual.validarPosicaoDeDestino(origem, destino);
                        partidaAtual.realizaJogada(origem, destino);
                    }
                    catch(TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Tela.imprimirPartida(partidaAtual);
                

                
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
