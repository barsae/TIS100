grammar TisLang;

options {
    language=CSharp3;
}

@lexer::namespace{TisLang}
@parser::namespace{TisLang}

program : expression*;

expression : label
           | instruction
           ;

label : SYMBOL ':' EOL;

instruction : SYMBOL (','? SYMBOL)*;

SYMBOL : [a-zA-Z_][a-zA-Z0-9_]*;
INTEGER : '-'?[0-9]+;
EOL : ('\r\n' | '\r' | '\n');
WHITESPACE : (' ' | '\t') -> channel(HIDDEN);
