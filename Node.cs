using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPuzzle
{
    public class Node : IComparable<Node>
    {
        public int _k;
        public List<int> a;
        public List<int> b;

        public Node() { }

        public Node(List<int> a, List<int> b, int _k) 
        { 

        }

        public bool IsSovled()
        {
            return SumTest() == 0 && SumPowerTest() == 0;
        }
        private int SumTest()
        {
            Console.WriteLine("SumTest: {0} == {1}", a.Sum(), b.Sum());
            return (int)Math.Abs(a.Sum() - b.Sum());
        }
        private int SumPowerTest()
        {
            List<int> a2 = new List<int>();
            List<int> b2 = new List<int>();

            foreach (int n in a)
                a2.Add((int)Math.Pow(n, _k));

            foreach (int n in b)
                b2.Add((int)Math.Pow(n, _k));

            Console.WriteLine("SumPowerTest: {0} == {1}", a2.Sum(), b2.Sum());
            return (int)Math.Abs(a2.Sum() - b2.Sum());
        }

        public int Heuristic()
        {
            //return _k;
            return SumTest() + SumPowerTest();
        }

        public void PrintArrays()
        {
            Console.WriteLine(String.Join(", ", a.ToArray()));
            Console.WriteLine(String.Join(", ", b.ToArray()));
        }
        public int CompareTo(Node node)
        {
            int result = 0;

            if (this.Heuristic() > node.Heuristic())
            {
                result = 1;
            }
            else if (this.Heuristic() < node.Heuristic())
            {
                result = -1;
            }
            
            return result;
        }
    }
}

