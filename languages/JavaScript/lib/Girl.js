class Girl {
  constructor(name, boyFriend, hateName) {
    this.name = name;
    this.boyFirend = boyFriend;
    this.hateName = hateName
  }
  say() {
    console.log(this.name + "的男朋友是" + this.boyFriend + "她讨厌" + this.hateName);
  }
};
const girlFriend = new Parent('纸片人', "纯爱战士", "牛头人");
girlFriend.say()