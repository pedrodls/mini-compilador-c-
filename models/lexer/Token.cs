namespace Compiler.Lexer
{
    public class Token
    {
        public TokenType Tipo { get; }
        public string Lexema { get; }
        public int Linha { get; }

        public Token(TokenType tipo, string lexema, int linha)
        {
            Tipo = tipo;
            Lexema = lexema;
            Linha = linha;
        }

        public override string ToString()
        {
            return $"[{Tipo}] \"{Lexema}\" (linha {Linha})";
        }
    }
}
