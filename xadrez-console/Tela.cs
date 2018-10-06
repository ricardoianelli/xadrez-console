using System;
using tabuleiro;

namespace xadrez_console
{
    class Tela
    {
        public static void imprimirTela(Tabuleiro tab)
        {
            for(int i = 0; i<tab.linhas; i++)
            {
                for(int j=0; j<tab.colunas; j++)
                {
                    Peca pecaAtual = tab.peca(i, j);
                    if (pecaAtual != null)
                    {
                        Console.Write(pecaAtual + " ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
