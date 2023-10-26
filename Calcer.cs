using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    internal class Calcer
    {
        private Stack<double> numbers = new Stack<double>();
        private Stack<char> operators = new Stack<char>();

        private Dictionary<char, int> priority = new Dictionary<char, int>()
        {
            {'(','0'},
            {'+','1'},
            {'-','1'},
            {'*','2'},
            {'/','2'},
            {'~','3'},
        };

        private double GetNumberFromString(string str, ref int ind)
        {
            string num = "";

            while (ind < str.Length)
            {
                char c = str[ind];
                if (Char.IsDigit(c) || c == ',')
                {
                    num += c;
                    ind++;
                }
                else
                {
                    ind--;
                    break;
                }
            }
            return Double.Parse(num);
        }

        private double evaluate(double b, double a, char oper)
        {
            switch (oper)
            {
                case '+': return a + b;
                case '-': return a - b;
                case '*': return a * b;
                case '/': return a / b;
                default:  throw new Exception("Ты дебил блять, ты как сломал то что нельзя сломать ебанько");
            }
        }

        public string SolveExpression(string expression)
        {
            for (int pos = 0; pos < expression.Length; pos++)
            {
                char c = expression[pos];
                if (Char.IsDigit(c))
                {
                    numbers.Push(GetNumberFromString(expression, ref pos));
                }
                else if (c == '(')
                {
                    operators.Push('(');
                }
                else if (c == ')')
                {
                    while (operators.Peek() != '(')
                    {
                        if (priority[operators.Peek()] == '~')
                        {
                            numbers.Push(-numbers.Pop());
                        }
                        else
                        {
                            numbers.Push(evaluate(numbers.Pop(), numbers.Pop(), operators.Pop()));
                        }
                    }
                    operators.Pop();
                }
                else if (c == '-' && (pos == 0 || expression[pos-1] == '('))
                {
                    operators.Push('~');
                }
                else 
                {
                    while (operators.Count > 0 && priority[operators.Peek()] > priority[c])
                    {
                        if (operators.Peek() == '~')
                        {
                            numbers.Push(-numbers.Pop());
                            operators.Pop();
                        }
                        else
                        {
                           numbers.Push(evaluate(numbers.Pop(), numbers.Pop(), operators.Pop()));
                        }
                       
                    }
                    operators.Push(c);
                }

            }

            while (operators.Count > 0)
            {
                if (priority[operators.Peek()] == '~')
                {
                    numbers.Push(-numbers.Pop());
                }
                else
                {
                    numbers.Push(evaluate(numbers.Pop(), numbers.Pop(), operators.Pop()));
                }
            }

            return numbers.Pop().ToString();
        }

        public double test()
        {
            double k = 0;
            return 1.0 / k;
        }
    }
}
