namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao pos { get;  set; }
        public Cor cor { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        public int qteMovimentos { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            this.tab = tab;
            this.cor = cor;
            pos = null;
            qteMovimentos = 0;
        }

        public void incrementarQteMovimentos()
        {
            qteMovimentos++;
        }

        protected bool podeMover(Posicao pos)
        {
            Peca p = tab.peca(pos);
            return p == null || p.cor != cor;
        }

        public bool existemMovimentosPossiveis()
        {
            bool[,] p = movimentosPossiveis();
            for(int i = 0; i<tab.linhas; i++)
            {
                for(int j = 0; j<tab.colunas; j++)
                {
                    if(p[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao destino)
        {
            return movimentosPossiveis()[destino.linha, destino.coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
