using CreatePeople.Core.Models;
using System;

namespace YouAndYourGirlfriendsDemo
{
    class Program
    {
        static void Main()
        {
            // 用反射来创建 人物
            //object[] InfoAboutMe = new object[] {"张三"};
            //People me = PeopleFactory.CreatePeole(typeof(Boy), InfoAboutMe);

            Boy me = new Boy
            {
                Name = "张三"
            };
            Girl her = new Girl
            {
                Name = "李四"
            };
            Girl her2 = new Girl
            {
                Name = "王五"
            };
            Girl her3 = new Girl
            {
                Name = "雷六"
            };

            me.FallInLoveEvent += (e, s) =>
            {
                var me = (People)e;
                var partner = (People)s.T;
                Console.WriteLine($"{me.Name} 和 {partner.Name} 坠入爱河!");

                Console.WriteLine($"画外音: {s.Tip}");
            };
            me.MarryEvent += (e, s) =>
            {
                var me = (People)e;
                var spouse = (People)s.T;
                Console.WriteLine($"{me.Name} 与 {spouse.Name} 结为夫妻!");

                Console.WriteLine($"画外音: {s.Tip}");
            };
            me.BreakUpEvent += (e, s) =>
            {
                var me = (People)e;
                var other = (People)s.T;

                if (other == null)
                {
                    Console.WriteLine($"{me.Name} 陷入分手循环!");
                }
                else
                {

                    Console.WriteLine($"{me.Name} 与 {other?.Name} 分手了 !");
                }

                Console.WriteLine($"画外音: {s.Tip}");
            };

            me.FallInLoveWith(her);
            me.FallInLoveWith(her2);
            me.FallInLoveWith(her3);
            me.FallInLove();
            me.FallInLove();
            me.FallInLove();
            me.FallInLoveWith(her2);
            me.BreakUpWith(her2);
            me.BreakUp();
            me.BreakUp();
            me.BreakUp();
            me.BreakUp();
            me.FallInLoveWith(her3);
            me.ToMarry();
            Console.ReadKey();

        }
    }
}
