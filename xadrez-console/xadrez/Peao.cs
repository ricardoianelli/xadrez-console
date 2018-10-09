using System;
using tabuleiro;


namespace xadrez
{
    class Peao : Peca
    {
        private PartidaXadrez partida;

        public Peao(Tabuleiro tab, Cor cor, PartidaXadrez partida) : base(tab, cor)
        {
            this.partida = partida;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool livre(Posicao pos)
        {
            return tab.peca(pos) == null;
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p != null && p.cor != cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] mat = new bool[tab.linhas, tab.colunas];
            Posicao posicao = new Posicao(0, 0);

            //brancos
            if (cor == Cor.Branca)
            {
                posicao.mudarValores(pos.linha - 1, pos.coluna);
                if (tab.posicaoValida(posicao) && livre(posicao))
                {
                    mat[posicao.linha, posicao.coluna] = true;
                }

                posicao.mudarValores(pos.linha - 2, pos.coluna);
                if (tab.posicaoValida(posicao) && livre(posicao) && qteMovimentos == 0)
                {
                    mat[posicao.linha, posicao.coluna] = true;
                }

                posicao.mudarValores(pos.linha - 1, pos.coluna - 1);
                if (tab.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    mat[posicao.linha, posicao.coluna] = true;
                }

                posicao.mudarValores(pos.linha - 1, pos.coluna + 1);
                if (tab.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    mat[posicao.linha, posicao.coluna] = true;
                }

                //#jogada especial enpassant
                if(pos.linha == 3)
                {
                    Posicao esquerda = new Posicao(pos.linha, pos.coluna-1);
                    if(tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha-1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(pos.linha, pos.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha-1, direita.coluna] = true;
                    }
                }
            }
            else
            {
                //pretos
                posicao.mudarValores(pos.linha + 1, pos.coluna);
                if (tab.posicaoValida(posicao) && livre(posicao))
                {
                    mat[posicao.linha, posicao.coluna] = true;
                }

                posicao.mudarValores(pos.linha + 2, pos.coluna);
                if (tab.posicaoValida(posicao) && livre(posicao) && qteMovimentos == 0)
                {
                    mat[posicao.linha, posicao.coluna] = true;
                }

                posicao.mudarValores(pos.linha + 1, pos.coluna - 1);
                if (tab.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    mat[posicao.linha, posicao.coluna] = true;
                }

                posicao.mudarValores(pos.linha + 1, pos.coluna + 1);
                if (tab.posicaoValida(posicao) && existeInimigo(posicao))
                {
                    mat[posicao.linha, posicao.coluna] = true;
                }

                //#jogada especial enpassant
                if (pos.linha == 4)
                {
                    Posicao esquerda = new Posicao(pos.linha, pos.coluna - 1);
                    if (tab.posicaoValida(esquerda) && existeInimigo(esquerda) && tab.peca(esquerda) == partida.vulneravelEnPassant)
                    {
                        mat[esquerda.linha+1, esquerda.coluna] = true;
                    }
                    Posicao direita = new Posicao(pos.linha, pos.coluna + 1);
                    if (tab.posicaoValida(direita) && existeInimigo(direita) && tab.peca(direita) == partida.vulneravelEnPassant)
                    {
                        mat[direita.linha+1, direita.coluna] = true;
                    }
                }
            }

            return mat;
        }
    }
}
