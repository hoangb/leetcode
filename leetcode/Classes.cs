using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }

    }

    public class LRUCache
    {
        LinkedList<int> cache;
        int size;
        int capacity;
        Dictionary<int, int> map;
        public LRUCache(int capacity)
        {
            this.capacity = capacity;
            size = 0;
            cache = new LinkedList<int>();
            map = new Dictionary<int, int>();
        }

        public int Get(int key)
        {
            if (map.ContainsKey(key))
            {
                cache.Remove(key);
                cache.AddLast(map[key]);
                return map[key];
            }

            return -1;
        }

        public void Put(int key, int value)
        {
            if (size >= capacity)
            {
                size--;
                var first = cache.First;
                cache.Remove(first);
                map.Remove(first.Value);
            }

            if (map.ContainsKey(key))
            {
                cache.Remove(key);
                cache.AddLast(value);
            }
            else
            {
                map.Add(key, value);
                cache.AddLast(value);
                size++;
            }
        }
    }

}
