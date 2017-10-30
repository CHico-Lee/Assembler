# Assembler
Tool to convert between instruction and machine code

## Description
Assembler is a program to convert between assembly language instruction and machine code.

Supported OS: Windows

Currently support this 1 byte instruction set and encoding:

	ADD		RD, RS	  add registers RD+RS, store the result in RD
	SUB		RD, RS	  subtract registers RD-RS, store the result in RD
	LOAD		RD,[RS]	  load 1 byte from memory at address RS into RD
	STORE           RD,[RS]	  store 1 byte from RD into memory at address RS
	JLEZ		RD,RS     if RS<=0, jump to address in RD
	JALR		RD,RS     save PC+1 into RS, jump to RD
	LUI		RT, IMM	  load 4-bit IMM into the upper four bits of RT
	LLI		RT, IMM	  load 4-bit IMM into the lower four bits of RT

```
Registers: A=00, B=01, C=10, D=11

ADD		0 0 0 0 RD1 RD0 RS1 RS0	
					example: ADD B,C = 0 0 0 0 0 1 1 0 = 06h
SUB		0 0 0 1 RD1 RD0 RS1 RS0
					example: SUB D,D = 0 0 0 1 1 1 1 1 = 1Fh
LOAD		0 0 1 0 RD1 RD0 RS1 RS0
					example: LOAD C,[B] = 0 0 1 0 1 0 0 1 = 29h
STORE	        0 0 1 1 RD1 RD0 RS1 RS0
					example: STORE C,[B] = 0 0 1 1 1 0 0 1 = 29h
JLEZ		0 1 0 0 RD1 RD0 RS1 RS0
					example: JLEZ A,B = 0 1 0 0 0 0 0 1 = 41h
JALR		0 1 0 1 RD1 RD0 RS1 RS0
					example: JALR C,D = 0 1 0 1 1 0 1 1 = 5bh
LUI		1 0 RT1 RT0 IMM3 IMM2 IMM1 IMM0
					example: LUI C, 9 = 1 0 1 0 1 0 0 1 = A9h
LLI		1 1 RT1 RT0 IMM3 IMM2 IMM1 IMM0
					example: LLI B, 2 = 1 1 0 1 0 0 1 0 = D2h
```

## Feature
Instruction can import from the .dat file.
Instruction will be saved to the original file after successfully convert to the binary machine code.
Machine code will be converted into formats included:
Readable format with #PC, OPcode, binary and hex.
Hex for EmuMaker86 memory file.
Hex prefixed with “0x” and separate by “,”.
Hex for the array of memory in Verilog (custom variable name).

## To Run
### Convert assembly to machine code.
1.  Download and run Assembler.exe.
2.  Fill in Loop label(optional), OPcode, RD/RT, and RS/IMM.
3.  Use “+” button to add a new line.
4.  After completed all instruction, use numericupdown to select number of NOPs to insert between each instruction.
5.  Click “Convert to Binary >>” to covert assembly to machine code.
6.  If an error occurs, please check instruction followed by PC number.
7.  Use “Copy All” to copy the needed code into the clipboard.
8.  Instruction will be saved to file “program.dat” on the same directory.

### Convert from Readable format to assembly.
This method is design for editing existing instruction from draft. The instruction must be input in the following format:
1.  Copy and plate Readable format instruction into the top right text field.
2.  Click “Input to Assembly << ”.
3.  Instruction should be imported and display on the left.
4.  Comment of the instruction will be retrieved when converting back to machine code.
 ### Convert from machine code to assembly.
This method is design to produce assembly from EmuMaker86 memory file.
1.	Input hex code into the bottom text field, one hex code per line.
2.	Click “Input from Hex to Assembly <<”.
3.	Instruction should be imported and display on the left.
