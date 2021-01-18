[bits 64]

STDIN_FILE_ID         equ     0
STDOUT_FILE_ID        equ     1

section .text

  sys_read:
    ; ssize_t read(int fd, void *buf, size_t count);
    mov rax,0
    syscall
    ret

  sys_write:
    ; ssize_t sys_write(int fd, const void *buf, size_t count);
    mov rax,1
    syscall
    ret

  sys_brk:
    ; int brk(void *addr);
    mov rax,12
    syscall
    ret

  sys_exit:
    ; void _exit(int status);
    mov rax,60
    syscall
    ret