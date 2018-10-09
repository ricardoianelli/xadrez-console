using System;
using tabuleiro;


namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tab, Cor cor) : base(tab, cor)
        { }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao posicao = new Posicao(0, 0);

            //cima
            posicao.mudarValores(pos.linha - 2, pos.coluna -1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            posicao.mudarValores(pos.linha - 2, pos.coluna + 1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //direita
            posicao.mudarValores(pos.linha - 1, pos.coluna + 2);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //baixo
            posicao.mudarValores(pos.linha + 2, pos.coluna - 1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            posicao.mudarValores(pos.linha + 2, pos.coluna + 1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //esquerda
            posicao.mudarValores(pos.linha - 1, pos.coluna - 2);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            posicao.mudarValores(pos.linha + 1, pos.coluna - 2);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            return mat;
        }
        public override string ToString()
        {
            return "C";
        }
    }
}
