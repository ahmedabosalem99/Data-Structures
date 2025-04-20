//This implementation is based on our previous implemetation for the stack not the standard .NET Stack

namespace Data_Structure.Stack
{
    public static class BalancedParentheses
    {
        public static bool CheckBalance(string expression)
        {
            Stack<char> stack = new Stack<char>();

            foreach(char c in  expression)
            {
               switch(c)
                {
                    case '(':
                    case '{':
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                    case '}':
                    case ']':
                        if(stack.IsEmpty()  || !AreValidPair(stack.Pop(), c))
                            return false;
                        break;
                }
            }
            return stack.IsEmpty();
        }

        private static bool AreValidPair(char left, char right)
        {
            return (left == '(' && right == ')')
                || (left == '{' && right == '}')
                || (left == '[' && right == ']');
        }
    }
}
