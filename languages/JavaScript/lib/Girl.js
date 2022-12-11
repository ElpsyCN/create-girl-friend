import Person from "./Person";

/**
 * 女孩子
 */
export default class Girl extends Person {
  /**
   * Kiss
   */
  kiss(someone) {
    console.log(`「${this.name}」 亲了下 「${someone.name}」。`);
  }

  /**
   * 与某人坠入爱河
   * @param someone 某人
   */
  fallInLoveWith(someone) {
    console.log(`「${this.name}」 与 「${someone.name}」 坠入爱河。`);
  }
}
