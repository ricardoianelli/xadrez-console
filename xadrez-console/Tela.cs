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
                Console.Write(8 - i + " ");
                for(int j=0; j<tab.colunas; j++)
                {
                    Peca pecaAtual = tab.peca(i, j);
                    if (pecaAtual != null)
                    {
                        imprimirPeca(pecaAtual);
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
            Console.Write("  a b c d e f g h");
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca.cor == Cor.Branca)
            {
                Console.Write(peca+ " ");
                return;
            }
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(peca + " ");
            Console.ForegroundColor = aux;
        }
    }
}
