/**
 * Xp System
 */
export class Xp {
  constructor(public keywords: string[] = ["可爱", "JK", "二次元"]) {}

  /**
   * 是否匹配
   * @param tags
   */
  match(tags: string[]) {
    const keywords = this.keywords.map((keyword) => keyword.toLowerCase());
    return tags.some((tag) => {
      return keywords.includes(tag.toLowerCase());
    });
  }

  print() {
    console.log("干，老兄，你的 xp 好 jb 怪！");
  }
}
