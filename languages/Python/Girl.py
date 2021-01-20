import requests
import json
class girl():
    def __init__(self,name,boyname,hatename):
        self.name = name
        self.boyname = boyname
        self.hatename = hatename
    def say(self):
        print(f'我 {self.name} 的男朋友是 {self.boyname} ,我讨厌 {self.hatename}')
    def say_nb(self):
        respoen = requests.get('https://el-bot-api.vercel.app/api/words/niubi')
        # 熟悉的api
        get_list = json.loads(respoen.text)
        rest = str(get_list[0])
        print(rest.replace('${name}',self.boyname))
    def say_wanan(self):
        respoen = requests.get('https://el-bot-api.vercel.app/api/words/wanan')
        # en......
        rest = json.loads(respoen.text)
        print(rest[0])