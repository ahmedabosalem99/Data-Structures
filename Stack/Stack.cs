namespace Data_Structure
{
    public static class Constants
    {
        public const int MAX_SIZE = 100;
    }
    public class Stack
    {
        int top;
        int[] item;

        public Stack()
        {
            item = new int[Constants.MAX_SIZE];
            top = -1;
        }

        public bool isEmpty() => top < 0;

        public bool isFull() => top >= Constants.MAX_SIZE - 1;

        public void Push(int element)
        {
            if (isFull())
                Console.WriteLine("Stack is Full");
            else
                item[++top] = element;
        }

        public void Pop()
        {
            if (isEmpty())
                Console.WriteLine("Stack is Empty");
            else
                top--;
        }

        public void Pop(ref int element)
        {
            if (isEmpty())
                Console.WriteLine("Stack is Empty");
            else
                element = item[top--];
        }

        public void Top(ref int stackTop)
        {
            if (isEmpty())
                Console.WriteLine("Stack is Empty");
            else
                stackTop = item[top];
        }

        public override string ToString()
        {
            return string.Join(" ", item[0..(top + 1)].Reverse());
        }
        public void Print()
        {
            Console.WriteLine($"[{ToString()}]");
        }
    }
}
