using CreatePeople.Core.Events;
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

        public virtual void FallInLoveWith(People people)
        {
            FallInLoveArgs e = new FallInLoveArgs
            {
                T = people
            };
            // 存在脚踏多条船的情况
            CurrentMate.Add(people);
            people.CurrentMate.Add(this);

            if(CurrentMate.Count == 1 && people.CurrentMate.Count == 1)
            {
                e.Tip = "彼此都是初恋";
                FallInLoveEvent?.Invoke(this, e);
            }

            if (CurrentMate.Count > 1)
            {
                e.Tip = $"{this.Name} 正在广撒网";
                FallInLoveEvent?.Invoke(this, e);
            }
            if (people.CurrentMate.Count >1)
            {
                e.Tip = $"{people.Name} 正在广撒网";
                FallInLoveEvent?.Invoke(this, e);
            }
        }

        public virtual void BreakUp(People people)
        {
            BreakUpArgs e = new BreakUpArgs
            {
                T = people
            };

            var index = CurrentMate.FindIndex((t) => t.Equals(people));
            if (index == -1)
            {
                throw new Exception("从未在一起，何来分手!");
            }
            else
            {
                PreviousMate.Add(CurrentMate[index]);
                CurrentMate.RemoveAt(index);

                people.PreviousMate.Add(this);
                people.CurrentMate.Remove(this);

                e.Tip = "所以，爱会消失的，对吗？";
                BreakUpEvent?.Invoke(this, e);
            }


        }
        public virtual void BeMarried(People people)
        {
            MarryArgs e = new MarryArgs
            {
                T = people
            };

            if (PreviousMate.Count == 0 && CurrentMate.Count ==  1 && people.PreviousMate.Count == 0 && people.CurrentMate.Count == 1 && CurrentMate[CurrentMate.Count - 1] == people)
            {
                e.Tip = "从一而终，矢志不渝！";
                MarryEvent?.Invoke(this, e);
            }
            else
            {
                var curIndex = CurrentMate.FindIndex((t) =>  t.Equals(people));
                var preIndex = PreviousMate.FindIndex((t) => t.Equals(people));
                if (curIndex == -1 && preIndex == -1)
                {
                    e.Tip = "我结婚了，新郎（娘）不是他！";
                    MarryEvent?.Invoke(this, e);

                }
                else if (curIndex == CurrentMate.Count - 1)
                {
                    e.Tip = "执子之手，与子偕老！";
                    MarryEvent?.Invoke(this, e);
                }
                else if (preIndex != -1 || curIndex != -1)
                {
                    e.Tip = "破镜也能重圆！";
                    MarryEvent?.Invoke(this, e);
                }

            }

            Couple = people;
            people.Couple = this;
        }
    }
}
