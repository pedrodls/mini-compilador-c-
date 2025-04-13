namespace Compiler.Lexer
{
    public enum TokenType
    {
        // Tipos de dados
        DATA_TYPE_INT,
        DATA_TYPE_FLOAT,
        DATA_TYPE_DOUBLE,
        DATA_TYPE_CHAR,
        DATA_TYPE_STRING,
        DATA_TYPE_BOOL,
        DATA_TYPE_VOID,
        DATA_TYPE_LIST,

        // Definições e declarações
        DEFINITION_CLASS,     // class
        DEFINITION_FUNCTION,  // function

        // Comentários
        COMMENT_SINGLE,   // // Comentário de uma linha
        COMMENT_MULTI,    // /* Comentário de várias linhas */

        // Operadores

        // Aritméticos
        OP_PLUS,        // +
        OP_MINUS,       // -
        OP_MULTIPLY,    // *
        OP_DIVIDE,      // /
        OP_MOD,         // %

        // Atribuição
        OP_ASSIGN,      // =
        OP_PLUS_EQUAL,  // +=
        OP_MINUS_EQUAL, // -=
        OP_MULT_EQUAL,  // *=
        OP_DIV_EQUAL,   // /=
        OP_MOD_EQUAL,   // %=

        // Comparação
        OP_EQUAL,       // ==
        OP_NOT_EQUAL,   // !=
        OP_LESS,        // <
        OP_GREATER,     // >
        OP_LESS_EQUAL,  // <=
        OP_GREATER_EQUAL, // >=

        // Lógicos
        OP_AND,         // &&
        OP_OR,          // ||

        // Controle de fluxo
        CONTROL_IF,
        CONTROL_ELSE,
        CONTROL_SWITCH,
        CONTROL_WHILE,
        CONTROL_DO,
        CONTROL_FOR,

        // Variáveis
        VAR_SIMPLE,       // int x = 10;
        VAR_ARRAY,        // int[] array = new int[5];

        // Caracteres especiais e pontuação

        // Pontuação e símbolos especiais
        DOT,         // .
        COMMA,       // ,
        AT,          // @

        LEFT_PAREN,      // (
        RIGHT_PAREN,     // )
        LEFT_BRACE,      // {
        RIGHT_BRACE,     // }
        LEFT_BRACKET,    // [
        RIGHT_BRACKET,   // ]

        LESS_THAN,       // <
        GREATER_THAN,    // >

        // Literais e identificadores
        IDENTIFIER,
        NUMBER_LITERAL,
        STRING_LITERAL,
        BOOLEAN_LITERAL,

        // Outros
        UNKNOWN,          // Token desconhecido
        EOF               // Fim do arquivo
    }
}
