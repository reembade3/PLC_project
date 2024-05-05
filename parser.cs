
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;

namespace com.calitha.goldparser
{

    [Serializable()]
    public class SymbolException : System.Exception
    {
        public SymbolException(string message) : base(message)
        {
        }

        public SymbolException(string message,
            Exception inner) : base(message, inner)
        {
        }

        protected SymbolException(SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }

    }

    [Serializable()]
    public class RuleException : System.Exception
    {

        public RuleException(string message) : base(message)
        {
        }

        public RuleException(string message,
                             Exception inner) : base(message, inner)
        {
        }

        protected RuleException(SerializationInfo info,
                                StreamingContext context) : base(info, context)
        {
        }

    }

    enum SymbolConstants : int
    {
        SYMBOL_EOF                 =  0, // (EOF)
        SYMBOL_ERROR               =  1, // (Error)
        SYMBOL_WHITESPACE          =  2, // Whitespace
        SYMBOL_MINUS               =  3, // '-'
        SYMBOL_MINUSMINUS          =  4, // '--'
        SYMBOL_EXCLAMEQ            =  5, // '!='
        SYMBOL_LPAREN              =  6, // '('
        SYMBOL_RPAREN              =  7, // ')'
        SYMBOL_TIMES               =  8, // '*'
        SYMBOL_COMMA               =  9, // ','
        SYMBOL_DIV                 = 10, // '/'
        SYMBOL_COLON               = 11, // ':'
        SYMBOL_LBRACE              = 12, // '{'
        SYMBOL_RBRACE              = 13, // '}'
        SYMBOL_PLUS                = 14, // '+'
        SYMBOL_PLUSPLUS            = 15, // '++'
        SYMBOL_LT                  = 16, // '<'
        SYMBOL_LTEQ                = 17, // '<='
        SYMBOL_EQ                  = 18, // '='
        SYMBOL_EQEQ                = 19, // '=='
        SYMBOL_GT                  = 20, // '>'
        SYMBOL_GTEQ                = 21, // '>='
        SYMBOL_BOOL                = 22, // bool
        SYMBOL_BREAK               = 23, // break
        SYMBOL_CASE                = 24, // case
        SYMBOL_DEFAULT             = 25, // default
        SYMBOL_DO                  = 26, // do
        SYMBOL_ELSE                = 27, // else
        SYMBOL_END                 = 28, // end
        SYMBOL_FOR                 = 29, // for
        SYMBOL_IDENTIFIER          = 30, // Identifier
        SYMBOL_IF                  = 31, // if
        SYMBOL_INT                 = 32, // int
        SYMBOL_INTEGER             = 33, // Integer
        SYMBOL_STRING              = 34, // string
        SYMBOL_STRINGLITERAL       = 35, // StringLiteral
        SYMBOL_SWITCH              = 36, // switch
        SYMBOL_WHILE               = 37, // while
        SYMBOL_ADDEXP              = 38, // <AddExp>
        SYMBOL_ASSIGNMENT          = 39, // <Assignment>
        SYMBOL_CASELIST            = 40, // <Caselist>
        SYMBOL_DEFAULT2            = 41, // <Default>
        SYMBOL_DOWHILELOOP         = 42, // <DoWhileLoop>
        SYMBOL_EXPRESSION          = 43, // <Expression>
        SYMBOL_FORLOOP             = 44, // <ForLoop>
        SYMBOL_IFSTATEMENT         = 45, // <IfStatement>
        SYMBOL_INCDEC              = 46, // <IncDec>
        SYMBOL_INITSTATEMENT       = 47, // <InitStatement>
        SYMBOL_MULTEXP             = 48, // <MultExp>
        SYMBOL_NEGATEEXP           = 49, // <NegateExp>
        SYMBOL_PROGRAM             = 50, // <Program>
        SYMBOL_STATEMENT           = 51, // <Statement>
        SYMBOL_STATEMENTLIST       = 52, // <StatementList>
        SYMBOL_SWITCHSTATEMENT     = 53, // <SwitchStatement>
        SYMBOL_TYPE                = 54, // <Type>
        SYMBOL_VALUE               = 55, // <Value>
        SYMBOL_VARIABLEDECLARATION = 56, // <VariableDeclaration>
        SYMBOL_WHILELOOP           = 57  // <WhileLoop>
    };

