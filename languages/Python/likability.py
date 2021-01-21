lb = [0]
from haogan import likability
lb[0] = likability
def files(value):
    with open('haogan.py','r+') as f:
        f.write(f'likability = {value}')
class haogan():
    def add(self,value):
        lb[0] = lb[0] + value
        files(lb[0])
    def remove(self,value):
        lb[0] = lb[0] - value
        files(lb[0])
    def clean(self):
        files(0)
    def get_haogan(self):
        return lb[0]