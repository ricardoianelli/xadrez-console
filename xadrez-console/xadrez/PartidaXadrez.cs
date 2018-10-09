using System;
using System.Collections.Generic;
using tabuleiro;

namespace xadrez
{
    class PartidaXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        public HashSet<Peca> pecas;
        public HashSet<Peca> capturadas;
        public bool xeque;

        public PartidaXadrez()
        {
            tab = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            xeque = false;
            terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        private void colocarPecas()
        {
            // Brancas
            colocarNovaPeca(1, 'a', new Torre(tab, Cor.Branca));
            colocarNovaPeca(1, 'b', new Cavalo(tab, Cor.Branca));
            colocarNovaPeca(1, 'c', new Bispo(tab, Cor.Branca));
            colocarNovaPeca(1, 'd', new Dama(tab, Cor.Branca));
            colocarNovaPeca(1, 'e', new Rei(tab, Cor.Branca));
            colocarNovaPeca(1, 'f', new Bispo(tab, Cor.Branca));
            colocarNovaPeca(1, 'g', new Cavalo(tab, Cor.Branca));
            colocarNovaPeca(1, 'h', new Torre(tab, Cor.Branca));
            colocarNovaPeca(2, 'a', new Peao(tab, Cor.Branca));
            colocarNovaPeca(2, 'b', new Peao(tab, Cor.Branca));
            colocarNovaPeca(2, 'c', new Peao(tab, Cor.Branca));
            colocarNovaPeca(2, 'd', new Peao(tab, Cor.Branca));
            colocarNovaPeca(2, 'e', new Peao(tab, Cor.Branca));
            colocarNovaPeca(2, 'f', new Peao(tab, Cor.Branca));
            colocarNovaPeca(2, 'g', new Peao(tab, Cor.Branca));
            colocarNovaPeca(2, 'h', new Peao(tab, Cor.Branca));

            // Pretas
            colocarNovaPeca(8, 'a', new Torre(tab, Cor.Preta));
            colocarNovaPeca(8, 'b', new Cavalo(tab, Cor.Preta));
            colocarNovaPeca(8, 'c', new Bispo(tab, Cor.Preta));
            colocarNovaPeca(8, 'd', new Dama(tab, Cor.Preta));
            colocarNovaPeca(8, 'e', new Rei(tab, Cor.Preta));
            colocarNovaPeca(8, 'f', new Bispo(tab, Cor.Preta));
            colocarNovaPeca(8, 'g', new Cavalo(tab, Cor.Preta));
            colocarNovaPeca(8, 'h', new Torre(tab, Cor.Preta));
            colocarNovaPeca(7, 'a', new Peao(tab, Cor.Preta));
            colocarNovaPeca(7, 'b', new Peao(tab, Cor.Preta));
            colocarNovaPeca(7, 'c', new Peao(tab, Cor.Preta));
            colocarNovaPeca(7, 'd', new Peao(tab, Cor.Preta));
            colocarNovaPeca(7, 'e', new Peao(tab, Cor.Preta));
            colocarNovaPeca(7, 'f', new Peao(tab, Cor.Preta));
            colocarNovaPeca(7, 'g', new Peao(tab, Cor.Preta));
            colocarNovaPeca(7, 'h', new Peao(tab, Cor.Preta));
        }

        public void colocarNovaPeca(int linha, char coluna, Peca peca)
        {
            tab.adicionarPeca(peca, new PosicaoXadrez(linha, coluna).toPosicao());
            pecas.Add(peca);
        }

        public Peca executarMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pDest = tab.retirarPeca(destino);
            tab.adicionarPeca(p, destino);
            if(pDest != null)
            {
                capturadas.Add(pDest);
            }
            return pDest;
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = executarMovimento(origem, destino);

            if(estaEmXeque(jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("Voce nao pode se colocar em xeque!");
            }

            if(estaEmXeque(adversaria(jogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if(testeXequeMate(adversaria(jogadorAtual)))
            {
                terminada = true;
            }
            else
            {
                turno++;
                mudarJogador();
            }
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca movida = tab.retirarPeca(destino);
            movida.decrementarQteMovimentos();  
            if(pecaCapturada != null)
            {
                tab.adicionarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.adicionarPeca(movida, origem);   
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in pecas)
            {
                if(x.cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void mudarJogador()
        {
            if (jogadorAtual == Cor.Branca)
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
            if(!tab.peca(origem).movimentoPossivel(destino))
            {
                throw new TabuleiroException("Posicao de destino invalida!");
            }
        }

        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            return Cor.Branca;
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca p in pecasEmJogo(cor))
            {
                if(p is Rei)
                {
                    return p;
                }
            }
            return null;
        }

        public bool estaEmXeque(Cor cor)
        {
            Peca r = rei(cor);
            if(r == null)
            {
                throw new TabuleiroException("ERRO: Rei nao encontrado!");
            }

            foreach(Peca p in pecasEmJogo(adversaria(cor)))
            {
                bool[,] possibilidades = p.movimentosPossiveis();
                if(possibilidades[r.pos.linha, r.pos.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool checarXeque(Cor cor, Posicao posRei)
        {
            foreach (Peca p in pecasEmJogo(adversaria(cor)))
            {
                bool[,] possibilidades = p.movimentosPossiveis();
                if (possibilidades[posRei.linha, posRei.coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testeXequeMate(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for(int i = 0; i< tab.linhas; i++)
                {
                    for(int j=0; j<tab.colunas;j++)
                    {
                        if(mat[i, j])
                        {
                            Posicao origem = x.pos;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = executarMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, pecaCapturada);
                            if(!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

    }
}
