using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PowerPuzzle
{
    public class Node : IEquatable<Node>
    {
        public int _k { get; set; }
        public int Cost { get; set; }
        public List<int> a { get; set; }
        public List<int> b { get; set; }
        //private Node _Parent;

        public Node() { }
        /// <summary>
        /// Each child node will start as a clone of the parent
        /// </summary>
        /// <param name="parent"></param>
        public Node(Node parent) 
        {
            //_Parent = parent;
            _k = parent._k;
            a = new List<int>(parent.a);
            b = new List<int>(parent.b);
            Cost = 0;//parent.Cost + 1;

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
                Node newNode = new Node(this);
                newNode.a.Add(n);
                children.Add(newNode);

                newNode = new Node(this);
                newNode.b.Add(n);
                children.Add(newNode);
            }

            return children;
        }

        public bool IsSovled()
        {
            if (GetUnusedNumbers().Count == 0 && 
                a.Count == b.Count &&
                SumTest() == 0 && 
                SumPowerTest() == 0)
            {
                return true;
            }
            return false;
        }
        #region sums
        /// <summary>
        /// Returns the difference in the regular sums
        /// </summary>
        /// <returns></returns>
        private int SumTest()
        {
            //Console.WriteLine("SumTest: {0} == {1}", a.Sum(), b.Sum());
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

            //Console.WriteLine("SumPowerTest: {0} == {1}", a2.Sum(), b2.Sum());
            return (int)Math.Abs(a2.Sum() - b2.Sum());
        }
        #endregion
        /// <summary>
        /// Smaller is better
        /// </summary>
        /// <returns></returns>
        public int Heuristic()
        {
            int result = GetUnusedNumbers().Count+SumTest();
            return result;
        }

        public void PrintArrays()
        {
            Console.WriteLine(String.Join(", ", a.ToArray()));
            Console.WriteLine(String.Join(", ", b.ToArray()));
        }
        
        public bool Equals(Node node)
        {
            bool isEqual = true;
            foreach(int i in a)
            {
                if(!node.a.Contains(i))
                {
                    isEqual = false;
                    break;
                }
            }
            if (isEqual)
            {
                foreach (int i in b)
                {
                    if (!node.b.Contains(i))
                    {
                        isEqual = false;
                        break;
                    }
                }
            }
            //nodes are also equal in a mirror situation, where b==a AND a==b
            if(!isEqual)
            {
                isEqual = true;
                foreach (int i in a)
                {
                    if (!node.b.Contains(i))
                    {
                        isEqual = false;
                        break;
                    }
                }
                if (isEqual)
                {
                    foreach (int i in b)
                    {
                        if (!node.a.Contains(i))
                        {
                            isEqual = false;
                            break;
                        }
                    }
                }

            }

            return isEqual;
        }
    }
}

