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
                Tabuleiro tab = new Tabuleiro(8, 8);
                // Adicionar pecas iniciais (teste)
                tab.adicionarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.adicionarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.adicionarPeca(new Rei(tab, Cor.Preta), new Posicao(2, 4));

                tab.adicionarPeca(new Rei(tab, Cor.Branca), new Posicao(5, 7));

                Tela.imprimirTela(tab);
            }
            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