    enum RuleConstants : int
    {
        RULE_PROGRAM                                                       =  0, // <Program> ::= <StatementList>
        RULE_STATEMENTLIST                                                 =  1, // <StatementList> ::= <Statement>
        RULE_STATEMENTLIST2                                                =  2, // <StatementList> ::= <StatementList> <Statement>
        RULE_STATEMENT                                                     =  3, // <Statement> ::= <VariableDeclaration>
        RULE_STATEMENT2                                                    =  4, // <Statement> ::= <Assignment>
        RULE_STATEMENT3                                                    =  5, // <Statement> ::= <IfStatement>
        RULE_STATEMENT4                                                    =  6, // <Statement> ::= <SwitchStatement>
        RULE_STATEMENT5                                                    =  7, // <Statement> ::= <ForLoop>
        RULE_STATEMENT6                                                    =  8, // <Statement> ::= <WhileLoop>
        RULE_STATEMENT7                                                    =  9, // <Statement> ::= <DoWhileLoop>
        RULE_VARIABLEDECLARATION_IDENTIFIER_EQ                             = 10, // <VariableDeclaration> ::= <Type> Identifier '=' <Expression>
        RULE_TYPE_INT                                                      = 11, // <Type> ::= int
        RULE_TYPE_STRING                                                   = 12, // <Type> ::= string
        RULE_TYPE_BOOL                                                     = 13, // <Type> ::= bool
        RULE_TYPE                                                          = 14, // <Type> ::= 
        RULE_ASSIGNMENT_IDENTIFIER_EQ                                      = 15, // <Assignment> ::= Identifier '=' <Expression>
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE                    = 16, // <IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}'
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE = 17, // <IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}' else '{' <StatementList> '}'
        RULE_SWITCHSTATEMENT_SWITCH_LBRACE_RBRACE                          = 18, // <SwitchStatement> ::= switch <Expression> '{' <Caselist> <Default> '}'
        RULE_CASELIST_CASE_COLON_BREAK                                     = 19, // <Caselist> ::= <Caselist> case <Expression> ':' <StatementList> break
        RULE_CASELIST_CASE_COLON_BREAK2                                    = 20, // <Caselist> ::= case <Expression> ':' <StatementList> break
        RULE_CASELIST                                                      = 21, // <Caselist> ::= 
        RULE_DEFAULT_DEFAULT_COLON                                         = 22, // <Default> ::= default ':' <StatementList>
        RULE_FORLOOP_FOR_LPAREN_COMMA_COMMA_RPAREN_LBRACE_RBRACE           = 23, // <ForLoop> ::= for '(' <InitStatement> ',' <Expression> ',' <IncDec> ')' '{' <StatementList> '}'
        RULE_INITSTATEMENT                                                 = 24, // <InitStatement> ::= <VariableDeclaration>
        RULE_INCDEC_IDENTIFIER_PLUSPLUS                                    = 25, // <IncDec> ::= Identifier '++'
        RULE_INCDEC_IDENTIFIER_MINUSMINUS                                  = 26, // <IncDec> ::= Identifier '--'
        RULE_WHILELOOP_WHILE_LPAREN_RPAREN_LBRACE_RBRACE                   = 27, // <WhileLoop> ::= while '(' <Expression> ')' '{' <StatementList> '}'
        RULE_DOWHILELOOP_DO_LBRACE_RBRACE_WHILE_END                        = 28, // <DoWhileLoop> ::= do '{' <StatementList> '}' while <Expression> end
        RULE_EXPRESSION_GT                                                 = 29, // <Expression> ::= <Expression> '>' <MultExp>
        RULE_EXPRESSION_GTEQ                                               = 30, // <Expression> ::= <Expression> '>=' <MultExp>
        RULE_EXPRESSION_LT                                                 = 31, // <Expression> ::= <Expression> '<' <MultExp>
        RULE_EXPRESSION_LTEQ                                               = 32, // <Expression> ::= <Expression> '<=' <MultExp>
        RULE_EXPRESSION_EQEQ                                               = 33, // <Expression> ::= <Expression> '==' <MultExp>
        RULE_EXPRESSION_EXCLAMEQ                                           = 34, // <Expression> ::= <Expression> '!=' <MultExp>
        RULE_EXPRESSION                                                    = 35, // <Expression> ::= <MultExp>
        RULE_MULTEXP_TIMES                                                 = 36, // <MultExp> ::= <MultExp> '*' <AddExp>
        RULE_MULTEXP_DIV                                                   = 37, // <MultExp> ::= <MultExp> '/' <AddExp>
        RULE_MULTEXP                                                       = 38, // <MultExp> ::= <AddExp>
        RULE_ADDEXP_PLUS                                                   = 39, // <AddExp> ::= <AddExp> '+' <NegateExp>
        RULE_ADDEXP_MINUS                                                  = 40, // <AddExp> ::= <AddExp> '-' <NegateExp>
        RULE_ADDEXP                                                        = 41, // <AddExp> ::= <NegateExp>
        RULE_NEGATEEXP_MINUS                                               = 42, // <NegateExp> ::= '-' <Value>
        RULE_NEGATEEXP                                                     = 43, // <NegateExp> ::= <Value>
        RULE_VALUE_IDENTIFIER                                              = 44, // <Value> ::= Identifier
        RULE_VALUE_INTEGER                                                 = 45, // <Value> ::= Integer
        RULE_VALUE_STRINGLITERAL                                           = 46, // <Value> ::= StringLiteral
        RULE_VALUE_LPAREN_RPAREN                                           = 47  // <Value> ::= '(' <Expression> ')'
    };

