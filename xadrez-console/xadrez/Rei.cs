using System;
using tabuleiro;


namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tab, Cor cor) : base(tab, cor)
        { }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao posicao = new Posicao(0, 0);

            //n
            posicao.mudarValores(pos.linha - 1, pos.coluna);
            if(tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //ne
            posicao.mudarValores(pos.linha - 1, pos.coluna+1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //o
            posicao.mudarValores(pos.linha, pos.coluna + 1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //se
            posicao.mudarValores(pos.linha +1, pos.coluna + 1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //s
            posicao.mudarValores(pos.linha+1, pos.coluna);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //so
            posicao.mudarValores(pos.linha + 1, pos.coluna-1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //l
            posicao.mudarValores(pos.linha, pos.coluna-1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            //no
            posicao.mudarValores(pos.linha - 1, pos.coluna-1);
            if (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
            }

            return mat;
        }
    }
}
