using System.Text;
using System.Text.RegularExpressions;

namespace Compiler.Lexer
{
    public class AnaLex
    {

        //Input do source code
        private readonly string _sourceCode;
        private int _pos = 0;
        private int _linha = 1;

        //Tabela de tokens
        private readonly List<Token> _tokens = new();

        public AnaLex(string sourceCode)
        {
            _sourceCode = sourceCode;
        }

        public List<Token> Analise()
        {
            while (_pos < _sourceCode.Length)
            {
                char c = _sourceCode[_pos];

                if (char.IsWhiteSpace(c))
                {
                    if (c == '\n') _linha++;
                    _pos++;
                    continue;
                }

                // Simples: letras iniciam identificadores ou palavras-chave
                if (char.IsLetter(c))
                {
                    string palavra = whileIdentifier(char.IsLetterOrDigit);
                    TokenType tipo = verifyKeyWord(palavra);
                    _tokens.Add(new Token(tipo, palavra, _linha));
                    continue;
                }

                // Números
                if (char.IsDigit(c))
                {
                    string numero = whileIdentifier(char.IsDigit);
                    _tokens.Add(new Token(TokenType.NUMBER_LITERAL, numero, _linha));
                    continue;
                }

                // Operadores e símbolos especiais
                string symbol = readSymbol();

                if (!string.IsNullOrEmpty(symbol))
                {
                    TokenType tipo = checkSymbol(symbol);
                    _tokens.Add(new Token(tipo, symbol, _linha));
                    continue;
                }

                // Caso não reconhecido
                _tokens.Add(new Token(TokenType.UNKNOWN, c.ToString(), _linha));
                _pos++;
            }

            _tokens.Add(new Token(TokenType.EOF, "EOF", _linha));

            return _tokens;
        }

        private string whileIdentifier(Func<char, bool> validate)
        {
            StringBuilder sb = new();

            while (_pos < _sourceCode.Length && validate(_sourceCode[_pos]))
            {
                sb.Append(_sourceCode[_pos]);
                _pos++;
            }
            return sb.ToString();
        }

        // Tenta ler operadores compostos ou símbolos individuais
        private string readSymbol()
        {

            foreach (var s in Constants.SYMBOLS.OrderByDescending(s => s.Length))
            {
                if (_sourceCode.Substring(_pos).StartsWith(s))
                {
                    _pos += s.Length;
                    return s;
                }
            }

            return "";
        }

        private TokenType verifyKeyWord(string word)
        {
            return word switch
            {
                "int" => TokenType.DATA_TYPE_INT,
                "float" => TokenType.DATA_TYPE_FLOAT,
                "double" => TokenType.DATA_TYPE_DOUBLE,
                "char" => TokenType.DATA_TYPE_CHAR,
                "string" => TokenType.DATA_TYPE_STRING,
                "bool" => TokenType.DATA_TYPE_BOOL,
                "list" => TokenType.DATA_TYPE_LIST,
                "void" => TokenType.DATA_TYPE_VOID,
                "class" => TokenType.DEFINITION_CLASS,
                "function" => TokenType.DEFINITION_FUNCTION,
                "if" => TokenType.CONTROL_IF,
                "else" => TokenType.CONTROL_ELSE,
                "switch" => TokenType.CONTROL_SWITCH,
                "while" => TokenType.CONTROL_WHILE,
                "do" => TokenType.CONTROL_DO,
                "for" => TokenType.CONTROL_FOR,
                "true" or "false" => TokenType.BOOLEAN_LITERAL,
                _ => TokenType.IDENTIFIER
            };
        }

        private TokenType checkSymbol(string symbol)
        {
            return symbol switch
            {
                "+" => TokenType.OP_PLUS,
                "-" => TokenType.OP_MINUS,
                "*" => TokenType.OP_MULTIPLY,
                "/" => TokenType.OP_DIVIDE,
                "%" => TokenType.OP_MOD,
                "=" => TokenType.OP_ASSIGN,
                "+=" => TokenType.OP_PLUS_EQUAL,
                "-=" => TokenType.OP_MINUS_EQUAL,
                "*=" => TokenType.OP_MULT_EQUAL,
                "/=" => TokenType.OP_DIV_EQUAL,
                "%=" => TokenType.OP_MOD_EQUAL,
                "==" => TokenType.OP_EQUAL,
                "!=" => TokenType.OP_NOT_EQUAL,
                "<" => TokenType.LESS_THAN,
                ">" => TokenType.GREATER_THAN,
                "<=" => TokenType.OP_LESS_EQUAL,
                ">=" => TokenType.OP_GREATER_EQUAL,
                "&&" => TokenType.OP_AND,
                "||" => TokenType.OP_OR,
                "." => TokenType.DOT,
                "," => TokenType.COMMA,
                "@" => TokenType.AT,
                "(" => TokenType.LEFT_PAREN,
                ")" => TokenType.RIGHT_PAREN,
                "{" => TokenType.LEFT_BRACE,
                "}" => TokenType.RIGHT_BRACE,
                "[" => TokenType.LEFT_BRACKET,
                "]" => TokenType.RIGHT_BRACKET,
                _ => TokenType.UNKNOWN
            };
        }
    }
}
