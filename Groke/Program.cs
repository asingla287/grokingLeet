using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// 
/// </summary>
public partial class Solution
{
    public int maxNumberOfBalloons(string text)
    {
        var freq = new Dictionary<char, int>();
        foreach (char c in text)
        {
            if (!freq.TryAdd(c, 1))
            {
                freq[c] += 1;
            }
        }
        int minCount = 0;
        // Calculate the maximum number of times "balloon" can be formed
        minCount = Math.Min(minCount, freq.GetValueOrDefault('b', 0));
        minCount = Math.Min(minCount, freq.GetValueOrDefault('a', 0));
        minCount = Math.Min(minCount, freq.GetValueOrDefault('l', 0) / 2);
        minCount = Math.Min(minCount, freq.GetValueOrDefault('o', 0) / 2);
        minCount = Math.Min(minCount, freq.GetValueOrDefault('n', 0));
        // ToDo: Write Your Code Here.
        return minCount;
    }
    public TreeNode mergeTrees(TreeNode t1, TreeNode t2)
    {
        if (t1 == null) return t2;
        if (t2 == null) return t1;

        t1.Val += t2.Val;

        t1.Left = mergeTrees(t1.Left, t2.Left);

        t1.Right = mergeTrees(t1.Right, t2.Right);


        return t1;
    }

    /// <summary>
    /// 
    /// </summary>
    int leftClosest = int.MinValue;
    int rightClosest = int.MaxValue;

    public void traverseToSetClosestToTarget(TreeNode root, double target)
    {
        if (root == null)
        {
            return;
        }
        if (root.Val >= target)
        {
            if (root.Val <= rightClosest)
                rightClosest = root.Val;
            traverseToSetClosestToTarget(root.Left, target);
        }
        if (root.Val <= target)
        {
            if (root.Val >= leftClosest)
                leftClosest = root.Val;
            traverseToSetClosestToTarget(root.Right, target);
        }
    }


    // This function finds the value in the BST closest to the target.
    public int closestValue(TreeNode root, double target)
    {
        traverseToSetClosestToTarget(root, target);

        // Once we've traversed all possible paths, return the closest value.
        if (Math.Abs(target - leftClosest) <= Math.Abs(target - rightClosest))
        {
            return leftClosest;
        }
        return rightClosest;
    }
    /// <summary>
    /// /////////////////////
    /// </summary>
    public int kth = int.MinValue;
    public int current = 0;
    public void InOrderTraversalTillK(TreeNode node, int k)
    {
        if (node == null || current >= k)
        {
            return;
        }
        Console.WriteLine($"k: {k}, current: {current}, val: {node.Val}");
        InOrderTraversalTillK(node.Left, k);
        current++;
        if (current == k)
        {
            kth = node.Val;
        }
        InOrderTraversalTillK(node.Right, k);
    }
    public int kthSmallest(TreeNode root, int k)
    {
        // ToDo: Write Your Code Here.
        InOrderTraversalTillK(root, k);
        return kth;
    }
    public int rangeSumBST(TreeNode root, int L, int R)
    {

        if (root == null) return 0;  // Base case

        // If the current node's value is out of the range on the higher side
        if (root.Val > R) return rangeSumBST(root.Left, L, R);

        // If the current node's value is out of the range on the lower side
        if (root.Val < L) return rangeSumBST(root.Right, L, R);

        // Current node's value is in the range, include it and check both children
        return root.Val + rangeSumBST(root.Left, L, R) + rangeSumBST(root.Right, L, R);

        //o<n>
        nodes.Clear();
        InOrderTraversal(root);

        return nodes.Where(x => x >= L && x <= R).Sum();
    }
    public static List<int> nodes = new List<int>();

