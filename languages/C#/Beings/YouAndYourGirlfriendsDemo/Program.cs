using CreatePeople.Core.Models;
using System;

namespace YouAndYourGirlfriendsDemo
{
    class Program
    {
        static void Main()
        {
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
                Console.WriteLine($"{me.Name} 与 {other.Name} 分手了 !");

                Console.WriteLine($"画外音: {s.Tip}");
            };

            me.FallInLoveWith(her);
            me.FallInLoveWith(her2);
            me.BreakUp(her2);
            me.BeMarried(her2);
            Console.ReadKey();

        }
    }
}
