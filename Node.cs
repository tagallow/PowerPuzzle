using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPuzzle
{
    public class Node : IComparable<Node>, IEquatable<Node>
    {
        public int _k;
        public List<int> a;
        public List<int> b;
        private Node _Parent;

        public Node() { }
        public Node(Node parent) 
        {
            _Parent = parent;
            _k = parent._k;
            a = new List<int>(parent.a);
            b = new List<int>(parent.b);

        }
        private List<int> GetUnusedNumbers()
        {
            int _n = (int)Math.Pow(2, _k + 1);
            List<int> result = new List<int>();
            for (int i = 0; i < _n; i++)
            {
                if(!a.Contains(i) && !b.Contains(i))
                {
                    result.Add(i);
                }
            }
            return result;
        }
        /// <summary>
        /// Returns all valid states that can be reached from this node.
        /// </summary>
        /// <returns></returns>
        public List<Node> GetChildren()
        {
            int _n = (int)Math.Pow(2, _k + 1);
            List<int> UnusedNumbers = GetUnusedNumbers();
            List<Node> children = new List<Node>();

            foreach(int n in UnusedNumbers)
            {

            }

            return children;
        }

        public bool IsSovled()
        {
            return SumTest() == 0 && SumPowerTest() == 0;
        }
        #region sums
        /// <summary>
        /// Returns the difference in the regular sums
        /// </summary>
        /// <returns></returns>
        private int SumTest()
        {
            Console.WriteLine("SumTest: {0} == {1}", a.Sum(), b.Sum());
            return (int)Math.Abs(a.Sum() - b.Sum());
        }
        /// <summary>
        /// Returns the difference in the power sums.
        /// </summary>
        /// <returns></returns>
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
        #endregion
        /// <summary>
        /// Smaller is better
        /// </summary>
        /// <returns></returns>
        public int Heuristic()
        {
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
        public bool Equals(Node node)
        {
            foreach(int i in a)
            {
                if(!node.a.Contains(i))
                {
                    return false;
                }
            }
            foreach (int i in b)
            {
                if (!node.b.Contains(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

