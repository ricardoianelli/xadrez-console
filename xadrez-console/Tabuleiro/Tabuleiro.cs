namespace tabuleiro
{
    class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca [,] pecas;


        public Tabuleiro(int linhas, int colunas)
        {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }

        public Peca peca(Posicao pos)
        {
            return pecas[pos.linha, pos.coluna];
        }

        public bool existePeca(Posicao pos)
        {
            validarPosicao(pos);
            return peca(pos) != null;
        }

        public void adicionarPeca(Peca peca, Posicao pos)
        {
            if (!existePeca(pos))
            {
                pecas[pos.linha, pos.coluna] = peca;
                peca.pos = pos;
            }
            else
            {
                throw new TabuleiroException("Já existe peca nessa posicao. (Pos: " + pos.linha + "/" + pos.coluna + ")");
            }
        }

        public Peca retirarPeca(Posicao p)
        {
            Peca aux = peca(p);
            if(aux == null)
            {
                return null;
            }
            aux.pos = null;
            pecas[p.linha, p.coluna] = null;
            return aux;
        }

        public bool posicaoValida(Posicao pos)
        {
            if(pos.linha < 0 || pos.linha >= linhas || pos.coluna < 0 || pos.coluna >= colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao pos)
        {
            if(!posicaoValida(pos))
            {
                throw new TabuleiroException("Posicao invalida! (Pos: " + pos.linha + "/" + pos.coluna+")");
            }
        }

    }
}
