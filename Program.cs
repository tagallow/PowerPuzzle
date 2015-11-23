using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace PowerPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve();
        }
        public static void Solve()
        {
            int _k = 3;
            int _n = (int)Math.Pow(2, _k + 1);
            int nodeCount = 0;
            Stopwatch timer = new Stopwatch();
            Stack<Node> q = new Stack<Node>();
            List<Node> Solutions = new List<Node>();
            HashSet<Node> CheckedNodes = new HashSet<Node>();
            Node FirstNode = new Node() { _k = _k, a = new List<int>(), b = new List<int>(), Cost = 0 };
            q.Push(FirstNode);
            timer.Start();
            while (q.Count > 0)
            {
                Node node = q.Pop();
                nodeCount++;
                if (node.IsSovled() && !Solutions.Contains(node))
                {
                    //timer.Stop();
                    Console.WriteLine("===SOLUTION FOUND===");
                    node.PrintArrays();
                    Console.WriteLine("{0:0,000} nodes checked", nodeCount);
                    Console.WriteLine("Time: {0}", timer.Elapsed.ToString());
                    Solutions.Add(node);
                    //break;
                }
                else
                {


                    foreach (Node childNode in node.GetChildren())
                    {
                        if (!q.Contains(childNode))
                        {
                            //if(!CheckedNodes.Contains(childNode))
                            q.Push(childNode);
                        }
                    }
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
