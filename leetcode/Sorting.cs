using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode
{
    public class Sorting
    {
        // Merge sort space complexity = O(n)  [because we making subarrays/lists]
        // Time complexity is O(nlogn)
        public static int[] MergeSort(int[] nums)
        {
            if (nums.Length == 1)
                return nums;

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (i % 2 == 0)
                    left.Add(nums[i]);
                else
                    right.Add(nums[i]);
            }

            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();

            return PerformMerge(left, right);
        }

        // Merge the subarray
        public static int[] PerformMerge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while (left.Count > 0 && right.Count > 0)
            {

                if (left.First() <= right.First())
                {
                    result.Add(left.First());
                    left.RemoveAt(0);
                }
                else
                {
                    result.Add(right.First());
                    right.RemoveAt(0);
                }
            }


            while (left.Count > 0)
            {
                result.Add(left.First());
                left.RemoveAt(0);
            }

            while (right.Count > 0)
            {
                result.Add(right.First());
                right.RemoveAt(0);
            }

            return result.ToArray();
        }

        public static int[] SortArray(int[] nums)
        {
            return MergeSort(nums);
        }
    }
}
