using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {

// you can also use other imports, for example:
// using System.Collections.Generic;

// you can use Console.WriteLine for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

        public int solution(int[] A)
        {
            // write your code in C# 5.0 with .NET 4.5 (Mono)
            List<int> list = new List<int>();
            int pointer = A[0];
            while (!list.Contains(A[pointer] + pointer))
            {
                list.Add(pointer);
                pointer = A[pointer] + pointer;
            }

            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i) == A[pointer] + pointer)
                {
                    return list.Count - i;
                }
            }

            return -1;
        }
    }
}