    public static void InOrderTraversal(TreeNode node)
    {
        if (node == null)
        {
            return;
        }
        InOrderTraversal(node.Left);
        nodes.Add(node.Val);
        InOrderTraversal(node.Right);
    }
    public int minDiffInBST(TreeNode root)
    {
        int minDiff = int.MaxValue;
        nodes.Clear();
        InOrderTraversal(root);
        var vals = nodes;
        for (int i = 1; i < vals.Count; i++)
        {
            minDiff = Math.Min(minDiff, vals[i] - vals[i - 1]);
        }


        return minDiff;
    }
    // Helper function to get the depth of the tree from a given node
    public int depth(TreeNode node)
    {
        if (node == null) return 0;

        Console.WriteLine($"going left for val: {node.Val}");
        int leftDepth = depth(node.Left);
        Console.WriteLine($"left depth for val: {node.Val} -- {leftDepth}");
        // If the left subtree is unbalanced, we return -1 to indicate it's not balanced
        if (leftDepth == -1)
        {
            return -1;
        }

        Console.WriteLine($"going right for val: {node.Val}");
        int rightDepth = depth(node.Right);
        Console.WriteLine($"right depth for val: {node.Val} -- {rightDepth}");
        // If the rightt subtree is unbalanced, we return -1 to indicate it's not balanced
        if (rightDepth == -1)
        {
            return -1;
        }

        // If current node is unbalanced, return -1 to indicate it's not balanced
        if (Math.Abs(leftDepth - rightDepth) > 1)
        {
            Console.WriteLine($"unalanced for val: {node.Val} ");
            return -1;
        }

        // If it's balanced, we return the depth of the current subtree
        return Math.Max(leftDepth, rightDepth) + 1;
    }
    public bool isBalanced(TreeNode root)
    {
        return depth(root) != -1;
    }

