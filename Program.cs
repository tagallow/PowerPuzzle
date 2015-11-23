using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kts.AStar;
using System.Diagnostics;


namespace PowerPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            Solve();
        }
        public static void QueueTest()
        {
            RandomMeldablePriorityQueue<int> q = new RandomMeldablePriorityQueue<int>();
            q.Add(10);
            q.Add(2);
            q.Add(5);
            q.Add(3);
            q.Add(4);
            q.Add(12);

            while (q.Count > 0)
            {
                Console.WriteLine(q.Dequeue());
            }

            Console.ReadKey();

        }
        public static void Solve()
        {
            int _k = 3;
            int _n = (int)Math.Pow(2, _k + 1);
            int nodeCount = 0;
            Stopwatch timer = new Stopwatch();
            RandomMeldablePriorityQueue<Node> q = new RandomMeldablePriorityQueue<Node>();
            HashSet<Node> CheckedNodes = new HashSet<Node>();
            Node FirstNode = new Node() { _k = _k, a = new List<int>(), b = new List<int>(), Cost = 0 };
            q.Add(FirstNode);
            timer.Start();
            while (q.Count > 0)
            {
                Node node = q.Dequeue();
                nodeCount++;
                if (node.IsSovled())
                {
                    //timer.Stop();
                    Console.WriteLine("===SOLUTION FOUND===");
                    node.PrintArrays();
                    Console.WriteLine("{0:0,000} nodes checked", nodeCount);
                    Console.WriteLine("Time: {0}", timer.Elapsed.ToString());
                    break;
                }
                else
                {
                    foreach (Node childNode in node.GetChildren())
                    {
                        if (!q.Contains(childNode))
                        {
                            //if(!CheckedNodes.Contains(childNode))
                            q.Add(childNode);
                        }
                    }
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
