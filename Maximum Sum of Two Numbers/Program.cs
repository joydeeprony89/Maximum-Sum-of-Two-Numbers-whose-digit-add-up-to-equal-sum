using System;
using System.Collections.Generic;
using System.Linq;

namespace Maximum_Sum_of_Two_Numbers
{
//  Write a function given array A consisting of N integers, returns the maximum sum of two numbers whose digits add up to an equal sum.If there are no two numbers whose digits have an equal sum, the function should return -1.

//Examples:

//Given A =[51, 71, 17, 42], the function should return 93. There are two pairs of numbers whose digits add up to an equal sum: (51,42) and(17,71). The first pairs sums up to 93.
//Given A =[42, 33, 60], the function shpuld return 102. The digits of all numbers in A add up to the same sum, and choosing to add 42 and 60 gives the result 102.
//Given A =[51, 32, 43], the function should return -1, since all numbers in A have digits that add up to different, unique sums
  class Program
  {
    static void Main(string[] args)
    {
      Program p = new Program();
      int[] A = new int[] { 51, 71, 17, 42, 33 , 60 }; // 51, 71, 17, 42  // 42, 33, 60 // 51, 32, 43
      Console.WriteLine(p.MaximumSum(A));
    }

    public int digit_sum(int n)
    {
      int sum = 0;
      while (n >= 10)
      {
        sum += n % 10;
        n = n / 10;
      }
      sum += n;
      return sum;
    }
    public int MaximumSum(int[] A)
    {
      // write your code here
      Dictionary<int, List<int>> hash = new Dictionary<int, List<int>>();
      int sum = -1;

      for (int i = 0; i < A.Length; i++)
      {
        int temp = digit_sum(A[i]);
        if (hash.ContainsKey(temp))
        {
          hash[temp].Add(A[i]);
        }
        else
        {
          List<int> nums = new List<int>();
          nums.Add(A[i]);
          hash[temp] = nums;
        }
      }

      foreach (int key in hash.Keys)
      {
        if (hash[key].Count < 2) continue;
        var ss = hash[key].OrderBy(x => x).ToList();
        List<int> num = new List<int>(ss);
        int n = num.Count;
        sum = Math.Max(sum, num[n - 1] + num[n - 2]);
      }
      return sum;
    }
  }
}
