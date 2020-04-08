using System;
using System.Collections.Generic;
using System.Linq;

namespace Algos{
    public class PriorityQueue<TK, TV>
        {
            private readonly SortedDictionary<TK, Queue<TV>> q;

            public PriorityQueue()
            {
                this.q = new SortedDictionary<TK, Queue<TV>>();
            }

            public PriorityQueue(IComparer<TK> comparer)
            {
                this.q = new SortedDictionary<TK, Queue<TV>>(comparer);
            }

            public int Count()
            {
                return q.Count;
            }

            public bool IsEmpty()
            {
                return q.Count == 0;
            }

            public void Enqueue(TK key, TV val)
            {
                if (!q.ContainsKey(key))
                {
                    q[key] = new Queue<TV>();
                }

                q[key].Enqueue(val);
            }

            public KeyValuePair<TK, TV> Dequeue()
            {
                if (this.IsEmpty())
                    throw new Exception("Queue is empty!");

                var top = q.First();
                KeyValuePair<TK, TV> result = new KeyValuePair<TK, TV>(top.Key, top.Value.Dequeue());

                if (top.Value.Count == 0)
                {
                    q.Remove(top.Key);
                }

                return result;
            }
        }
}