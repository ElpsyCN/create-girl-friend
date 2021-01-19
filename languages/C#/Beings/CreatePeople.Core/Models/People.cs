using CreatePeople.Core.Events;
using CreatePeople.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using static CreatePeople.Core.Events.PeopleEvents;

namespace CreatePeople.Core.Models
{
    public class People
    {
        public string Name { get; set; }
        public Gender Gender { get; set; } = Gender.Other;
        public Gender Sexual { get; set; }
        public List<People> CurrentMate { get; set; } = new List<People>();

        // 判断他（她）是否有过女（男）朋友
        public bool IfHadMate = false;
        public List<People> PreviousMate { get; set; } = new List<People>();
        public People Couple { get; set; }
        public DateTime DateOfBrith { get; set; }
        public DateTime DateOfDenth { get; set; }

        // Declare the event.
        public event FallInLoveEventHandler FallInLoveEvent;
        public event BreakUpEventHandler BreakUpEvent;
        public event MarryEventHandler MarryEvent;

        public People()
        {

        }

       public virtual void FallInLove()
        {
            // 默认与最新的一个对象，坠入爱河。
            FallInLoveArgs e = new FallInLoveArgs() ;
            
            if (CurrentMate.Count == 0)
            {
                throw new NotFoundCurrentMateException("呓！你爱的甚么！");
            }
            else
            {
                People people = CurrentMate[^1];
                e.T = people;
                e.Tip = "我爱你，我爱你多一分";
                FallInLoveEvent?.Invoke(this, e);
            }
        }
        public virtual void FallInLoveWith(People people)
        {
            FallInLoveArgs e = new FallInLoveArgs
            {
                T = people
            };

            var curIndex = CurrentMate.FindIndex((t) => t.Equals(people));
            var preIndex = PreviousMate.FindIndex(t => t.Equals(people));
            
            if (curIndex ==  -1)
            {
                // 存在脚踏多条船的情况
                CurrentMate.Add(people);
                people.CurrentMate.Add(this);
            }
            if (curIndex == -1 && preIndex == -1)
            {
                if (!(IfHadMate))
                {
                    e.Tip = "初恋的感觉真美好！";
                }
                else
                {
                    e.Tip = "新的生活！";
                    if (CurrentMate.Count > 1)
                    {
                        e.Tip += " 多线程战士";
                    }
                }
            }
            else if (curIndex == -1 && preIndex != -1)
            {
                e.Tip = "我们复合了，今后的路我们能继续走下去吗？";
            }
            else if (curIndex != -1 && preIndex == -1)
            {
                e.Tip = "万花丛中，我爱你多一分！";
            }
            else if (curIndex != -1 && preIndex != -1)
            {
                e.Tip = "喂喂喂，这一定是我脑子出毛病了！";

            }
            FallInLoveEvent?.Invoke(this, e);

            IfHadMate = true;

        }
        public virtual void BreakUpWith(People people)
        {
            BreakUpArgs e = new BreakUpArgs
            {
                T = people
            };
            var curIndex = CurrentMate.FindIndex((t) => t.Equals(people));
            var preIndex = PreviousMate.FindIndex(t => t.Equals(people));
            if (curIndex == -1 && preIndex == -1)
            {
                throw new RelationshipException("关系异常，你们从未在一起过");
            }
            else if (curIndex == -1 && preIndex != -1)
            {
                throw new RelationshipException("关系异常，你没有分手的资格");
            }
            else if (curIndex != -1 && preIndex == -1 )
            {
                e.Tip = "所以，爱会消失的，对吗？";
            }
            else if (curIndex != -1 && preIndex != -1)
            {

                e.Tip = "分久必合，合久必分，下次继续啊！";
               
            }
            PreviousMate.Add(CurrentMate[curIndex]);
            CurrentMate.RemoveAt(curIndex);

            people.PreviousMate.Add(this);
            people.CurrentMate.Remove(this);
            BreakUpEvent?.Invoke(this, e);

        }
        public virtual void BreakUp()
        {
            // 不加参数，则默认从最后一个伴侣结束关系
            BreakUpArgs e = new BreakUpArgs();

            if (CurrentMate.Count == 0)
            {
                if (!IfHadMate)
                {
                    throw new NotFoundCurrentMateException("你个单身狗，想啥呢！");
                }
                e.T = null;
                e.Tip = "终究还是一个人!";
                BreakUpEvent?.Invoke(this, e);
            }
            else
            {
                var t = CurrentMate[^1];
                e.T = t;
                CurrentMate.Remove(t);
                PreviousMate.Add(t);
                t.CurrentMate.Remove(this);
                t.PreviousMate.Add(this);
                e.Tip = "让我们友好地说再见吧!";
                BreakUpEvent?.Invoke(this, e);
            }

        }
        public virtual void ToMarry()
        {
            if (CurrentMate.Count == 0)
            {
                throw new NotToMarryException("女朋友都没有，就像这结婚呢！");
            }
            else
            {
                People people = CurrentMate[^1];
                ToMarryWith(people);
            }
        
        }
        public virtual void ToMarryWith(People people)
        {
            MarryArgs e = new MarryArgs
            {
                T = people
            };

            if (PreviousMate.Count == 0 && CurrentMate.Count ==  1 && people.PreviousMate.Count == 0 && people.CurrentMate.Count == 1 && CurrentMate[^1] == people)
            {
                e.Tip = "从一而终，矢志不渝！";
            }
            else
            {
                var curIndex = CurrentMate.FindIndex((t) =>  t.Equals(people));
                var preIndex = PreviousMate.FindIndex((t) => t.Equals(people));

                if (curIndex == -1 && preIndex == -1)
                {

                    e.Tip = "到头来，还是败给了现实！";
                    MarryEvent?.Invoke(this, e);
                }
                else if (curIndex == -1 && preIndex != -1)
                {

                    e.Tip = "破镜也能重圆";
                }
                else if (curIndex != -1 && preIndex == -1)
                {
                    if (curIndex == CurrentMate.Count -1)
                    {

                        e.Tip = "希望从今天开始，能一直一直走下去！";
                    }
                    else
                    {
                        e.Tip = "选择最适合自己的！";
                    }
                }
                else if(curIndex != -1 && preIndex != -1)
                {
                    e.Tip = "从喜欢到讨厌，从讨厌到喜欢，我原来还是最在意你啊！";
                }
            }

            MarryEvent?.Invoke(this, e);
            PreviousMate.AddRange(CurrentMate);
            Couple = people;
            people.Couple = this;
        }
        public virtual void ToLick()
        {
        }
        public virtual void ToLickWith(People people)
        {

        }

        public virtual void ToKill()
        {

        }
        public virtual void ToKillWith(People people)
        {

        }
        public virtual void ToMakeLove()
        {

        }
        public virtual void ToMakeLoveWith(People people)
        {

        }
    }
}
