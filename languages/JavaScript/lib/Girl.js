export default class Girl {

  constructor(name, boyFriend, hateName) {
    this.name = name;
    this.boyFirend = boyFriend;
    this.hateName = hateName
  }

  say() {
    console.log(this.name + "的男朋友是" + this.boyFriend + "她讨厌" + this.hateName);
  }

};
