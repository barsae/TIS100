grammar TisLang;

options {
    language=CSharp3;
}

@lexer::namespace{TisLang}
@parser::namespace{TisLang}

program : expression*;

expression : label
           | instruction
           | EOL
           ;

label : SYMBOL ':' EOL;

instruction : SYMBOL argumentList EOL;

argumentList : (argument (COMMA? argument)*)?;

argument : SYMBOL
         | INTEGER
         ;

SYMBOL : [a-zA-Z_][a-zA-Z0-9_]*;
INTEGER : '-'?[0-9]+;
EOL : ('\r\n' | '\r' | '\n' | EOF);
WHITESPACE : (' ' | '\t') -> channel(HIDDEN);
