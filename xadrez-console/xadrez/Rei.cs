using System;
using tabuleiro;


namespace xadrez
{
    class Rei : Peca
    {
        private PartidaXadrez partida;

        public Rei(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p is Torre && p.qteMovimentos == 0 && p.cor == cor;
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

            //#jogadaespecial roque
            if (qteMovimentos == 0 && !partida.xeque)
            {
                //#jogadaespecial roque pequeno
                Posicao[] posicoesDireita = new Posicao[3];
                for(int i = 0; i<3;i++)
                {
                    posicoesDireita[i] = new Posicao(pos.linha, pos.coluna + 1 + i);
                }
                if(testeTorreParaRoque(posicoesDireita[2])) //torre
                {
                    if(tab.peca(posicoesDireita[0]) == null && tab.peca(posicoesDireita[1]) == null)
                    {
                        mat[posicoesDireita[1].linha, posicoesDireita[1].coluna] = true;
                    }
                }

                //#jogadaespecial roque grande
                Posicao[] posicoesEsquerda = new Posicao[4];
                for (int i = 0; i < 4; i++)
                {
                    posicoesEsquerda[i] = new Posicao(pos.linha, pos.coluna - 1 - i);
                }
                if (testeTorreParaRoque(posicoesEsquerda[3])) //torre
                {
                    if (tab.peca(posicoesEsquerda[0]) == null && tab.peca(posicoesEsquerda[1]) == null && tab.peca(posicoesEsquerda[2]) == null)
                    {
                        mat[posicoesEsquerda[1].linha, posicoesEsquerda[1].coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
