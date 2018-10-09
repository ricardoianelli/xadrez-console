using System;
using tabuleiro;


namespace xadrez
{
    class Dama : Peca
    {
        public Dama(Tabuleiro tab, Cor cor) : base(tab, cor)
        { }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao posicao = new Posicao(0, 0);

            //n
            posicao.mudarValores(pos.linha - 1, pos.coluna);
            while(tab.posicaoValida(posicao) && podeMover(posicao))
            { 
                mat[posicao.linha, posicao.coluna] = true;
                if(tab.existePeca(posicao))
                {
                    break;
                }
                posicao.linha--;
            }

            //o
            posicao.mudarValores(pos.linha, pos.coluna + 1);
            while (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
                if (tab.existePeca(posicao))
                {
                    break;
                }
                posicao.coluna++;
            }


            //s
            posicao.mudarValores(pos.linha + 1, pos.coluna);
            while (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
                if (tab.existePeca(posicao))
                {
                    break;
                }
                posicao.linha++;
            }


            //l
            posicao.mudarValores(pos.linha, pos.coluna - 1);
            while (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
                if (tab.existePeca(posicao))
                {
                    break;
                }
                posicao.coluna--;
            }

            //norte-leste (^->)
            posicao.mudarValores(pos.linha - 1, pos.coluna + 1);
            while (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
                if (tab.existePeca(posicao))
                {
                    break;
                }
                posicao.mudarValores(posicao.linha - 1, posicao.coluna + 1);
            }

            //sul-leste (V->)
            posicao.mudarValores(pos.linha + 1, pos.coluna + 1);
            while (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
                if (tab.existePeca(posicao))
                {
                    break;
                }
                posicao.mudarValores(posicao.linha + 1, posicao.coluna + 1);
            }

            //sul-oeste (V<-)
            posicao.mudarValores(pos.linha + 1, pos.coluna - 1);
            while (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
                if (tab.existePeca(posicao))
                {
                    break;
                }
                posicao.mudarValores(posicao.linha + 1, posicao.coluna - 1);
            }

            //norte-oeste (^<-)
            posicao.mudarValores(pos.linha - 1, pos.coluna - 1);
            while (tab.posicaoValida(posicao) && podeMover(posicao))
            {
                mat[posicao.linha, posicao.coluna] = true;
                if (tab.existePeca(posicao))
                {
                    break;
                }
                posicao.mudarValores(posicao.linha - 1, posicao.coluna - 1);
            }

            return mat;
        }
        public override string ToString()
        {
            return "D";
        }
    }
}
