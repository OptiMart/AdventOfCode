using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC.AdventOfCode.Common.Monkeys
{
    internal class Monkey
    {
        #region Constructor
        public Monkey(int number)
        {
            Number = number;
        }

        #endregion

        #region Properties
        public int Number { get; set; }
        public Queue<long> Items { get; set; } = new Queue<long>();
        public Func<long, long> Operation { get; set; }
        public Func<long, long> Test { get; set; }
        public long Throws { get; private set; } = 0;
        public long WorryFactor { get; set; } = 3;
        public List<int> Factors { get; set; }

        #endregion

        #region Methods
        public void ThrowAllItems(IEnumerable<Monkey> monkeys)
        {
            while (Items.Any())
            {
                ThrowItem(monkeys);
            }
        }

        public void ThrowItem(IEnumerable<Monkey> monkeys)
        {
            var target = monkeys.FirstOrDefault(x => x.Number == GetTargetMonkey());
            target.Items.Enqueue(GetNextItem());
            Throws++;
        }

        public long GetTargetMonkey()
        {
            return Test(NewWorryvalue(Items.Peek()));
        }

        public long GetNextItem()
        {
            return NewWorryvalue(Items.Dequeue());
        }

        public long NewWorryvalue(long item)
        {
            return Operation.Invoke(item) / WorryFactor % GetFactor();
        }

        public long GetFactor()
        {
            return Factors.Aggregate(1, (a, b) => a * b);
        }

        #endregion
    }
}
