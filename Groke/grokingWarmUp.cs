using System;
using System.Collections.Generic;

public partial class Solution {

  public bool containsDuplicate(int[] nums) {
    var set = new HashSet<int>(nums);
    return set.Count != nums.Length;
  }
  // Function to check if given sentence is pangram
  public bool checkIfPangram(string sentence) {
    var set = new HashSet<char>();
    foreach(char c in sentence[..' '].ToLower()){
        if(!set.Add(c)){

        }
    }
    // ToDo: Write Your Code Here.
    return true;
  }
}
