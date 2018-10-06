namespace tabuleiro
{
    class Peca
    {
        public Posicao pos { get;  set; }
        public Cor cor { get; protected set; }
        public Tabuleiro tab { get; protected set; }
        public int qteMovimentos { get; protected set; }

        public Peca(Tabuleiro tab, Posicao pos, Cor cor)
        {
            this.pos = pos;
            this.tab = tab;
            this.cor = cor;
            qteMovimentos = 0;
        }
    }
}
