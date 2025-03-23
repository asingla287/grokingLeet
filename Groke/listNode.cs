public class ListNode {
    public int Val;
    public ListNode Next;
    public ListNode(int x) { Val = x; }
    public ListNode(int val, ListNode next) { this.Val = val; this.Next = next; }
}
public class DLNode {
    public int Val;
    public DLNode Next, Prev;
    public DLNode(int val) { this.Val = val; }
}