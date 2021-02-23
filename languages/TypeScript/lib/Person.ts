import Girl from "./Girl";
import { Xp } from "./Xp";

/**
 * 人
 */
export default class Person {
  /**
   * 姓名
   */
  name: string = "";
  /**
   * 年龄
   */
  age: number = 0;

  /**
   * 标签
   */
  tags: string[] = [];

  /**
   * XP 系统
   */
  xp = new Xp();

  /**
   * 说话
   * @param word
   */
  say(word: string) {
    console.log(word);
  }

  like(girl: Girl) {
    return this.xp.match(girl.tags);
  }
}
