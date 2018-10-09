using System;
using tabuleiro;


namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        { }

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
            }

            return mat;
        }
    }
}
