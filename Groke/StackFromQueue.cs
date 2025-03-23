
class SolutionT {
    // Constructor to initialize the queues
    Queue<int> q1;
    Queue<int> q2;
    public SolutionT() {
        q1 = new Queue<int>();
        q2 = new Queue<int>();
       // ToDo: Write Your Code Here.
    }

    // Push element x onto the stack
    public void push(int x) {
        q1.Enqueue(x);
       // ToDo: Write Your Code Here.
    }

    // Pop element from the stack
    public int pop() {
        if(q1.Count == 0){
            throw new InvalidOperationException();
        }
        while(q1.Count > 1){
            q2.Enqueue(q1.Dequeue());

        }
            var x = q1.Dequeue();
        while(q2.Count > 0){
            q1.Enqueue(q2.Dequeue());
        }
            return x;
    }

    // Get the top element
    public int top() {
        if(q1.Count == 0){
            throw new InvalidOperationException();
        }
        while(q1.Count > 1){
            q2.Enqueue(q1.Dequeue());

        }
            var x = q1.Peek();
            q2.Enqueue(q1.Dequeue());
        while(q2.Count > 0){
            q1.Enqueue(q2.Dequeue());
        }
            return x;
    }

    // Check if the stack is empty
    public bool empty() {
       // ToDo: Write Your Code Here.
       return q1.Count == 0;
    }
}
