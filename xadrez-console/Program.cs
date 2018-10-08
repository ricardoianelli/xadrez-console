﻿using System;
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
                        Tela.imprimirTela(partidaAtual.tab);

                        Console.WriteLine("\nTurno: " + partidaAtual.turno);
                        Console.WriteLine("Aguardando jogada: " + partidaAtual.jogadorAtual);

                        Console.Write("\nOrigem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partidaAtual.validarPosicaoDeOrigem(origem);

                        bool[,] possibilidades = partidaAtual.tab.peca(origem).movimentosPossiveis();
                        Console.Clear();
                        Tela.imprimirTela(partidaAtual.tab, possibilidades);

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

                
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
