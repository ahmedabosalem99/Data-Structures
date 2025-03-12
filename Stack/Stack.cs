using System;
using System.Text;

namespace Data_Structure
{
    public static class Constants
    {
        // Theoretical maximum size of an array in .NET
        public const int MAX_SIZE = int.MaxValue - 56;
    }

    public class Stack<T>
    {
        private int top;
        private readonly T[] item;

        public Stack(int maxSize = Constants.MAX_SIZE)
        {
            if (maxSize <= 0)
                throw new ArgumentException("Size must be greater than 0.");
            if (maxSize > Constants.MAX_SIZE)
                throw new ArgumentException($"Size exceeds the maximum allowed array size of {Constants.MAX_SIZE}.");

            item = new T[maxSize];
            top = -1;
        }

        public bool IsEmpty() => top < 0;

        public bool IsFull() => top >= item.Length - 1;

        public void Push(T element)
        {
            if (IsFull())
                throw new InvalidOperationException("Stack is full.");
            item[++top] = element;
        }

        public T Pop()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return item[top--];
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Stack is empty.");
            return item[top];
        }

        public override string ToString()
        {
            if (IsEmpty())
                return "[]";

            var result = new StringBuilder("[");
            for (int i = top; i >= 0; i--)
            {
                result.Append(item[i]);
                if (i > 0)
                    result.Append(", ");
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
