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
            Stopwatch timer = new Stopwatch();
            RandomMeldablePriorityQueue<Node> q = new RandomMeldablePriorityQueue<Node>();
            HashSet<Node> CheckedNodes = new HashSet<Node>();
            Node FirstNode = new Node() { _k = 3, a = new List<int>(), b = new List<int>() };
            q.Add(FirstNode);
            timer.Start();
            while (q.Count > 0)
            {
                Node node = q.Dequeue();
                if (node.IsSovled())
                {
                    timer.Stop();
                    Console.WriteLine("===SOLVED===");
                    node.PrintArrays();
                    Console.WriteLine("Time: {0}", timer.Elapsed.ToString());
                    break;
                }
                else
                {
                    CheckedNodes.Add(node);
                    foreach(Node childNode in node.GetChildren())
                    {
                        if (!q.Contains(childNode) && !CheckedNodes.Contains(childNode))
                        {
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
