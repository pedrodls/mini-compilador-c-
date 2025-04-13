# 🔍 Compilador - Analisador Léxico em C#

Este projeto é a **primeira fase de um compilador**: um **Analisador Léxico (AnaLex)** desenvolvido em **C#**, responsável por ler o código-fonte de uma linguagem fictícia e gerar uma tabela de **tokens**.

---

## 📦 Estrutura do Projeto

```
📁 Compiler/
│
├── 📁 source-code/
|   ├── index.txt          // Código-fonte de exemplo para análise
├── 📁 Lexer/
│   ├── AnaLex.cs          // Classe principal do analisador léxico
│   ├── Token.cs           // Representação de um token
│   ├── TokenType.cs       // Enum com os tipos de tokens reconhecidos
│   └── Constants.cs       // Lista de palavras-chave, símbolos, etc.
│
├── Program.cs             // Ponto de entrada do programa
├── Compiler.csproj
└── README.md              // Este arquivo :)
```

---

## 🚀 Como executar

### 🔧 Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) (versão 6.0 ou superior)

### ▶️ Rodando o projeto

```bash
# Restaurar dependências (caso haja)
dotnet restore

# Compilar o projeto
dotnet build

# Executar
dotnet run
```

---

## 📄 Exemplo de entrada (`codigo.txt`)

```c
int x = 10;
if (x > 5) {
    x += 1;
}
```

---

## 📋 Exemplo de saída (Tabela de Tokens)

```text
[DATA_TYPE_INT] "int" (linha 1)
[IDENTIFIER] "x" (linha 1)
[OP_ASSIGNMENT] "=" (linha 1)
[NUMBER_LITERAL] "10" (linha 1)
[CONTROL_IF] "if" (linha 2)
[SPECIAL_CHARS] "(" (linha 2)
[IDENTIFIER] "x" (linha 2)
[OP_COMPARISON] ">" (linha 2)
[NUMBER_LITERAL] "5" (linha 2)
...
```

---

## 🛠 Funcionalidades

- Reconhecimento de:
  - Tipos primitivos (`int`, `float`, `char`, `bool`, etc.)
  - Palavras-chave (`if`, `else`, `while`, etc.)
  - Operadores aritméticos, relacionais e lógicos
  - Comentários de linha e múltiplas linhas
  - Identificadores, literais e símbolos especiais
- Geração de tabela de tokens com linha de ocorrência

---

## 💡 Possíveis melhorias

- Suporte a **strings** e **caracteres**
- Suporte a **números com ponto flutuante**
- Geração de **arquivo CSV ou JSON** com os tokens
- Interface gráfica (WinForms/WPF ou Web)
- Integração com as próximas fases do compilador: sintática e semântica

---

## 👨‍💻 Autor

Feito com 💻 por Pedro João  
🔗 [https://github.com/pedrodls](https://github.com/pedrodls)

---

## 📄 Licença

Este projeto está licenciado sob a [MIT License](LICENSE).

---

## 🧾 .gitignore sugerido

```gitignore
bin/
obj/
*.user
*.suo
*.cache
*.log
*.vs/
.vscode/
*.DS_Store
*.exe
*.dll
*.pdb
*.db
```
