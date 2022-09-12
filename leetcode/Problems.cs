using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    internal class Problems
    {
        static int MOD = 1000000007;

        // Brute force - https://leetcode.com/problems/sum-of-total-strength-of-wizards/
        public static int TotalStrength(int[] strength)
        {
            long result = 0;
            int window = 0;

            while (window < strength.Length)
            {
                for (int i = window; i < strength.Length; i++)
                {
                    long sum = 0;
                    int min = Int32.MaxValue;
                    int index = window;

                    while (i - index >= 0)
                    {
                        min = Math.Min(min, strength[i - index]);
                        sum = (sum + strength[i - index]) % MOD;
                        index--;
                        if (index < 0)
                            break;
                    }
                    result += (min * sum);

                }
                window++;
            }


            return (int)(result % MOD);
        }


        public static int MinCostRope(int[] arr)
        {
            int cost = 0;

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < arr.Length; i++)
                pq.Enqueue(arr[i], arr[i]);

            while (pq.Count > 1)
            {
                int val1 = pq.Dequeue();
                int val2 = 0;

                if (pq.Count != 0)
                    val2 = pq.Dequeue();

                int currentCost = (val1 + val2);
                cost += currentCost;
                pq.Enqueue(currentCost, currentCost);
            }

            return cost;
        }
    }
}