    public class MyParser
    {
        private LALRParser parser;

        public MyParser(string filename)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            Init(stream);
            stream.Close();
        }

        public MyParser(string baseName, string resourceName)
        {
            byte[] buffer = ResourceUtil.GetByteArrayResource(
                System.Reflection.Assembly.GetExecutingAssembly(),
                baseName,
                resourceName);
            MemoryStream stream = new MemoryStream(buffer);
            Init(stream);
            stream.Close();
        }

        public MyParser(Stream stream)
        {
            Init(stream);
        }

        private void Init(Stream stream)
        {
            CGTReader reader = new CGTReader(stream);
            parser = reader.CreateNewParser();
            parser.TrimReductions = false;
            parser.StoreTokens = LALRParser.StoreTokensMode.NoUserObject;

            parser.OnTokenError += new LALRParser.TokenErrorHandler(TokenErrorEvent);
            parser.OnParseError += new LALRParser.ParseErrorHandler(ParseErrorEvent);
        }

        public void Parse(string source)
        {
            NonterminalToken token = parser.Parse(source);
            if (token != null)
            {
                Object obj = CreateObject(token);
                //todo: Use your object any way you like
            }
        }

        private Object CreateObject(Token token)
        {
            if (token is TerminalToken)
                return CreateObjectFromTerminal((TerminalToken)token);
            else
                return CreateObjectFromNonterminal((NonterminalToken)token);
        }

