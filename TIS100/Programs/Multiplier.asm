
@1
MOV UP ACC
MOV ACC RIGHT
MOV ACC RIGHT

@2
MOV UP ACC
MOV ACC RIGHT
SUB LEFT
JGZ ELSE
MOV LEFT DOWN
MOV RIGHT DOWN
JRO -99
ELSE:
MOV RIGHT DOWN
MOV LEFT DOWN

@3
MOV UP ACC
SAV
MOV UP ACC
LOOP:
JEZ DONE
SWP
MOV ACC DOWN
MOV ACC DOWN
SWP
SUB 1
JMP LOOP
DONE:
MOV -1 DOWN

@4
MOV UP ACC
JLZ DONE
SWP
ADD UP
SWP
JRO -99
DONE:
SWP
MOV ACC DOWN
MOV 0 ACC
SAV

@5
MOV LEFT LEFT
