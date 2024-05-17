
using System;
using System.IO;
using System.Runtime.Serialization;
using com.calitha.goldparser.lalr;
using com.calitha.commons;
using System.Windows.Forms;

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
        SYMBOL_EOF                      =   0, // (EOF)
        SYMBOL_ERROR                    =   1, // (Error)
        SYMBOL_COMMENT                  =   2, // Comment
        SYMBOL_NEWLINE                  =   3, // NewLine
        SYMBOL_WHITESPACE               =   4, // Whitespace
        SYMBOL_TIMESDIV                 =   5, // '*/'
        SYMBOL_DIVTIMES                 =   6, // '/*'
        SYMBOL_DIVDIV                   =   7, // '//'
        SYMBOL_MINUS                    =   8, // '-'
        SYMBOL_MINUSMINUS               =   9, // '--'
        SYMBOL_EXCLAM                   =  10, // '!'
        SYMBOL_EXCLAMEQ                 =  11, // '!='
        SYMBOL_EXCLAMEQEQ               =  12, // '!=='
        SYMBOL_PERCENT                  =  13, // '%'
        SYMBOL_PERCENTEQ                =  14, // '%='
        SYMBOL_AMP                      =  15, // '&'
        SYMBOL_AMPAMP                   =  16, // '&&'
        SYMBOL_AMPEQ                    =  17, // '&='
        SYMBOL_LPAREN                   =  18, // '('
        SYMBOL_RPAREN                   =  19, // ')'
        SYMBOL_TIMES                    =  20, // '*'
        SYMBOL_TIMESEQ                  =  21, // '*='
        SYMBOL_COMMA                    =  22, // ','
        SYMBOL_DOT                      =  23, // '.'
        SYMBOL_DIV                      =  24, // '/'
        SYMBOL_DIVEQ                    =  25, // '/='
        SYMBOL_COLON                    =  26, // ':'
        SYMBOL_SEMI                     =  27, // ';'
        SYMBOL_QUESTION                 =  28, // '?'
        SYMBOL_LBRACKET                 =  29, // '['
        SYMBOL_RBRACKET                 =  30, // ']'
        SYMBOL_CARET                    =  31, // '^'
        SYMBOL_CARETEQ                  =  32, // '^='
        SYMBOL_LBRACE                   =  33, // '{'
        SYMBOL_PIPE                     =  34, // '|'
        SYMBOL_PIPEPIPE                 =  35, // '||'
        SYMBOL_PIPEEQ                   =  36, // '|='
        SYMBOL_RBRACE                   =  37, // '}'
        SYMBOL_TILDE                    =  38, // '~'
        SYMBOL_PLUS                     =  39, // '+'
        SYMBOL_PLUSPLUS                 =  40, // '++'
        SYMBOL_PLUSEQ                   =  41, // '+='
        SYMBOL_LT                       =  42, // '<'
        SYMBOL_LTLT                     =  43, // '<<'
        SYMBOL_LTLTEQ                   =  44, // '<<='
        SYMBOL_LTEQ                     =  45, // '<='
        SYMBOL_EQ                       =  46, // '='
        SYMBOL_MINUSEQ                  =  47, // '-='
        SYMBOL_EQEQ                     =  48, // '=='
        SYMBOL_EQEQEQ                   =  49, // '==='
        SYMBOL_GT                       =  50, // '>'
        SYMBOL_GTEQ                     =  51, // '>='
        SYMBOL_GTGT                     =  52, // '>>'
        SYMBOL_GTGTEQ                   =  53, // '>>='
        SYMBOL_GTGTGT                   =  54, // '>>>'
        SYMBOL_GTGTGTEQ                 =  55, // '>>>='
        SYMBOL_BREAK                    =  56, // break
        SYMBOL_CASE                     =  57, // case
        SYMBOL_CATCH                    =  58, // catch
        SYMBOL_CONTINUE                 =  59, // continue
        SYMBOL_DECIMALLITERAL           =  60, // DecimalLiteral
        SYMBOL_DEFAULT                  =  61, // default
        SYMBOL_DELETE                   =  62, // delete
        SYMBOL_DO                       =  63, // do
        SYMBOL_ELSE                     =  64, // else
        SYMBOL_FALSE                    =  65, // false
        SYMBOL_FINALLY                  =  66, // finally
        SYMBOL_FOR                      =  67, // for
        SYMBOL_FUNCTION                 =  68, // function
        SYMBOL_HEXINTEGERLITERAL        =  69, // HexIntegerLiteral
        SYMBOL_IDENTIFIER               =  70, // Identifier
        SYMBOL_IF                       =  71, // if
        SYMBOL_IN                       =  72, // in
        SYMBOL_INSTANCEOF               =  73, // instanceof
        SYMBOL_NEW                      =  74, // new
        SYMBOL_NULL                     =  75, // null
        SYMBOL_REGEXP                   =  76, // RegExp
        SYMBOL_RETURN                   =  77, // return
        SYMBOL_STRINGLITERAL            =  78, // StringLiteral
        SYMBOL_SWITCH                   =  79, // switch
        SYMBOL_THIS                     =  80, // this
        SYMBOL_THROW                    =  81, // throw
        SYMBOL_TRUE                     =  82, // true
        SYMBOL_TRY                      =  83, // try
        SYMBOL_TYPEOF                   =  84, // typeof
        SYMBOL_VAR                      =  85, // var
        SYMBOL_VOID                     =  86, // void
        SYMBOL_WHILE                    =  87, // while
        SYMBOL_WITH                     =  88, // with
        SYMBOL_ADDITIVEEXPRESSION       =  89, // <Additive Expression>
        SYMBOL_ARGUMENTLIST             =  90, // <Argument List>
        SYMBOL_ARGUMENTS                =  91, // <Arguments>
        SYMBOL_ARRAYLITERAL             =  92, // <Array Literal>
        SYMBOL_ASSIGNMENTEXPRESSION     =  93, // <Assignment Expression>
        SYMBOL_ASSIGNMENTOPERATOR       =  94, // <Assignment Operator>
        SYMBOL_BITWISEANDEXPRESSION     =  95, // <Bitwise And Expression>
        SYMBOL_BITWISEOREXPRESSION      =  96, // <Bitwise Or Expression>
        SYMBOL_BITWISEXOREXPRESSION     =  97, // <Bitwise XOr Expression>
        SYMBOL_BLOCK                    =  98, // <Block>
        SYMBOL_BOOLEANLITERAL           =  99, // <Boolean Literal>
        SYMBOL_BREAKSTATEMENT           = 100, // <Break Statement>
        SYMBOL_CALLEXPRESSION           = 101, // <Call Expression>
        SYMBOL_CASEBLOCK                = 102, // <Case Block>
        SYMBOL_CASECLAUSE               = 103, // <Case Clause>
        SYMBOL_CASECLAUSES              = 104, // <Case Clauses>
        SYMBOL_CATCH2                   = 105, // <Catch>
        SYMBOL_CONDITIONALEXPRESSION    = 106, // <Conditional Expression>
        SYMBOL_CONTINUESTATEMENT        = 107, // <Continue Statement>
        SYMBOL_DEFAULTCLAUSE            = 108, // <Default Clause>
        SYMBOL_ELEMENTLIST              = 109, // <Element List>
        SYMBOL_ELISION                  = 110, // <Elision>
        SYMBOL_EMPTYSTATEMENT           = 111, // <Empty Statement>
        SYMBOL_EQUALITYEXPRESSION       = 112, // <Equality Expression>
        SYMBOL_EXPRESSION               = 113, // <Expression>
        SYMBOL_FINALLY2                 = 114, // <Finally>
        SYMBOL_FORMALPARAMETERLIST      = 115, // <Formal Parameter List>
        SYMBOL_FUNCTIONBODY             = 116, // <Function Body>
        SYMBOL_FUNCTIONDECLARATION      = 117, // <Function Declaration>
        SYMBOL_FUNCTIONEXPRESSION       = 118, // <Function Expression>
        SYMBOL_IFELSESTATEMENT          = 119, // <If Else Statement>
        SYMBOL_IFSTATEMENT              = 120, // <If Statement>
        SYMBOL_INITIALIZER              = 121, // <Initializer>
        SYMBOL_ITERATIONSTATEMENT       = 122, // <Iteration Statement>
        SYMBOL_LABELLEDSTATEMENT        = 123, // <Labelled Statement>
        SYMBOL_LEFTHANDSIDEEXPRESSION   = 124, // <Left Hand Side Expression>
        SYMBOL_LITERAL                  = 125, // <Literal>
        SYMBOL_LOGICALANDEXPRESSION     = 126, // <Logical And Expression>
        SYMBOL_LOGICALOREXPRESSION      = 127, // <Logical Or Expression>
        SYMBOL_MEMBEREXPRESSION         = 128, // <Member Expression>
        SYMBOL_MULTIPLICATIVEEXPRESSION = 129, // <Multiplicative Expression>
        SYMBOL_NEWEXPRESSION            = 130, // <New Expression>
        SYMBOL_NULLLITERAL              = 131, // <Null Literal>
        SYMBOL_NUMERICLITERAL           = 132, // <Numeric Literal>
        SYMBOL_OBJECTLITERAL            = 133, // <Object Literal>
        SYMBOL_POSTFIXEXPRESSION        = 134, // <Postfix Expression>
        SYMBOL_PRIMARYEXPRESSION        = 135, // <Primary Expression>
        SYMBOL_PROGRAM                  = 136, // <Program>
        SYMBOL_PROPERTYNAME             = 137, // <Property Name>
        SYMBOL_PROPERTYNAMEANDVALUELIST = 138, // <Property Name and Value List>
        SYMBOL_REGULAREXPRESSIONLITERAL = 139, // <Regular Expression Literal>
        SYMBOL_RELATIONALEXPRESSION     = 140, // <Relational Expression>
        SYMBOL_RETURNSTATEMENT          = 141, // <Return Statement>
        SYMBOL_SHIFTEXPRESSION          = 142, // <Shift Expression>
        SYMBOL_SOURCEELEMENT            = 143, // <Source Element>
        SYMBOL_SOURCEELEMENTS           = 144, // <Source Elements>
        SYMBOL_STATEMENT                = 145, // <Statement>
        SYMBOL_STATEMENTLIST            = 146, // <Statement List>
        SYMBOL_SWITCHSTATEMENT          = 147, // <Switch Statement>
        SYMBOL_THROWSTATEMENT           = 148, // <Throw Statement>
        SYMBOL_TRYSTATEMENT             = 149, // <Try Statement>
        SYMBOL_UNARYEXPRESSION          = 150, // <Unary Expression>
        SYMBOL_VARIABLEDECLARATION      = 151, // <Variable Declaration>
        SYMBOL_VARIABLEDECLARATIONLIST  = 152, // <Variable Declaration List>
        SYMBOL_VARIABLESTATEMENT        = 153, // <Variable Statement>
        SYMBOL_WITHSTATEMENT            = 154  // <With Statement>
    };

    enum RuleConstants : int
    {
        RULE_LITERAL                                                              =   0, // <Literal> ::= <Null Literal>
        RULE_LITERAL2                                                             =   1, // <Literal> ::= <Boolean Literal>
        RULE_LITERAL3                                                             =   2, // <Literal> ::= <Numeric Literal>
        RULE_LITERAL_STRINGLITERAL                                                =   3, // <Literal> ::= StringLiteral
        RULE_NULLLITERAL_NULL                                                     =   4, // <Null Literal> ::= null
        RULE_BOOLEANLITERAL_TRUE                                                  =   5, // <Boolean Literal> ::= true
        RULE_BOOLEANLITERAL_FALSE                                                 =   6, // <Boolean Literal> ::= false
        RULE_NUMERICLITERAL_DECIMALLITERAL                                        =   7, // <Numeric Literal> ::= DecimalLiteral
        RULE_NUMERICLITERAL_HEXINTEGERLITERAL                                     =   8, // <Numeric Literal> ::= HexIntegerLiteral
        RULE_REGULAREXPRESSIONLITERAL_REGEXP                                      =   9, // <Regular Expression Literal> ::= RegExp
        RULE_PRIMARYEXPRESSION_THIS                                               =  10, // <Primary Expression> ::= this
        RULE_PRIMARYEXPRESSION_IDENTIFIER                                         =  11, // <Primary Expression> ::= Identifier
        RULE_PRIMARYEXPRESSION                                                    =  12, // <Primary Expression> ::= <Literal>
        RULE_PRIMARYEXPRESSION2                                                   =  13, // <Primary Expression> ::= <Array Literal>
        RULE_PRIMARYEXPRESSION3                                                   =  14, // <Primary Expression> ::= <Object Literal>
        RULE_PRIMARYEXPRESSION_LPAREN_RPAREN                                      =  15, // <Primary Expression> ::= '(' <Expression> ')'
        RULE_PRIMARYEXPRESSION4                                                   =  16, // <Primary Expression> ::= <Regular Expression Literal>
        RULE_ARRAYLITERAL_LBRACKET_RBRACKET                                       =  17, // <Array Literal> ::= '[' ']'
        RULE_ARRAYLITERAL_LBRACKET_RBRACKET2                                      =  18, // <Array Literal> ::= '[' <Elision> ']'
        RULE_ARRAYLITERAL_LBRACKET_RBRACKET3                                      =  19, // <Array Literal> ::= '[' <Element List> ']'
        RULE_ARRAYLITERAL_LBRACKET_COMMA_RBRACKET                                 =  20, // <Array Literal> ::= '[' <Element List> ',' <Elision> ']'
        RULE_ELISION_COMMA                                                        =  21, // <Elision> ::= ','
        RULE_ELISION_COMMA2                                                       =  22, // <Elision> ::= <Elision> ','
        RULE_ELEMENTLIST                                                          =  23, // <Element List> ::= <Elision> <Assignment Expression>
        RULE_ELEMENTLIST_COMMA                                                    =  24, // <Element List> ::= <Element List> ',' <Elision> <Assignment Expression>
        RULE_ELEMENTLIST_COMMA2                                                   =  25, // <Element List> ::= <Element List> ',' <Assignment Expression>
        RULE_ELEMENTLIST2                                                         =  26, // <Element List> ::= <Assignment Expression>
        RULE_OBJECTLITERAL_LBRACE_RBRACE                                          =  27, // <Object Literal> ::= '{' <Property Name and Value List> '}'
        RULE_PROPERTYNAMEANDVALUELIST_COLON                                       =  28, // <Property Name and Value List> ::= <Property Name> ':' <Assignment Expression>
        RULE_PROPERTYNAMEANDVALUELIST_COMMA_COLON                                 =  29, // <Property Name and Value List> ::= <Property Name and Value List> ',' <Property Name> ':' <Assignment Expression>
        RULE_PROPERTYNAME_IDENTIFIER                                              =  30, // <Property Name> ::= Identifier
        RULE_PROPERTYNAME_STRINGLITERAL                                           =  31, // <Property Name> ::= StringLiteral
        RULE_PROPERTYNAME                                                         =  32, // <Property Name> ::= <Numeric Literal>
        RULE_MEMBEREXPRESSION                                                     =  33, // <Member Expression> ::= <Primary Expression>
        RULE_MEMBEREXPRESSION2                                                    =  34, // <Member Expression> ::= <Function Expression>
        RULE_MEMBEREXPRESSION_LBRACKET_RBRACKET                                   =  35, // <Member Expression> ::= <Member Expression> '[' <Expression> ']'
        RULE_MEMBEREXPRESSION_DOT_IDENTIFIER                                      =  36, // <Member Expression> ::= <Member Expression> '.' Identifier
        RULE_MEMBEREXPRESSION_NEW                                                 =  37, // <Member Expression> ::= new <Member Expression> <Arguments>
        RULE_NEWEXPRESSION                                                        =  38, // <New Expression> ::= <Member Expression>
        RULE_NEWEXPRESSION_NEW                                                    =  39, // <New Expression> ::= new <New Expression>
        RULE_CALLEXPRESSION                                                       =  40, // <Call Expression> ::= <Member Expression> <Arguments>
        RULE_CALLEXPRESSION2                                                      =  41, // <Call Expression> ::= <Call Expression> <Arguments>
        RULE_CALLEXPRESSION_LBRACKET_RBRACKET                                     =  42, // <Call Expression> ::= <Call Expression> '[' <Expression> ']'
        RULE_CALLEXPRESSION_DOT_IDENTIFIER                                        =  43, // <Call Expression> ::= <Call Expression> '.' Identifier
        RULE_ARGUMENTS_LPAREN_RPAREN                                              =  44, // <Arguments> ::= '(' ')'
        RULE_ARGUMENTS_LPAREN_RPAREN2                                             =  45, // <Arguments> ::= '(' <Argument List> ')'
        RULE_ARGUMENTLIST                                                         =  46, // <Argument List> ::= <Assignment Expression>
        RULE_ARGUMENTLIST_COMMA                                                   =  47, // <Argument List> ::= <Argument List> ',' <Assignment Expression>
        RULE_LEFTHANDSIDEEXPRESSION                                               =  48, // <Left Hand Side Expression> ::= <New Expression>
        RULE_LEFTHANDSIDEEXPRESSION2                                              =  49, // <Left Hand Side Expression> ::= <Call Expression>
        RULE_POSTFIXEXPRESSION                                                    =  50, // <Postfix Expression> ::= <Left Hand Side Expression>
        RULE_POSTFIXEXPRESSION_PLUSPLUS                                           =  51, // <Postfix Expression> ::= <Postfix Expression> '++'
        RULE_POSTFIXEXPRESSION_MINUSMINUS                                         =  52, // <Postfix Expression> ::= <Postfix Expression> '--'
        RULE_UNARYEXPRESSION                                                      =  53, // <Unary Expression> ::= <Postfix Expression>
        RULE_UNARYEXPRESSION_DELETE                                               =  54, // <Unary Expression> ::= delete <Unary Expression>
        RULE_UNARYEXPRESSION_VOID                                                 =  55, // <Unary Expression> ::= void <Unary Expression>
        RULE_UNARYEXPRESSION_TYPEOF                                               =  56, // <Unary Expression> ::= typeof <Unary Expression>
        RULE_UNARYEXPRESSION_PLUSPLUS                                             =  57, // <Unary Expression> ::= '++' <Unary Expression>
        RULE_UNARYEXPRESSION_MINUSMINUS                                           =  58, // <Unary Expression> ::= '--' <Unary Expression>
        RULE_UNARYEXPRESSION_PLUS                                                 =  59, // <Unary Expression> ::= '+' <Unary Expression>
        RULE_UNARYEXPRESSION_MINUS                                                =  60, // <Unary Expression> ::= '-' <Unary Expression>
        RULE_UNARYEXPRESSION_TILDE                                                =  61, // <Unary Expression> ::= '~' <Unary Expression>
        RULE_UNARYEXPRESSION_EXCLAM                                               =  62, // <Unary Expression> ::= '!' <Unary Expression>
        RULE_MULTIPLICATIVEEXPRESSION                                             =  63, // <Multiplicative Expression> ::= <Unary Expression>
        RULE_MULTIPLICATIVEEXPRESSION_TIMES                                       =  64, // <Multiplicative Expression> ::= <Unary Expression> '*' <Multiplicative Expression>
        RULE_MULTIPLICATIVEEXPRESSION_DIV                                         =  65, // <Multiplicative Expression> ::= <Unary Expression> '/' <Multiplicative Expression>
        RULE_MULTIPLICATIVEEXPRESSION_PERCENT                                     =  66, // <Multiplicative Expression> ::= <Unary Expression> '%' <Multiplicative Expression>
        RULE_ADDITIVEEXPRESSION_PLUS                                              =  67, // <Additive Expression> ::= <Additive Expression> '+' <Multiplicative Expression>
        RULE_ADDITIVEEXPRESSION_MINUS                                             =  68, // <Additive Expression> ::= <Additive Expression> '-' <Multiplicative Expression>
        RULE_ADDITIVEEXPRESSION                                                   =  69, // <Additive Expression> ::= <Multiplicative Expression>
        RULE_SHIFTEXPRESSION_LTLT                                                 =  70, // <Shift Expression> ::= <Shift Expression> '<<' <Additive Expression>
        RULE_SHIFTEXPRESSION_GTGT                                                 =  71, // <Shift Expression> ::= <Shift Expression> '>>' <Additive Expression>
        RULE_SHIFTEXPRESSION_GTGTGT                                               =  72, // <Shift Expression> ::= <Shift Expression> '>>>' <Additive Expression>
        RULE_SHIFTEXPRESSION                                                      =  73, // <Shift Expression> ::= <Additive Expression>
        RULE_RELATIONALEXPRESSION                                                 =  74, // <Relational Expression> ::= <Shift Expression>
        RULE_RELATIONALEXPRESSION_LT                                              =  75, // <Relational Expression> ::= <Relational Expression> '<' <Shift Expression>
        RULE_RELATIONALEXPRESSION_GT                                              =  76, // <Relational Expression> ::= <Relational Expression> '>' <Shift Expression>
        RULE_RELATIONALEXPRESSION_LTEQ                                            =  77, // <Relational Expression> ::= <Relational Expression> '<=' <Shift Expression>
        RULE_RELATIONALEXPRESSION_GTEQ                                            =  78, // <Relational Expression> ::= <Relational Expression> '>=' <Shift Expression>
        RULE_RELATIONALEXPRESSION_INSTANCEOF                                      =  79, // <Relational Expression> ::= <Relational Expression> instanceof <Shift Expression>
        RULE_EQUALITYEXPRESSION                                                   =  80, // <Equality Expression> ::= <Relational Expression>
        RULE_EQUALITYEXPRESSION_EQEQ                                              =  81, // <Equality Expression> ::= <Equality Expression> '==' <Relational Expression>
        RULE_EQUALITYEXPRESSION_EXCLAMEQ                                          =  82, // <Equality Expression> ::= <Equality Expression> '!=' <Relational Expression>
        RULE_EQUALITYEXPRESSION_EQEQEQ                                            =  83, // <Equality Expression> ::= <Equality Expression> '===' <Relational Expression>
        RULE_EQUALITYEXPRESSION_EXCLAMEQEQ                                        =  84, // <Equality Expression> ::= <Equality Expression> '!==' <Relational Expression>
        RULE_BITWISEANDEXPRESSION                                                 =  85, // <Bitwise And Expression> ::= <Equality Expression>
        RULE_BITWISEANDEXPRESSION_AMP                                             =  86, // <Bitwise And Expression> ::= <Bitwise And Expression> '&' <Equality Expression>
        RULE_BITWISEXOREXPRESSION                                                 =  87, // <Bitwise XOr Expression> ::= <Bitwise And Expression>
        RULE_BITWISEXOREXPRESSION_CARET                                           =  88, // <Bitwise XOr Expression> ::= <Bitwise XOr Expression> '^' <Bitwise And Expression>
        RULE_BITWISEOREXPRESSION                                                  =  89, // <Bitwise Or Expression> ::= <Bitwise XOr Expression>
        RULE_BITWISEOREXPRESSION_PIPE                                             =  90, // <Bitwise Or Expression> ::= <Bitwise Or Expression> '|' <Bitwise XOr Expression>
        RULE_LOGICALANDEXPRESSION                                                 =  91, // <Logical And Expression> ::= <Bitwise Or Expression>
        RULE_LOGICALANDEXPRESSION_AMPAMP                                          =  92, // <Logical And Expression> ::= <Logical And Expression> '&&' <Bitwise Or Expression>
        RULE_LOGICALOREXPRESSION                                                  =  93, // <Logical Or Expression> ::= <Logical And Expression>
        RULE_LOGICALOREXPRESSION_PIPEPIPE                                         =  94, // <Logical Or Expression> ::= <Logical Or Expression> '||' <Logical And Expression>
        RULE_CONDITIONALEXPRESSION                                                =  95, // <Conditional Expression> ::= <Logical Or Expression>
        RULE_CONDITIONALEXPRESSION_QUESTION_COLON                                 =  96, // <Conditional Expression> ::= <Logical Or Expression> '?' <Assignment Expression> ':' <Assignment Expression>
        RULE_ASSIGNMENTEXPRESSION                                                 =  97, // <Assignment Expression> ::= <Conditional Expression>
        RULE_ASSIGNMENTEXPRESSION2                                                =  98, // <Assignment Expression> ::= <Left Hand Side Expression> <Assignment Operator> <Assignment Expression>
        RULE_ASSIGNMENTOPERATOR_EQ                                                =  99, // <Assignment Operator> ::= '='
        RULE_ASSIGNMENTOPERATOR_TIMESEQ                                           = 100, // <Assignment Operator> ::= '*='
        RULE_ASSIGNMENTOPERATOR_DIVEQ                                             = 101, // <Assignment Operator> ::= '/='
        RULE_ASSIGNMENTOPERATOR_PERCENTEQ                                         = 102, // <Assignment Operator> ::= '%='
        RULE_ASSIGNMENTOPERATOR_PLUSEQ                                            = 103, // <Assignment Operator> ::= '+='
        RULE_ASSIGNMENTOPERATOR_MINUSEQ                                           = 104, // <Assignment Operator> ::= '-='
        RULE_ASSIGNMENTOPERATOR_LTLTEQ                                            = 105, // <Assignment Operator> ::= '<<='
        RULE_ASSIGNMENTOPERATOR_GTGTEQ                                            = 106, // <Assignment Operator> ::= '>>='
        RULE_ASSIGNMENTOPERATOR_GTGTGTEQ                                          = 107, // <Assignment Operator> ::= '>>>='
        RULE_ASSIGNMENTOPERATOR_AMPEQ                                             = 108, // <Assignment Operator> ::= '&='
        RULE_ASSIGNMENTOPERATOR_CARETEQ                                           = 109, // <Assignment Operator> ::= '^='
        RULE_ASSIGNMENTOPERATOR_PIPEEQ                                            = 110, // <Assignment Operator> ::= '|='
        RULE_EXPRESSION                                                           = 111, // <Expression> ::= <Assignment Expression>
        RULE_EXPRESSION_COMMA                                                     = 112, // <Expression> ::= <Expression> ',' <Assignment Expression>
        RULE_BLOCK_LBRACE_RBRACE                                                  = 113, // <Block> ::= '{' '}'
        RULE_BLOCK_LBRACE_RBRACE2                                                 = 114, // <Block> ::= '{' <Statement List> '}'
        RULE_STATEMENT                                                            = 115, // <Statement> ::= <Block>
        RULE_STATEMENT2                                                           = 116, // <Statement> ::= <Variable Statement>
        RULE_STATEMENT3                                                           = 117, // <Statement> ::= <Empty Statement>
        RULE_STATEMENT4                                                           = 118, // <Statement> ::= <If Statement>
        RULE_STATEMENT5                                                           = 119, // <Statement> ::= <If Else Statement>
        RULE_STATEMENT6                                                           = 120, // <Statement> ::= <Iteration Statement>
        RULE_STATEMENT7                                                           = 121, // <Statement> ::= <Continue Statement>
        RULE_STATEMENT8                                                           = 122, // <Statement> ::= <Break Statement>
        RULE_STATEMENT9                                                           = 123, // <Statement> ::= <Return Statement>
        RULE_STATEMENT10                                                          = 124, // <Statement> ::= <With Statement>
        RULE_STATEMENT11                                                          = 125, // <Statement> ::= <Labelled Statement>
        RULE_STATEMENT12                                                          = 126, // <Statement> ::= <Switch Statement>
        RULE_STATEMENT13                                                          = 127, // <Statement> ::= <Throw Statement>
        RULE_STATEMENT14                                                          = 128, // <Statement> ::= <Try Statement>
        RULE_STATEMENT15                                                          = 129, // <Statement> ::= <Expression>
        RULE_STATEMENTLIST                                                        = 130, // <Statement List> ::= <Statement>
        RULE_STATEMENTLIST2                                                       = 131, // <Statement List> ::= <Statement List> <Statement>
        RULE_VARIABLESTATEMENT_VAR_SEMI                                           = 132, // <Variable Statement> ::= var <Variable Declaration List> ';'
        RULE_VARIABLEDECLARATIONLIST                                              = 133, // <Variable Declaration List> ::= <Variable Declaration>
        RULE_VARIABLEDECLARATIONLIST_COMMA                                        = 134, // <Variable Declaration List> ::= <Variable Declaration List> ',' <Variable Declaration>
        RULE_VARIABLEDECLARATION_IDENTIFIER                                       = 135, // <Variable Declaration> ::= Identifier
        RULE_VARIABLEDECLARATION_IDENTIFIER2                                      = 136, // <Variable Declaration> ::= Identifier <Initializer>
        RULE_INITIALIZER_EQ                                                       = 137, // <Initializer> ::= '=' <Assignment Expression>
        RULE_EMPTYSTATEMENT_SEMI                                                  = 138, // <Empty Statement> ::= ';'
        RULE_IFSTATEMENT_IF_LPAREN_RPAREN                                         = 139, // <If Statement> ::= if '(' <Expression> ')' <Statement>
        RULE_IFELSESTATEMENT_IF_LPAREN_RPAREN_ELSE                                = 140, // <If Else Statement> ::= if '(' <Expression> ')' <Statement> else <Statement>
        RULE_ITERATIONSTATEMENT_DO_WHILE_LPAREN_RPAREN_SEMI                       = 141, // <Iteration Statement> ::= do <Statement> while '(' <Expression> ')' ';'
        RULE_ITERATIONSTATEMENT_WHILE_LPAREN_RPAREN                               = 142, // <Iteration Statement> ::= while '(' <Expression> ')' <Statement>
        RULE_ITERATIONSTATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN                       = 143, // <Iteration Statement> ::= for '(' <Expression> ';' <Expression> ';' <Expression> ')' <Statement>
        RULE_ITERATIONSTATEMENT_FOR_LPAREN_VAR_SEMI_SEMI_RPAREN                   = 144, // <Iteration Statement> ::= for '(' var <Variable Declaration List> ';' <Expression> ';' <Expression> ')' <Statement>
        RULE_ITERATIONSTATEMENT_FOR_LPAREN_IN_RPAREN                              = 145, // <Iteration Statement> ::= for '(' <Left Hand Side Expression> in <Expression> ')' <Statement>
        RULE_ITERATIONSTATEMENT_FOR_LPAREN_VAR_IN_RPAREN                          = 146, // <Iteration Statement> ::= for '(' var <Variable Declaration> in <Expression> ')' <Statement>
        RULE_CONTINUESTATEMENT_CONTINUE_SEMI                                      = 147, // <Continue Statement> ::= continue ';'
        RULE_CONTINUESTATEMENT_CONTINUE_IDENTIFIER_SEMI                           = 148, // <Continue Statement> ::= continue Identifier ';'
        RULE_BREAKSTATEMENT_BREAK_SEMI                                            = 149, // <Break Statement> ::= break ';'
        RULE_BREAKSTATEMENT_BREAK_IDENTIFIER_SEMI                                 = 150, // <Break Statement> ::= break Identifier ';'
        RULE_RETURNSTATEMENT_RETURN_SEMI                                          = 151, // <Return Statement> ::= return ';'
        RULE_RETURNSTATEMENT_RETURN_SEMI2                                         = 152, // <Return Statement> ::= return <Expression> ';'
        RULE_WITHSTATEMENT_WITH_LPAREN_RPAREN_SEMI                                = 153, // <With Statement> ::= with '(' <Expression> ')' <Statement> ';'
        RULE_SWITCHSTATEMENT_SWITCH_LPAREN_RPAREN                                 = 154, // <Switch Statement> ::= switch '(' <Expression> ')' <Case Block>
        RULE_CASEBLOCK_LBRACE_RBRACE                                              = 155, // <Case Block> ::= '{' '}'
        RULE_CASEBLOCK_LBRACE_RBRACE2                                             = 156, // <Case Block> ::= '{' <Case Clauses> '}'
        RULE_CASEBLOCK_LBRACE_RBRACE3                                             = 157, // <Case Block> ::= '{' <Case Clauses> <Default Clause> '}'
        RULE_CASEBLOCK_LBRACE_RBRACE4                                             = 158, // <Case Block> ::= '{' <Case Clauses> <Default Clause> <Case Clauses> '}'
        RULE_CASEBLOCK_LBRACE_RBRACE5                                             = 159, // <Case Block> ::= '{' <Default Clause> <Case Clauses> '}'
        RULE_CASEBLOCK_LBRACE_RBRACE6                                             = 160, // <Case Block> ::= '{' <Default Clause> '}'
        RULE_CASECLAUSES                                                          = 161, // <Case Clauses> ::= <Case Clause>
        RULE_CASECLAUSES2                                                         = 162, // <Case Clauses> ::= <Case Clauses> <Case Clause>
        RULE_CASECLAUSE_CASE_COLON                                                = 163, // <Case Clause> ::= case <Expression> ':' <Statement List>
        RULE_CASECLAUSE_CASE_COLON2                                               = 164, // <Case Clause> ::= case <Expression> ':'
        RULE_DEFAULTCLAUSE_DEFAULT_COLON                                          = 165, // <Default Clause> ::= default ':'
        RULE_DEFAULTCLAUSE_DEFAULT_COLON2                                         = 166, // <Default Clause> ::= default ':' <Statement List>
        RULE_LABELLEDSTATEMENT_IDENTIFIER_COLON                                   = 167, // <Labelled Statement> ::= Identifier ':' <Statement>
        RULE_THROWSTATEMENT_THROW                                                 = 168, // <Throw Statement> ::= throw <Expression>
        RULE_TRYSTATEMENT_TRY                                                     = 169, // <Try Statement> ::= try <Block> <Catch>
        RULE_TRYSTATEMENT_TRY2                                                    = 170, // <Try Statement> ::= try <Block> <Finally>
        RULE_TRYSTATEMENT_TRY3                                                    = 171, // <Try Statement> ::= try <Block> <Catch> <Finally>
        RULE_CATCH_CATCH_LPAREN_IDENTIFIER_RPAREN                                 = 172, // <Catch> ::= catch '(' Identifier ')' <Block>
        RULE_FINALLY_FINALLY                                                      = 173, // <Finally> ::= finally <Block>
        RULE_FUNCTIONDECLARATION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_LBRACE_RBRACE  = 174, // <Function Declaration> ::= function Identifier '(' <Formal Parameter List> ')' '{' <Function Body> '}'
        RULE_FUNCTIONDECLARATION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_LBRACE_RBRACE2 = 175, // <Function Declaration> ::= function Identifier '(' ')' '{' <Function Body> '}'
        RULE_FUNCTIONEXPRESSION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE              = 176, // <Function Expression> ::= function '(' ')' '{' <Function Body> '}'
        RULE_FUNCTIONEXPRESSION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE2             = 177, // <Function Expression> ::= function '(' <Formal Parameter List> ')' '{' <Function Body> '}'
        RULE_FORMALPARAMETERLIST_IDENTIFIER                                       = 178, // <Formal Parameter List> ::= Identifier
        RULE_FORMALPARAMETERLIST_COMMA_IDENTIFIER                                 = 179, // <Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
        RULE_FUNCTIONBODY                                                         = 180, // <Function Body> ::= <Source Elements>
        RULE_FUNCTIONBODY2                                                        = 181, // <Function Body> ::= 
        RULE_PROGRAM                                                              = 182, // <Program> ::= <Source Elements>
        RULE_SOURCEELEMENTS                                                       = 183, // <Source Elements> ::= <Source Element>
        RULE_SOURCEELEMENTS2                                                      = 184, // <Source Elements> ::= <Source Elements> <Source Element>
        RULE_SOURCEELEMENT                                                        = 185, // <Source Element> ::= <Statement>
        RULE_SOURCEELEMENT2                                                       = 186  // <Source Element> ::= <Function Declaration>
    };

    public class MyParser
    {
        private LALRParser parser;
        ListBox lst;
        ListBox ls;
        public MyParser(string filename, ListBox lst, ListBox ls)
        {
            FileStream stream = new FileStream(filename,
                                               FileMode.Open, 
                                               FileAccess.Read, 
                                               FileShare.Read);
            this.lst = lst;
            this.ls = ls;
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
            parser.OnTokenRead += new LALRParser.TokenReadHandler(TokenReadEvent);
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

                case (int)SymbolConstants.SYMBOL_COMMENT :
                //Comment
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWLINE :
                //NewLine
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE :
                //Whitespace
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TIMESDIV :
                //'*/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVTIMES :
                //'/*'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVDIV :
                //'//'
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

                case (int)SymbolConstants.SYMBOL_EXCLAM :
                //'!'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQ :
                //'!='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXCLAMEQEQ :
                //'!=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENT :
                //'%'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PERCENTEQ :
                //'%='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMP :
                //'&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPAMP :
                //'&&'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_AMPEQ :
                //'&='
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

                case (int)SymbolConstants.SYMBOL_TIMESEQ :
                //'*='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COMMA :
                //','
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DOT :
                //'.'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIV :
                //'/'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DIVEQ :
                //'/='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_COLON :
                //':'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SEMI :
                //';'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_QUESTION :
                //'?'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACKET :
                //'['
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACKET :
                //']'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARET :
                //'^'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CARETEQ :
                //'^='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LBRACE :
                //'{'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPE :
                //'|'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEPIPE :
                //'||'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PIPEEQ :
                //'|='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RBRACE :
                //'}'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TILDE :
                //'~'
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

                case (int)SymbolConstants.SYMBOL_PLUSEQ :
                //'+='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LT :
                //'<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLT :
                //'<<'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LTLTEQ :
                //'<<='
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

                case (int)SymbolConstants.SYMBOL_MINUSEQ :
                //'-='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQ :
                //'=='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQEQEQ :
                //'==='
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

                case (int)SymbolConstants.SYMBOL_GTGT :
                //'>>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGTEQ :
                //'>>='
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGTGT :
                //'>>>'
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_GTGTGTEQ :
                //'>>>='
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

                case (int)SymbolConstants.SYMBOL_CATCH :
                //catch
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUE :
                //continue
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DECIMALLITERAL :
                //DecimalLiteral
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULT :
                //default
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DELETE :
                //delete
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

                case (int)SymbolConstants.SYMBOL_FALSE :
                //false
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLY :
                //finally
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FOR :
                //for
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTION :
                //function
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_HEXINTEGERLITERAL :
                //HexIntegerLiteral
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

                case (int)SymbolConstants.SYMBOL_IN :
                //in
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INSTANCEOF :
                //instanceof
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEW :
                //new
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NULL :
                //null
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REGEXP :
                //RegExp
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURN :
                //return
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

                case (int)SymbolConstants.SYMBOL_THIS :
                //this
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THROW :
                //throw
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRUE :
                //true
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRY :
                //try
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TYPEOF :
                //typeof
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VAR :
                //var
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VOID :
                //void
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WHILE :
                //while
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WITH :
                //with
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ADDITIVEEXPRESSION :
                //<Additive Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTLIST :
                //<Argument List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARGUMENTS :
                //<Arguments>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ARRAYLITERAL :
                //<Array Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENTEXPRESSION :
                //<Assignment Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ASSIGNMENTOPERATOR :
                //<Assignment Operator>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BITWISEANDEXPRESSION :
                //<Bitwise And Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BITWISEOREXPRESSION :
                //<Bitwise Or Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BITWISEXOREXPRESSION :
                //<Bitwise XOr Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BLOCK :
                //<Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BOOLEANLITERAL :
                //<Boolean Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_BREAKSTATEMENT :
                //<Break Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CALLEXPRESSION :
                //<Call Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASEBLOCK :
                //<Case Block>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASECLAUSE :
                //<Case Clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CASECLAUSES :
                //<Case Clauses>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CATCH2 :
                //<Catch>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONDITIONALEXPRESSION :
                //<Conditional Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_CONTINUESTATEMENT :
                //<Continue Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_DEFAULTCLAUSE :
                //<Default Clause>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELEMENTLIST :
                //<Element List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ELISION :
                //<Elision>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EMPTYSTATEMENT :
                //<Empty Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EQUALITYEXPRESSION :
                //<Equality Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION :
                //<Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FINALLY2 :
                //<Finally>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FORMALPARAMETERLIST :
                //<Formal Parameter List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONBODY :
                //<Function Body>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONDECLARATION :
                //<Function Declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_FUNCTIONEXPRESSION :
                //<Function Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFELSESTATEMENT :
                //<If Else Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_IFSTATEMENT :
                //<If Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_INITIALIZER :
                //<Initializer>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_ITERATIONSTATEMENT :
                //<Iteration Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LABELLEDSTATEMENT :
                //<Labelled Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LEFTHANDSIDEEXPRESSION :
                //<Left Hand Side Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LITERAL :
                //<Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALANDEXPRESSION :
                //<Logical And Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_LOGICALOREXPRESSION :
                //<Logical Or Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MEMBEREXPRESSION :
                //<Member Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_MULTIPLICATIVEEXPRESSION :
                //<Multiplicative Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NEWEXPRESSION :
                //<New Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NULLLITERAL :
                //<Null Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_NUMERICLITERAL :
                //<Numeric Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_OBJECTLITERAL :
                //<Object Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_POSTFIXEXPRESSION :
                //<Postfix Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PRIMARYEXPRESSION :
                //<Primary Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROGRAM :
                //<Program>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROPERTYNAME :
                //<Property Name>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_PROPERTYNAMEANDVALUELIST :
                //<Property Name and Value List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_REGULAREXPRESSIONLITERAL :
                //<Regular Expression Literal>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RELATIONALEXPRESSION :
                //<Relational Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTATEMENT :
                //<Return Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SHIFTEXPRESSION :
                //<Shift Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SOURCEELEMENT :
                //<Source Element>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SOURCEELEMENTS :
                //<Source Elements>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT :
                //<Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_STATEMENTLIST :
                //<Statement List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_SWITCHSTATEMENT :
                //<Switch Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_THROWSTATEMENT :
                //<Throw Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_TRYSTATEMENT :
                //<Try Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_UNARYEXPRESSION :
                //<Unary Expression>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATION :
                //<Variable Declaration>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLEDECLARATIONLIST :
                //<Variable Declaration List>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_VARIABLESTATEMENT :
                //<Variable Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

                case (int)SymbolConstants.SYMBOL_WITHSTATEMENT :
                //<With Statement>
                //todo: Create a new object that corresponds to the symbol
                return null;

            }
            throw new SymbolException("Unknown symbol");
        }

        public Object CreateObjectFromNonterminal(NonterminalToken token)
        {
            switch (token.Rule.Id)
            {
                case (int)RuleConstants.RULE_LITERAL :
                //<Literal> ::= <Null Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL2 :
                //<Literal> ::= <Boolean Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL3 :
                //<Literal> ::= <Numeric Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LITERAL_STRINGLITERAL :
                //<Literal> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NULLLITERAL_NULL :
                //<Null Literal> ::= null
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEANLITERAL_TRUE :
                //<Boolean Literal> ::= true
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BOOLEANLITERAL_FALSE :
                //<Boolean Literal> ::= false
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUMERICLITERAL_DECIMALLITERAL :
                //<Numeric Literal> ::= DecimalLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NUMERICLITERAL_HEXINTEGERLITERAL :
                //<Numeric Literal> ::= HexIntegerLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_REGULAREXPRESSIONLITERAL_REGEXP :
                //<Regular Expression Literal> ::= RegExp
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_THIS :
                //<Primary Expression> ::= this
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_IDENTIFIER :
                //<Primary Expression> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION :
                //<Primary Expression> ::= <Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION2 :
                //<Primary Expression> ::= <Array Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION3 :
                //<Primary Expression> ::= <Object Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION_LPAREN_RPAREN :
                //<Primary Expression> ::= '(' <Expression> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PRIMARYEXPRESSION4 :
                //<Primary Expression> ::= <Regular Expression Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYLITERAL_LBRACKET_RBRACKET :
                //<Array Literal> ::= '[' ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYLITERAL_LBRACKET_RBRACKET2 :
                //<Array Literal> ::= '[' <Elision> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYLITERAL_LBRACKET_RBRACKET3 :
                //<Array Literal> ::= '[' <Element List> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARRAYLITERAL_LBRACKET_COMMA_RBRACKET :
                //<Array Literal> ::= '[' <Element List> ',' <Elision> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELISION_COMMA :
                //<Elision> ::= ','
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELISION_COMMA2 :
                //<Elision> ::= <Elision> ','
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTLIST :
                //<Element List> ::= <Elision> <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTLIST_COMMA :
                //<Element List> ::= <Element List> ',' <Elision> <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTLIST_COMMA2 :
                //<Element List> ::= <Element List> ',' <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ELEMENTLIST2 :
                //<Element List> ::= <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_OBJECTLITERAL_LBRACE_RBRACE :
                //<Object Literal> ::= '{' <Property Name and Value List> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROPERTYNAMEANDVALUELIST_COLON :
                //<Property Name and Value List> ::= <Property Name> ':' <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROPERTYNAMEANDVALUELIST_COMMA_COLON :
                //<Property Name and Value List> ::= <Property Name and Value List> ',' <Property Name> ':' <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROPERTYNAME_IDENTIFIER :
                //<Property Name> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROPERTYNAME_STRINGLITERAL :
                //<Property Name> ::= StringLiteral
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROPERTYNAME :
                //<Property Name> ::= <Numeric Literal>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MEMBEREXPRESSION :
                //<Member Expression> ::= <Primary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MEMBEREXPRESSION2 :
                //<Member Expression> ::= <Function Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MEMBEREXPRESSION_LBRACKET_RBRACKET :
                //<Member Expression> ::= <Member Expression> '[' <Expression> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MEMBEREXPRESSION_DOT_IDENTIFIER :
                //<Member Expression> ::= <Member Expression> '.' Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MEMBEREXPRESSION_NEW :
                //<Member Expression> ::= new <Member Expression> <Arguments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEWEXPRESSION :
                //<New Expression> ::= <Member Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_NEWEXPRESSION_NEW :
                //<New Expression> ::= new <New Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CALLEXPRESSION :
                //<Call Expression> ::= <Member Expression> <Arguments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CALLEXPRESSION2 :
                //<Call Expression> ::= <Call Expression> <Arguments>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CALLEXPRESSION_LBRACKET_RBRACKET :
                //<Call Expression> ::= <Call Expression> '[' <Expression> ']'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CALLEXPRESSION_DOT_IDENTIFIER :
                //<Call Expression> ::= <Call Expression> '.' Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS_LPAREN_RPAREN :
                //<Arguments> ::= '(' ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTS_LPAREN_RPAREN2 :
                //<Arguments> ::= '(' <Argument List> ')'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST :
                //<Argument List> ::= <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ARGUMENTLIST_COMMA :
                //<Argument List> ::= <Argument List> ',' <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LEFTHANDSIDEEXPRESSION :
                //<Left Hand Side Expression> ::= <New Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LEFTHANDSIDEEXPRESSION2 :
                //<Left Hand Side Expression> ::= <Call Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POSTFIXEXPRESSION :
                //<Postfix Expression> ::= <Left Hand Side Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POSTFIXEXPRESSION_PLUSPLUS :
                //<Postfix Expression> ::= <Postfix Expression> '++'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_POSTFIXEXPRESSION_MINUSMINUS :
                //<Postfix Expression> ::= <Postfix Expression> '--'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION :
                //<Unary Expression> ::= <Postfix Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_DELETE :
                //<Unary Expression> ::= delete <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_VOID :
                //<Unary Expression> ::= void <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_TYPEOF :
                //<Unary Expression> ::= typeof <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_PLUSPLUS :
                //<Unary Expression> ::= '++' <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_MINUSMINUS :
                //<Unary Expression> ::= '--' <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_PLUS :
                //<Unary Expression> ::= '+' <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_MINUS :
                //<Unary Expression> ::= '-' <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_TILDE :
                //<Unary Expression> ::= '~' <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_UNARYEXPRESSION_EXCLAM :
                //<Unary Expression> ::= '!' <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTIPLICATIVEEXPRESSION :
                //<Multiplicative Expression> ::= <Unary Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTIPLICATIVEEXPRESSION_TIMES :
                //<Multiplicative Expression> ::= <Unary Expression> '*' <Multiplicative Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTIPLICATIVEEXPRESSION_DIV :
                //<Multiplicative Expression> ::= <Unary Expression> '/' <Multiplicative Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_MULTIPLICATIVEEXPRESSION_PERCENT :
                //<Multiplicative Expression> ::= <Unary Expression> '%' <Multiplicative Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDITIVEEXPRESSION_PLUS :
                //<Additive Expression> ::= <Additive Expression> '+' <Multiplicative Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDITIVEEXPRESSION_MINUS :
                //<Additive Expression> ::= <Additive Expression> '-' <Multiplicative Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ADDITIVEEXPRESSION :
                //<Additive Expression> ::= <Multiplicative Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXPRESSION_LTLT :
                //<Shift Expression> ::= <Shift Expression> '<<' <Additive Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXPRESSION_GTGT :
                //<Shift Expression> ::= <Shift Expression> '>>' <Additive Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXPRESSION_GTGTGT :
                //<Shift Expression> ::= <Shift Expression> '>>>' <Additive Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SHIFTEXPRESSION :
                //<Shift Expression> ::= <Additive Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPRESSION :
                //<Relational Expression> ::= <Shift Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPRESSION_LT :
                //<Relational Expression> ::= <Relational Expression> '<' <Shift Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPRESSION_GT :
                //<Relational Expression> ::= <Relational Expression> '>' <Shift Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPRESSION_LTEQ :
                //<Relational Expression> ::= <Relational Expression> '<=' <Shift Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPRESSION_GTEQ :
                //<Relational Expression> ::= <Relational Expression> '>=' <Shift Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RELATIONALEXPRESSION_INSTANCEOF :
                //<Relational Expression> ::= <Relational Expression> instanceof <Shift Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXPRESSION :
                //<Equality Expression> ::= <Relational Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXPRESSION_EQEQ :
                //<Equality Expression> ::= <Equality Expression> '==' <Relational Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXPRESSION_EXCLAMEQ :
                //<Equality Expression> ::= <Equality Expression> '!=' <Relational Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXPRESSION_EQEQEQ :
                //<Equality Expression> ::= <Equality Expression> '===' <Relational Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EQUALITYEXPRESSION_EXCLAMEQEQ :
                //<Equality Expression> ::= <Equality Expression> '!==' <Relational Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BITWISEANDEXPRESSION :
                //<Bitwise And Expression> ::= <Equality Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BITWISEANDEXPRESSION_AMP :
                //<Bitwise And Expression> ::= <Bitwise And Expression> '&' <Equality Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BITWISEXOREXPRESSION :
                //<Bitwise XOr Expression> ::= <Bitwise And Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BITWISEXOREXPRESSION_CARET :
                //<Bitwise XOr Expression> ::= <Bitwise XOr Expression> '^' <Bitwise And Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BITWISEOREXPRESSION :
                //<Bitwise Or Expression> ::= <Bitwise XOr Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BITWISEOREXPRESSION_PIPE :
                //<Bitwise Or Expression> ::= <Bitwise Or Expression> '|' <Bitwise XOr Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXPRESSION :
                //<Logical And Expression> ::= <Bitwise Or Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALANDEXPRESSION_AMPAMP :
                //<Logical And Expression> ::= <Logical And Expression> '&&' <Bitwise Or Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXPRESSION :
                //<Logical Or Expression> ::= <Logical And Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LOGICALOREXPRESSION_PIPEPIPE :
                //<Logical Or Expression> ::= <Logical Or Expression> '||' <Logical And Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALEXPRESSION :
                //<Conditional Expression> ::= <Logical Or Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONDITIONALEXPRESSION_QUESTION_COLON :
                //<Conditional Expression> ::= <Logical Or Expression> '?' <Assignment Expression> ':' <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTEXPRESSION :
                //<Assignment Expression> ::= <Conditional Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTEXPRESSION2 :
                //<Assignment Expression> ::= <Left Hand Side Expression> <Assignment Operator> <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_EQ :
                //<Assignment Operator> ::= '='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_TIMESEQ :
                //<Assignment Operator> ::= '*='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_DIVEQ :
                //<Assignment Operator> ::= '/='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_PERCENTEQ :
                //<Assignment Operator> ::= '%='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_PLUSEQ :
                //<Assignment Operator> ::= '+='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_MINUSEQ :
                //<Assignment Operator> ::= '-='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_LTLTEQ :
                //<Assignment Operator> ::= '<<='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_GTGTEQ :
                //<Assignment Operator> ::= '>>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_GTGTGTEQ :
                //<Assignment Operator> ::= '>>>='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_AMPEQ :
                //<Assignment Operator> ::= '&='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_CARETEQ :
                //<Assignment Operator> ::= '^='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ASSIGNMENTOPERATOR_PIPEEQ :
                //<Assignment Operator> ::= '|='
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION :
                //<Expression> ::= <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EXPRESSION_COMMA :
                //<Expression> ::= <Expression> ',' <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE :
                //<Block> ::= '{' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BLOCK_LBRACE_RBRACE2 :
                //<Block> ::= '{' <Statement List> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT :
                //<Statement> ::= <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT2 :
                //<Statement> ::= <Variable Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT3 :
                //<Statement> ::= <Empty Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT4 :
                //<Statement> ::= <If Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT5 :
                //<Statement> ::= <If Else Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT6 :
                //<Statement> ::= <Iteration Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT7 :
                //<Statement> ::= <Continue Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT8 :
                //<Statement> ::= <Break Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT9 :
                //<Statement> ::= <Return Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT10 :
                //<Statement> ::= <With Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT11 :
                //<Statement> ::= <Labelled Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT12 :
                //<Statement> ::= <Switch Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT13 :
                //<Statement> ::= <Throw Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT14 :
                //<Statement> ::= <Try Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENT15 :
                //<Statement> ::= <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST :
                //<Statement List> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_STATEMENTLIST2 :
                //<Statement List> ::= <Statement List> <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLESTATEMENT_VAR_SEMI :
                //<Variable Statement> ::= var <Variable Declaration List> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATIONLIST :
                //<Variable Declaration List> ::= <Variable Declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATIONLIST_COMMA :
                //<Variable Declaration List> ::= <Variable Declaration List> ',' <Variable Declaration>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER :
                //<Variable Declaration> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_VARIABLEDECLARATION_IDENTIFIER2 :
                //<Variable Declaration> ::= Identifier <Initializer>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_INITIALIZER_EQ :
                //<Initializer> ::= '=' <Assignment Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_EMPTYSTATEMENT_SEMI :
                //<Empty Statement> ::= ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFSTATEMENT_IF_LPAREN_RPAREN :
                //<If Statement> ::= if '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_IFELSESTATEMENT_IF_LPAREN_RPAREN_ELSE :
                //<If Else Statement> ::= if '(' <Expression> ')' <Statement> else <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATIONSTATEMENT_DO_WHILE_LPAREN_RPAREN_SEMI :
                //<Iteration Statement> ::= do <Statement> while '(' <Expression> ')' ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATIONSTATEMENT_WHILE_LPAREN_RPAREN :
                //<Iteration Statement> ::= while '(' <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATIONSTATEMENT_FOR_LPAREN_SEMI_SEMI_RPAREN :
                //<Iteration Statement> ::= for '(' <Expression> ';' <Expression> ';' <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATIONSTATEMENT_FOR_LPAREN_VAR_SEMI_SEMI_RPAREN :
                //<Iteration Statement> ::= for '(' var <Variable Declaration List> ';' <Expression> ';' <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATIONSTATEMENT_FOR_LPAREN_IN_RPAREN :
                //<Iteration Statement> ::= for '(' <Left Hand Side Expression> in <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_ITERATIONSTATEMENT_FOR_LPAREN_VAR_IN_RPAREN :
                //<Iteration Statement> ::= for '(' var <Variable Declaration> in <Expression> ')' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTINUESTATEMENT_CONTINUE_SEMI :
                //<Continue Statement> ::= continue ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CONTINUESTATEMENT_CONTINUE_IDENTIFIER_SEMI :
                //<Continue Statement> ::= continue Identifier ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BREAKSTATEMENT_BREAK_SEMI :
                //<Break Statement> ::= break ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_BREAKSTATEMENT_BREAK_IDENTIFIER_SEMI :
                //<Break Statement> ::= break Identifier ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI :
                //<Return Statement> ::= return ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI2 :
                //<Return Statement> ::= return <Expression> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_WITHSTATEMENT_WITH_LPAREN_RPAREN_SEMI :
                //<With Statement> ::= with '(' <Expression> ')' <Statement> ';'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SWITCHSTATEMENT_SWITCH_LPAREN_RPAREN :
                //<Switch Statement> ::= switch '(' <Expression> ')' <Case Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE :
                //<Case Block> ::= '{' '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE2 :
                //<Case Block> ::= '{' <Case Clauses> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE3 :
                //<Case Block> ::= '{' <Case Clauses> <Default Clause> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE4 :
                //<Case Block> ::= '{' <Case Clauses> <Default Clause> <Case Clauses> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE5 :
                //<Case Block> ::= '{' <Default Clause> <Case Clauses> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASEBLOCK_LBRACE_RBRACE6 :
                //<Case Block> ::= '{' <Default Clause> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASECLAUSES :
                //<Case Clauses> ::= <Case Clause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASECLAUSES2 :
                //<Case Clauses> ::= <Case Clauses> <Case Clause>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASECLAUSE_CASE_COLON :
                //<Case Clause> ::= case <Expression> ':' <Statement List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CASECLAUSE_CASE_COLON2 :
                //<Case Clause> ::= case <Expression> ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULTCLAUSE_DEFAULT_COLON :
                //<Default Clause> ::= default ':'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_DEFAULTCLAUSE_DEFAULT_COLON2 :
                //<Default Clause> ::= default ':' <Statement List>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_LABELLEDSTATEMENT_IDENTIFIER_COLON :
                //<Labelled Statement> ::= Identifier ':' <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_THROWSTATEMENT_THROW :
                //<Throw Statement> ::= throw <Expression>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TRYSTATEMENT_TRY :
                //<Try Statement> ::= try <Block> <Catch>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TRYSTATEMENT_TRY2 :
                //<Try Statement> ::= try <Block> <Finally>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_TRYSTATEMENT_TRY3 :
                //<Try Statement> ::= try <Block> <Catch> <Finally>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_CATCH_CATCH_LPAREN_IDENTIFIER_RPAREN :
                //<Catch> ::= catch '(' Identifier ')' <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FINALLY_FINALLY :
                //<Finally> ::= finally <Block>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDECLARATION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Function Declaration> ::= function Identifier '(' <Formal Parameter List> ')' '{' <Function Body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONDECLARATION_FUNCTION_IDENTIFIER_LPAREN_RPAREN_LBRACE_RBRACE2 :
                //<Function Declaration> ::= function Identifier '(' ')' '{' <Function Body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONEXPRESSION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE :
                //<Function Expression> ::= function '(' ')' '{' <Function Body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONEXPRESSION_FUNCTION_LPAREN_RPAREN_LBRACE_RBRACE2 :
                //<Function Expression> ::= function '(' <Formal Parameter List> ')' '{' <Function Body> '}'
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMETERLIST_IDENTIFIER :
                //<Formal Parameter List> ::= Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FORMALPARAMETERLIST_COMMA_IDENTIFIER :
                //<Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONBODY :
                //<Function Body> ::= <Source Elements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_FUNCTIONBODY2 :
                //<Function Body> ::= 
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_PROGRAM :
                //<Program> ::= <Source Elements>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SOURCEELEMENTS :
                //<Source Elements> ::= <Source Element>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SOURCEELEMENTS2 :
                //<Source Elements> ::= <Source Elements> <Source Element>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SOURCEELEMENT :
                //<Source Element> ::= <Statement>
                //todo: Create a new object using the stored tokens.
                return null;

                case (int)RuleConstants.RULE_SOURCEELEMENT2 :
                //<Source Element> ::= <Function Declaration>
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
            string message = "Parse error caused by token: '"+args.UnexpectedToken.ToString()+"'"+ "in line "+args.UnexpectedToken.Location.LineNr;
            lst.Items.Add(message);
            string m2 = "Expected Token: "+args.ExpectedTokens.ToString();
            lst.Items.Add(m2);
            //todo: Report message to UI?
        }

        private void TokenReadEvent(LALRParser parser, TokenReadEventArgs args)
        {
            string info = args.Token.Text + "\t\t\t" + (SymbolConstants)args.Token.Symbol.Id;
            ls.Items.Add(info);
        }

    }
}
