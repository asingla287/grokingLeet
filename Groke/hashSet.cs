using System;
using System.Collections.Generic;
using System.Text;

public partial class Solution
{

    public int countElements(int[] arr)
    {
        int count = 0;
        HashSet<int> test = new HashSet<int>(arr);

        foreach (int x in test)
        {
            if (test.Contains(x + 1))
            {
                count += arr.Count(v => v == x);
            }
        }

        return count;
    }
    /// <summary>
    // Input: "abcdabef"
    // Expected Output: 6
    // Justification: The longest segment with distinct
    // characters is "bcdaef", which has a length of 6.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int lengthOfLongestSubstring(string s)
    {
        HashSet<char> set = new HashSet<char>();
        int maxLength = 0, start = 0, end = 0;

        while (end < s.Length)
        {
            if (!set.Contains(s[end]))
            {
                set.Add(s[end]);
                maxLength = Math.Max(maxLength, end - start + 1);
                end ++;
            }
            else{
                set.Remove(s[start]);
                start++;
            }
        }

        return maxLength;
    }
}