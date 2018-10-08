using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        private int turno { get; set; }
        private Cor jogadorAtual { get; set; }
        public bool terminada { get; private set; }

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            colocarPecas();
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
        }

        private void colocarPecas()
        {
            // Brancas
            tab.adicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(1, 'c').toPosicao());
            tab.adicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(2, 'c').toPosicao());
            tab.adicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(2, 'd').toPosicao());
            tab.adicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(1, 'e').toPosicao());
            tab.adicionarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez(2, 'e').toPosicao());
            tab.adicionarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez(1, 'd').toPosicao());
            // Pretas
            tab.adicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(8, 'c').toPosicao());
            tab.adicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(7, 'c').toPosicao());
            tab.adicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(7, 'd').toPosicao());
            tab.adicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(8, 'e').toPosicao());
            tab.adicionarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez(7, 'e').toPosicao());
            tab.adicionarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez(8, 'd').toPosicao());
        }

        public void executarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pDest = tab.retirarPeca(destino);
            tab.adicionarPeca(p, destino);
        }

    }
}
