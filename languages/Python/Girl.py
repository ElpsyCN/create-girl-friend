import requests
import json
import likability
haogan = likability.haogan()

class girl():
    def __init__(self,name,boyname,hatename):
        self.name = name
        self.boyname = boyname
        self.hatename = hatename
    def say(self):
        print(f'我 {self.name} 的男朋友是 {self.boyname} ,我讨厌 {self.hatename}')
        # 只要正确操作就会增加好感度
        haogan.add(1)

    def say_nb(self):
        respoen = requests.get('https://el-bot-api.vercel.app/api/words/niubi')
        # 熟悉的api
        get_list = json.loads(respoen.text)
        rest = str(get_list[0])
        print(rest.replace('${name}',self.boyname))

        haogan.add(1)

    def say_wanan(self):
        respoen = requests.get('https://el-bot-api.vercel.app/api/words/wanan')
        # en......
        rest = json.loads(respoen.text)

        print(rest[0])
        haogan.add(1)
    def haogandu(self):
        print(f'当前好感度{haogan.get_haogan()}\n正确操作可以增加好感度\n错误会减少')
    def remove_hgd(self):
        haogan.remove(1)
class girl_launcher():
    def __init__(self,object_girl):
        self.girl = object_girl
    def launch(self):
        girl = self.girl
        while True:
            get = input('\n1.说说想法\n2.说我nb\n3.说晚安\n4.查询好感度\n5.退出\n')
            try:
                g = int(get)
                if g == 1:
                    girl.say()
                elif g == 2:
                    girl.say_nb()
                elif g == 3:
                    girl.say_wanan()
                elif g == 5:
                    print('拜拜QWQ')
                    break
                elif g == 4:
                    girl.haogandu()
                else:
                    print('还没有这个功能')
                    girl.remove_hgd()

            except ValueError:
                print('数字指令嗷')
                girl.remove_hgd()
        
        print(rest[0])

