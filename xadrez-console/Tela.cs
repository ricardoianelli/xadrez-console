using System;
using tabuleiro;
using xadrez;

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
                    imprimirPeca(pecaAtual);
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void imprimirTela(Tabuleiro tab, bool[,] possibilidades)
        {
            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    Peca pecaAtual = tab.peca(i, j);
                    if(possibilidades[i,j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    imprimirPeca(pecaAtual);
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(linha, coluna);
        }

        public static void imprimirPeca(Peca peca)
        {
            if(peca == null)
            {
               Console.Write("- ");
               return;
            }
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
