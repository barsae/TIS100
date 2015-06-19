
# TIS-100 Emulator
This is a fun side project to emulate the solutions to Zachtronics game "[TIS-100](http://www.zachtronics.com/tis-100/)."

## Download
Get the Windows executable _here_

## Usage
To run the emulator, execute `TIS100.exe <asm filename> <board filename>` from the command line.  The expected file formats are explained below.

## ASM File Format
The .asm file format is essentially the same as used for the save files.  The `@1` syntax starts a block of code belonging to a specific chip.  Then, an `@2` line begins the next block, etc.

For example, the following file specifies two chips that will "triplicate" a given input.  That is, the input `1, 2, 3` will be expanded into `0, 0, 1; 0, 1, 2; 1, 2, 3`.
```
@1
mov right down
swp
mov acc right
mov acc down
mov up acc
mov acc down
sav

@2
mov 0 left
top:
mov left left
jmp top
```

## Board File Format
Since each level uses a potentially different chip layout, we use the board file to specify which chips are in which positions.  Each line represents a chip, and has the following format, with the parts explained below: `<name> <x position> <y position> <type>`.

* `<name>` is one of the `@1` style names referred to in the .asm file.
* `<x position>` and `<y position>` are integers representing the location of the chip.  `x` increases going right across the screen, and `y` increases going down the screen.
* `<type>` can be either `AssemblyChip` or `ConsoleChip`.
  * `AssemblyChip` is the TIS-100 programmable assembly chip you are used to.
  * `ConsoleChip` is a chip specific to this implementation that reads and writes input using the console.

The following board file specifies the chip configuration to make the triplicator code above work as intended.

```
@1 0 0 AssemblyChip
@2 1 0 AssemblyChip
@3 0 -1 ConsoleChip
@4 0 1 ConsoleChip
```

## Credits
* [Leah Perlmutter](https://github.com/lrperlmu) for helping me break the problem into easier to solve problems.
* [Zachtronics](http://www.zachtronics.com/) for making awesome engineering puzzle games.

