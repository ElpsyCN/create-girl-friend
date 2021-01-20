from Girl import girl
test_girl = girl('Test Girl','Me','Fu*cker')
while True:
    get = input('\n1.说说想法\n2.说我nb\n3.说晚安\n4.退出\n')
    try:
        g = int(get)
        if g == 1:
            test_girl.say()
        elif g == 2:
            test_girl.say_nb()
        elif g == 3:
            test_girl.say_wanan()
        elif g == 4:
            print('拜拜QWQ')
            break
        else:
            print('还没有这个功能')
    except TypeError:
        print('数字指令嗷')