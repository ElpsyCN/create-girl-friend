NASM=nasm
cc=gcc
LINKER=ld
SRC_DIR=src
INC_DIR=inc
OBJ_DIR=obj
BIN_DIR=bin

build: $(SRC_DIR)/main.asm
	@mkdir -p bin
	@mkdir -p obj
	@$(NASM) -O0 -g -f elf64 $(SRC_DIR)/main.asm -o $(OBJ_DIR)/main.o
	@$(cc) -g -no-pie -o $(BIN_DIR)/main $(OBJ_DIR)/main.o
	@echo 'Please run ./bin/main'