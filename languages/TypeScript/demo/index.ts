import Person from "../lib/Person";
import Girl from "../lib/Girl";

const me = new Person();
me.name = "我";

const girl = new Girl();
girl.name = "女朋友";

girl.kiss(me);
girl.fallInLoveWith(me);
