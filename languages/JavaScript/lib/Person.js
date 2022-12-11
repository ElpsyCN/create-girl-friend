import { Xp } from "./Xp";

/**
 * 人
 */
export default class Person {
  /**
   * 姓名
   */
  name = "";
  /**
   * 年龄
   */
  age = 0;

  /**
   * 标签
   */
  tags = [];

  /**
   * XP 系统
   */
  xp = new Xp();

  /**
   * 说话
   * @param word
   */
  say(word) {
    console.log(word);
  }

  like(girl) {
    return this.xp.match(girl.tags);
  }
}
