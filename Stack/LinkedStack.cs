using System.Text;


namespace Data_Structure.Stack
{
    public class Node<T>
    {
        public T Item { get; set; }
        public Node<T> Next { get; set; }

        public Node(T item)
        {
            Item = item;
        }
    }
    public class LinkedStack<T>
    {
        private Node<T> top;

        public void Push(T item)
        {
            Node<T> newNode = new(item);
            newNode.Next = top;
            top = newNode;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            Node<T> stackTop = top;
            top = top.Next;
            stackTop.Next = null; // Dereference the node
            return stackTop.Item;
        }

        public bool IsEmpty()
        {
            return top == null; 
        }
        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");

            return top.Item;
        }

        public override string ToString()
        {
            var result = new StringBuilder("[");
            Node<T> stackTop = top;
            while (stackTop != null)
            {
                result.Append(stackTop.Item);
                if (stackTop.Next != null)
                    result.Append(", ");

                stackTop = stackTop.Next;
            }
            result.Append("]");
            return result.ToString();
        }

        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }
}
