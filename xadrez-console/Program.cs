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
                    Console.Clear();
                    Tela.imprimirTela(partidaAtual.tab);

                    Console.Write("\nOrigem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    bool[,] possibilidades = partidaAtual.tab.peca(origem).movimentosPossiveis();
                    Console.Clear();
                    Tela.imprimirTela(partidaAtual.tab, possibilidades);

                    Console.Write("\nDestino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partidaAtual.executarMovimento(origem, destino);
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
