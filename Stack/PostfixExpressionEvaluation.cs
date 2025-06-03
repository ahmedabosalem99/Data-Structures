using System.Data;

namespace Data_Structure.Stack
{
    public static class PostfixExpressionEvaluation
    {
        public static int Evaluate(string expression)
        {
            if(string.IsNullOrEmpty(expression))
                throw new ArgumentException("Expression cannot be null or empty");

            char[] buff = new char[11];
            Stack<int> stack = new Stack<int>();
            int buffIdx = 0, op1, op2;

            foreach(char x in expression)
            {
                if(char.IsDigit(x))
                {
                    if (buffIdx >= buff.Length)
                        throw new OverflowException("Number is too large");

                    buff[buffIdx++] = x;
                }
                else if (x == ' ')
                {
                    if(buffIdx > 0)
                    {
                        buff[buffIdx] = '\0';
                        int number = int.Parse(buff);
                        stack.Push(number);
                        buffIdx = 0;
                    }
                }
                else if (IsOperator(x))
                {
                    if (stack.Count() < 2)
                        throw new InvalidOperationException("Insufficient operands for operator");

                    op1 = stack.Pop();
                    op2 = stack.Pop();
                    stack.Push(PerformOperation(op1, op2, x));
                }
                else
                {
                    throw new ArgumentException($"Invalid character '{x}' in expression");
                }

            }

            if (stack.Count() != 1)
                throw new InvalidOperationException("Expression is malformed - too many operands");

            return stack.Peek();
        }
        private static bool IsOperator(char op)
        {
            return (op == '+' || op == '-' || op == '*' || op == '/');
        }

        private static int PerformOperation(int op1, int op2, char operat)
        {
            try
            {
                return operat switch
                {
                    '+' => op2 + op1,
                    '-' => op2 - op1,
                    '*' => op2 * op1,
                    '/' => op2 / op1,
                    _ => throw new ArgumentException($"Unknown operator '{operat}'")
                };
            }
            catch (DivideByZeroException)
            {
                throw new DivideByZeroException("Division by zero in expression");
            }
        }
    }
}
