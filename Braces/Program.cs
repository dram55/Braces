using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Braces
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tests = new List<string> { "[()]", "(({{[[]]}}))", "({})[({})]", "(})", "())({}}{()][][", "[(])" };

            foreach (var test in tests)
            {
                bool result = validBraces(test);
                Console.WriteLine("{0} - {1}", test, result);
            }
            Console.Read();
        }

        /// <summary>
        /// Solution for codewars http://www.codewars.com/kata/valid-braces/train/csharp
        /// </summary>
        /// <param name="braces"></param>
        /// <returns></returns>
        public static bool validBraces(String braces)
        {
            Stack<char> workingBraces = new Stack<char>();

            for (int i = 0; i < braces.Length; i++)
            {
                // If the stack is empty - push the next brace and continue
                if (workingBraces.Count == 0)
                {
                    workingBraces.Push(braces[i]);
                }

                else
                {
                    bool isMatch = isClosingBraceFor(workingBraces.Peek(), braces[i]);
                    if (isMatch)
                    {
                        workingBraces.Pop();
                    }
                    else
                    {
                        workingBraces.Push(braces[i]);
                    }
                }
            }

            // If the stack is empty then braces are valid
            if (workingBraces.Count == 0) return true;
            else return false;
        }

        private static bool isClosingBraceFor(char open, char close)
        {
            if (open == '[' && close == ']') return true;
            if (open == '{' && close == '}') return true;
            if (open == '(' && close == ')') return true;
            return false;
        }
    }
}
