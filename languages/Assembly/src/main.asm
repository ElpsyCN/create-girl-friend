[bits 64]

; 注释中有不少开玩笑的成分，不要当真。

%include "inc/syscall.asm"

section .data
  msg_intput_her_name                 db          '请输入您的对象的姓名：'
  msg_intput_her_name_len             equ         $-msg_intput_her_name

  msg_input_your_name                 db          '请输入您的姓名：'
  msg_input_your_name_len             equ         $-msg_input_your_name

  msg_is_a_beauty_girl                db          '是一个美少女', 0x0a
  msg_is_a_beauty_girl_len            equ         $-msg_is_a_beauty_girl

  msg_she_love                        db          '她喜欢',
  msg_she_love_len                    equ         $-msg_she_love

  msg_end                             db          0x0a, 0x0d, '从此两人过上了幸福快乐的生活', 0x0a
  msg_end_len                         equ         $-msg_end

  program_break                       dq          0

[bits 64]

; x86_64 系统调用约定：
    ; * 参数数量小于 7 个：从左到右依次存入 rdi，rsi，rdx，r10，r8，r9。
    ; * 参数数量大于等 7 个：依次存放在一段连续的内存，内存首地址存入 rbx。

; x86_64 调用约定：
    ; * 参数数量小于 7 个：从左到右依次存入 rdi, rsi, rdx, rcx, r8, r9。
    ; * 参数数量大于等 7 个：前 7 个参数与上面一样，从第八个参数开始从右到左压栈。

; 我心目的中的对象（专业描述）：
    ; * base_addr+0 qword 恒为 1，表示是一个美少女。
    ; * base_addr+8 qword 指向美少女姓名的字符串指针。
    ; * base_addr+16 qword 指向美少女爱人姓名的字符串指针。
    ; * 对象占用的空间为 8 Byte × 3 = 24 Byte。美少女就是这么苗条。

; 我心目的中的对象（人话）：
    ; * 她是个美少女。
    ; * 她的名字很好听。
    ; * 她的爱人是我。

section .text
  global main

main:

  ; 显示信息「请输入您的对象姓名」
  mov rdi,msg_intput_her_name             ; 字符串首地址
  mov rsi,msg_intput_her_name_len         ; 字符串长度
  call puts                               ; 调用字符串打印过程

  ; 从键盘读取信息
  mov rdi,her_name                        ; 缓冲区首地址
  mov rsi,100*7                           ; 缓冲区长度
  call gets                               ; 调用键盘读取过程
  dec rax                                 ; 丢弃末尾的换行符
  mov qword [her_name_len],rax            ; 存储字符串长度

  ; 显示信息「请输入您的姓名」
  mov rdi,msg_input_your_name             ; 字符串首地址
  mov rsi,msg_input_your_name_len         ; 字符串长度
  call puts                               ; 调用字符串打印例程

  ; 从键盘读取信息
  mov rdi,my_name                         ; 缓冲区首地址
  mov rsi,100*7                           ; 缓冲区长度
  call gets                               ; 调用键盘读取过程
  dec rax                                 ; 丢弃末尾的换行符
  mov qword [my_name_len],rax             ; 存储字符串长度

  ; 为对象（美少女）申请一个房间号（内存）
  mov rdi,24                              ; 申请 24 Byte 的内存
  call sbrk                               ; 调用内存申请例程
  mov [girl_addr],rax                     ; 存储分配到的内存的首地址
  mov qword [girl_addr],1                 ; 标记为美少女

  ; 让美少女爱上我
  mov rdi,[girl_addr]                     ; 美少女的房间号（地址）
  mov rsi,my_name                         ; 字符串首地址
  call beauty_girl_love                   ; 让美少女爱上我

  ; 设置美少女的姓名
  mov rdi,[girl_addr]                     ; 美少女的房间号（地址）
  mov rsi,her_name                        ; 字符串首地址
  call beauty_girl_set_name               ; 设置美少女的名字

  ; 打印美好生活
  mov rax,[girl_addr]                     ; 美少女的房间号（地址）
  add rax,8                               ; 偏移到美少女的名字
  mov rdi,[rax]                           ; 获取美少女名字的字符串的首地址
  mov rsi,[her_name_len]                  ; 字符串长度
  call puts                               ; 调用字符串打印过程

  mov rdi,msg_is_a_beauty_girl            ; 字符串首地址
  mov rsi,msg_is_a_beauty_girl_len        ; 字符串长度
  call puts                               ; 调用字符串打印过程

  mov rdi,msg_she_love                    ; 字符串首地址
  mov rsi,msg_she_love_len                ; 字符串长度
  call puts                               ; 调用字符串打印过程

  mov rax,[girl_addr]                     ; 美少女的房间号（地址）
  add rax,16                              ; 偏移到美少女的爱人的名字
  mov rdi,[rax]                           ; 获取美少女爱人的名字的字符串的首地址
  mov rsi,[my_name_len]                   ; 字符串长度
  call puts                               ; 调用字符串打印过程

  mov rdi,msg_end                         ; 字符串首地址
  mov rsi,msg_end_len                     ; 字符串长度
  call puts                               ; 调用字符串打印过程


  ; 退出程序
  call sys_exit

beauty_girl_love:
  ; 本函数没有返回值，因为美少女会无条件地爱上我。
  ; void beauty_girl_love(beauty_girl_t* girl, char* my_name);
  mov qword [rdi+16],rsi
  ret

beauty_girl_set_name:
  ; 本函数也没有返回值，因为我喜欢的美少女一定会爱上我。
  ; void beauty_girl_love(beauty_girl_t* girl, char* her_name);
  mov qword [rdi+8],rsi
  ret

gets:
  ; uint_64_t gets(char* str, size_t count);
  push rdi
  push rsi

  mov rdx,rsi
  mov rsi,rdi
  mov rdi,STDIN_FILE_ID
  call sys_read

  pop rsi
  pop rdi
  ret

puts:
  ; uint_64_t puts(char* str, size_t count);
  push rdi
  push rsi

  mov rdx,rsi
  mov rsi,rdi
  mov rdi,STDOUT_FILE_ID
  call sys_write

  pop rsi
  pop rdi
  ret

sbrk:
  ; void *sbrk(intptr_t increment);
  push rdi
  mov rax,[program_break]
  test rax,rax
  jnz .b1
  .b0:
    mov rdi,0
    call sys_brk
    mov [program_break],rax
  .b1:
  pop rdi
  push rdi
  add rdi,rax
  call sys_brk
  
  test eax,eax
  jz .b3
  .b2:
    mov rax,[program_break]
    pop rdi
    add rdi,rax
    mov [program_break],rax
    jmp .b4
  .b3:
    pop rdi
  .b4:
  ret



[bits 64]

section .bss
  girl_addr               resq          1          ; 美少女（对象）的房间号（地址）
  her_name                resq          100        ; 美少女的名字
  her_name_len            resq          1
  my_name                 resq          100        ; 我的名字，美少女不能喜欢我以外的人。
  my_name_len             resq          1
