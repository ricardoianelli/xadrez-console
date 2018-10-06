using System;

namespace tabuleiro
{
    class tabuleiroException : Exception
    {
        public tabuleiroException(string msg) : base(msg)
        { }
    }
}