        private Object CreateObjectFromTerminal(TerminalToken token)
        {
            switch (token.Symbol.Id)
            {
                case (int)SymbolConstants.SYMBOL_EOF :
                //(EOF)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ERROR :
                //(Error)
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUS :
                //'-'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MINUSMINUS :
                //'--'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LPAREN :
                //'('
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RPAREN :
                //')'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMES :
                //'*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUS :
                //'+'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PLUSPLUS :
                //'++'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTEQ :
                //'<='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQ :
                //'='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GT :
                //'>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTEQ :
                //'>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOL :
                //bool
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAK :
                //break
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASE :
                //case
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DO :
                //do
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELSE :
                //else
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_END :
                //end
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIER :
                //Identifier
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IF :
                //if
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INT :
                //int
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INTEGER :
                //Integer
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRING :
                //string
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STRINGLITERAL :
                //StringLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCH :
                //switch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDEXP :
                //<AddExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENT :
                //<Assignment>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASELIST :
                //<Caselist>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT2 :
                //<Default>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOWHILELOOP :
                //<DoWhileLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORLOOP :
                //<ForLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<IfStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INCDEC :
                //<IncDec>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INITSTATEMENT :
                //<InitStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTEXP :
                //<MultExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEGATEEXP :
                //<NegateExp>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<StatementList>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSTATEMENT :
                //<SwitchStatement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPE :
                //<Type>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VALUE :
                //<Value>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATION :
                //<VariableDeclaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILELOOP :
                //<WhileLoop>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<StatementList> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2 :
                //<StatementList> ::= <StatementList> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <VariableDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <Assignment>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <IfStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <SwitchStatement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <ForLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<Statement> ::= <WhileLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT7 :
                //<Statement> ::= <DoWhileLoop>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER_EQ :
                //<VariableDeclaration> ::= <Type> Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_INT :
                //<Type> ::= int
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_STRING :
                //<Type> ::= string
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE_BOOL :
                //<Type> ::= bool
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TYPE :
                //<Type> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENT_IDENTIFIER_EQ :
                //<Assignment> ::= Identifier '=' <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE :
                //<IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN_LBRACE_RBRACE_ELSE_LBRACE_RBRACE :
                //<IfStatement> ::= if '(' <Expression> ')' '{' <StatementList> '}' else '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTATEMENT_SWITCH_LBRACE_RBRACE :
                //<SwitchStatement> ::= switch <Expression> '{' <Caselist> <Default> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE_COLON_BREAK :
                //<Caselist> ::= <Caselist> case <Expression> ':' <StatementList> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST_CASE_COLON_BREAK2 :
                //<Caselist> ::= case <Expression> ':' <StatementList> break
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASELIST :
                //<Caselist> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULT_DEFAULT_COLON :
                //<Default> ::= default ':' <StatementList>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORLOOP_FOR_LPAREN_COMMA_COMMA_RPAREN_LBRACE_RBRACE :
                //<ForLoop> ::= for '(' <InitStatement> ',' <Expression> ',' <IncDec> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITSTATEMENT :
                //<InitStatement> ::= <VariableDeclaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_IDENTIFIER_PLUSPLUS :
                //<IncDec> ::= Identifier '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INCDEC_IDENTIFIER_MINUSMINUS :
                //<IncDec> ::= Identifier '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WHILELOOP_WHILE_LPAREN_RPAREN_LBRACE_RBRACE :
                //<WhileLoop> ::= while '(' <Expression> ')' '{' <StatementList> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DOWHILELOOP_DO_LBRACE_RBRACE_WHILE_END :
                //<DoWhileLoop> ::= do '{' <StatementList> '}' while <Expression> end
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GT :
                //<Expression> ::= <Expression> '>' <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_GTEQ :
                //<Expression> ::= <Expression> '>=' <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LT :
                //<Expression> ::= <Expression> '<' <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_LTEQ :
                //<Expression> ::= <Expression> '<=' <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EQEQ :
                //<Expression> ::= <Expression> '==' <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_EXCLAMEQ :
                //<Expression> ::= <Expression> '!=' <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <MultExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_TIMES :
                //<MultExp> ::= <MultExp> '*' <AddExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP_DIV :
                //<MultExp> ::= <MultExp> '/' <AddExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTEXP :
                //<MultExp> ::= <AddExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_PLUS :
                //<AddExp> ::= <AddExp> '+' <NegateExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP_MINUS :
                //<AddExp> ::= <AddExp> '-' <NegateExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDEXP :
                //<AddExp> ::= <NegateExp>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP_MINUS :
                //<NegateExp> ::= '-' <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEGATEEXP :
                //<NegateExp> ::= <Value>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_IDENTIFIER :
                //<Value> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_INTEGER :
                //<Value> ::= Integer
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_STRINGLITERAL :
                //<Value> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VALUE_LPAREN_RPAREN :
                //<Value> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

            }
            throw new RuleException("Unknown rule");
        }

        private void TokenErrorEvent(LALRParser parser, TokenErrorEventArgs args)
        {
            string message = "Token error with input: '"+args.Token.ToString()+"'";
            //todo: Report message to UI?
        }

        private void ParseErrorEvent(LALRParser parser, ParseErrorEventArgs args)
        {
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'";
            //todo: Report message to UI?
        }

    }
}
