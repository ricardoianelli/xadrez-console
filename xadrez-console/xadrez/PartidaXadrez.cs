using System;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
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

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executarMovimento(origem, destino);
            turno++;
            mudarJogador();
        }

        public void mudarJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public void validarPosicaoDeOrigem(Posicao p)
        {
            if(tab.peca(p) == null)
            {
                throw new TabuleiroException("Nao existe peca na posicao de origem escolhida!");
            }
            if (tab.peca(p).cor != jogadorAtual)
            {
                throw new TabuleiroException("A peca de origem escolhida nao é sua!");
            }
            if (!tab.peca(p).existemMovimentosPossiveis())
            {
                throw new TabuleiroException("Nao há movimentos possiveis para a peca de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if(!tab.peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino invalida!");
            }
        }

    }
}
