import Person from "../lib/Person";
import Girl from "../lib/Girl";

const me = new Person();
me.name = "我";

const girl = new Girl();
girl.name = "女朋友";

girl.tags = ["JK"];
girl.kiss(me);
girl.fallInLoveWith(me);

if (me.like(girl)) {
  me.say("戳我 xp 了！");
} else {
  me.say("就这?");
}