    // Method to compute the maximum depth of a binary tree
    public int maxDepth(TreeNode root)
    {
        // Base case: if node is null, return 0
        if (root == null) return 0;

        // Recursively calculate left subtree depth
        int leftDepth = maxDepth(root.Left);

        // Recursively calculate right subtree depth
        int rightDepth = maxDepth(root.Right);

        // Return the maximum of left and right subtree depth plus 1 for the current node
        return Math.Max(leftDepth, rightDepth) + 1;
    }
    // // Method to compute the maximum depth of a binary tree
    // static int maxDepthChild(int val, TreeNode root)
    // {
    //     Console.WriteLine($"val: {val}, root: {root.Val}");
    //     val++;
    //     if (root.Left != null)
    //     {
    //         Console.WriteLine($"going left with val: {val}, root: {root.Left.Val}");
    //         return maxDepthChild(val, root.Left);
    //     }
    //     if (root.Right != null)
    //     {
    //         Console.WriteLine($"going right with val: {val}, root: {root.Right.Val}");
    //         return maxDepthChild(val, root.Right);
    //     }
    //    return val;
    // }
    // public int maxDepth(TreeNode root)
    // {
    //     int maxLeft = 0;
    //     int maxRight = 0;
    //     if (root == null)
    //     {
    //         return 0;
    //     }
    //     if (root.Left != null)
    //     {
    //         maxLeft = maxDepthChild(0, root.Left);
    //         Console.WriteLine($"maxLeft: {maxLeft}");
    //     }
    //     if (root.Right != null)
    //     {
    //         maxRight = maxDepthChild(0, root.Right);
    //         Console.WriteLine($"maxLeft: {maxRight}");
    //     }
    //     return maxLeft > maxRight ? maxLeft : maxRight;
    // }
    public ListNode swapPairs(ListNode head)
    {

        ListNode dummy = new ListNode(0);
        dummy.Next = head;
        // Previous node to maintain the node previous to the current pair being swapped.
        ListNode previous = dummy;
        ListNode current = head;

        while (current != null && current.Next != null)
        {
            var firstNode = current; //1 , 3
            var secondNode = current.Next; //2 , 4

            firstNode.Next = secondNode.Next; // 1-> 3, 3-> null
            secondNode.Next = firstNode; // 2 -> 1, 4 -> 3
            previous.Next = secondNode; // 0 -> 2, 2 => 4

            current = firstNode.Next; // 3, null
            previous = firstNode; // 1 , 3

        }
        // TODO: Write your code here
        return dummy.Next;
    }
    public bool isPalindrome(DLNode head)
    {
        if (head == null || head.Next == null) return true;

        var current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        var start = head;
        var end = current;
        while (start != end && start.Prev != end)
        {
            if (start.Val != end.Val)
            {
                return false;
            }
            start = start.Next;
            end = end.Prev;
        }
        return true;
    }
    public ListNode mergeTwoLists(ListNode l1, ListNode l2)
    {
        // ListNode head = l1.Val > l2.Val ? l2 : l1;
        ListNode dummy = new ListNode(-1);
        ListNode current = dummy;
        while (l1 != null && l2 != null)
        {
            if (l1.Val < l2.Val)
            {
                current.Next = l1;
                l1 = l1.Next;
            }
            else
            {
                current.Next = l2;
                l2 = l2.Next;
            }
            current = current.Next;
        }
        if (l1 != null) current.Next = l1;
        else current.Next = l2;
        return dummy.Next;
    }
    public ListNode deleteDuplicates(ListNode head)
    {
        // TODO: Write your code here
        ListNode current = head;
        while (current != null && current.Next != null)
        {
            var temp = current.Next;
            if (current.Val == temp.Val)
            {
                if (temp.Next != null)
                {
                    current.Next = temp.Next;
                }
                else
                {
                    current.Next = null;
                }
            }
            else
            {
                current = temp;
            }
        }
        return head;
    }
    public ListNode reverseList(ListNode head)
    {
        // TODO: Write your code here
        ListNode prev = null;
        ListNode current = head;
        while (current != null)
        {
            var temp = current.Next;
            current.Next = prev;
            prev = current;
            current = temp;
        }
        return prev;
    }
    public Queue<int> reverseQueue(Queue<int> queue)
    {
        var n = queue.Reverse().ToList();
        var ans = new Queue<int>();

        foreach (int x in n)
        {
            ans.Enqueue(x);
        }
        return ans;
    }
    public string makeGood(string s)
    {
        // Create a stack to store the components of the path
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (stack.Count == 0)
            {
                stack.Push(c);
                continue;
            }
            if (stack.Peek() != c)
            {
                var isPeekEqual = stack.Peek().ToString().Equals(c.ToString(),
                                 StringComparison.InvariantCultureIgnoreCase);
                if (isPeekEqual)
                {
                    stack.Pop();
                    continue;
                }
            }
            stack.Push(c);
        }
        var result = stack.ToArray();
        Array.Reverse(result);
        return new string(result);
    }
    public string removeStars(string s)
    {
        // Create a stack to store the components of the path
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (stack.Count == 0 || c != '*')
            {
                stack.Push(c);
            }
            if (c == '*' && stack.Count != 0)
            {
                stack.Pop();
            }
        }
        var result = stack.ToArray();
        Array.Reverse(result);
        return new string(result);
    }
    public string removeDuplicates(string s)
    {
        // Create a stack to store the components of the path
        Stack<char> stack = new Stack<char>();
        foreach (char c in s)
        {
            if (stack.Count == 0 && stack.Peek() != c)
            {
                stack.Push(c);
            }
            if (stack.Peek() == c)
            {
                stack.Pop();
            }
        }
        var result = stack.ToArray();
        Array.Reverse(result);
        return new string(result);
    }
    public string simplifyPath(string path)
    {
        // Create a stack to store the components of the path
        Stack<string> stack = new Stack<string>();

        // Split the input path string by '/' and iterate through the resulting array
        foreach (var p in path.Split('/'))
        {
            if (p == "..")
            {
                // If the component is '..', and the stack isn't empty, pop the last component
                if (stack.Count > 0)
                {
                    stack.Pop();
                }
            }
            else if (!string.IsNullOrEmpty(p) && p != ".")
            {
                // If the component is not empty or '.', add it to the stack
                stack.Push(p);
            }
        }

        // Convert the stack to an array and reverse it to get the correct order
        var result = stack.ToArray();
        Array.Reverse(result);

        // Join the array elements with '/' to form the simplified path
        // and ensure it starts with '/'
        return $"/{String.Join("/", result)}";
    }
    public Stack<int> sortStack(Stack<int> input)
    {
        Stack<int> tmpStack = new Stack<int>();
        while (input.Count > 0)
        {
            int number = input.Pop();
            while (tmpStack.Count > 0 && tmpStack.Peek() > number)
            {
                input.Push(tmpStack.Pop());
            }
            tmpStack.Push(number);
        }
        return tmpStack;
    }

    public List<int> nextLargerElement2(List<int> arr)
    {
        int n = arr.Count;
        Stack<int> s = new Stack<int>();
        List<int> res = new List<int>(n);

        // Traverse the list in reverse order
        for (int i = n - 1; i >= 0; i--)
        {
            // Pop elements from the stack while they are smaller than or equal to the current element
            while (s.Count > 0 && s.Peek() <= arr[i])
            {
                s.Pop();
            }

            // If the stack is empty, there is no greater element on the right, so assign -1
            // Otherwise, assign the top element of the stack as the NGE for the current element
            res.Insert(0, s.Count == 0 ? -1 : s.Peek());

            // Push the current element onto the stack
            s.Push(arr[i]);
        }

        return res;
    }
    public List<int> nextLargerElement(List<int> arr)
    {
        List<int> res = new List<int>();
        for (int i1 = 0; i1 < arr.Count; i1++)
        {
            if (arr.Where((x, idx) => x > arr[i1] && idx > i1).Any())
            {
                res.Add(arr.Where((x, idx) => x > arr[i1] && idx > i1).First());
            }
            else
            {
                res.Add(-1);
            }
        }
        // ToDo: Write Your Code Here.
        return res;
    }
    public string decimalToBinary(int num)
    {
        StringBuilder sb = new StringBuilder();
        // 018/2 = 0, 9/2=1, 8/2 = 0, 4/2= 0, 2/2 = 0
        // ToDo: Write Your Code Here.
        return sb.ToString();
    }
    public string reverseString(string s)
    {
        var length = s.Length;
        var myStack = new Stack<char>(s.Length);
        foreach (char c in s)
        {
            myStack.Push(c);
        }
        s = string.Empty;
        for (int i = 0; i < length; i++)
        {
            s += myStack.Pop();
        }

        return s;
    }
    public bool isValid(string s)
    {
        var myStack = new Stack<char>(s.Length);
        var openingP = new[] { '{', '(', '[' };
        var closingP = new[] { '}', ')', ']' };
        foreach (char c in s)
        {
            if (openingP.Contains(c))
            {
                myStack.Push(c);
            }
            if (myStack.Count == 0)
            {
                return false;
            }
            if (closingP.Contains(c))
            {
                var typeC = Array.FindIndex(closingP, row => row == c);
                var typeO = Array.FindIndex(openingP, row => row == myStack.Peek());
                if (typeC != typeO)
                {
                    return false;
                }
                myStack.Pop();
            }
        }
        return myStack.Count == 0;
    }
    public int[] findMaxOnesRow(int[][] mat)
    {
        int MaxOnesIdx = 0;
        int MaxOnesCount = 0;
        for (int i = 0; i < mat.Length; i++)
        {
            int count = mat[i].Count((x) => x == 1);
            if (count > MaxOnesCount)
            {
                MaxOnesIdx = i;
                MaxOnesCount = count;
            }
        }
        return new int[] { MaxOnesIdx, MaxOnesCount };
    }
    public int diagonalSum(int[][] mat)
    {
        int totalSum = 0;  // Initialize the total sum
        int length = mat.Length - 1;
        for (int i = 0; i <= length; i++)
        {
            totalSum += mat[i][i] + (i == length - i ? 0 : mat[i][length - i]);
        }
        return totalSum;
    }
    public int maximumWealth(int[][] accounts)
    {
        int maxWealth = 0;  // Initialize maxWealth to 0
        foreach (int[] money in accounts)
        {
            int totalMoney = money.Sum();
            if (totalMoney > maxWealth)
            {
                maxWealth = totalMoney;
            }
        }
        return maxWealth;
    }
    public int largestAltitude(int[] gain)
    {
        int maxAltitude = 0; // To store the maximum altitude encountered
        for (int i = 0; i < gain.Length; i++)
        {
            if (i == 0)
            {
                gain[i] = gain[i];
                if (gain[i] > 0)
                {
                    maxAltitude = gain[i];
                }
            }
            else
            {
                gain[i] = gain[i - 1] + gain[i];
                if (maxAltitude < gain[i])
                {
                    maxAltitude = gain[i];
                }
            }
        }
        return maxAltitude;
    }
}

