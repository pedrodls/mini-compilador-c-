using Compiler.Lexer;
using System.IO;

string caminho = "./source-code/index.txt"; // Caminho relativo ou absoluto
string codigoFonte = File.ReadAllText(caminho);

var analex = new AnaLex(codigoFonte);

var tokens = analex.Analise();

foreach (var token in tokens)
{
    Console.WriteLine(token);
}

