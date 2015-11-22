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
            //RandomMeldablePriorityQueue<Node> q = new RandomMeldablePriorityQueue<Node>();
            Stack<Node> stack = new Stack<Node>();
            List<Node> Solutions = new List<Node>();
            //HashSet<Node> CheckedNodes = new HashSet<Node>();
            Node FirstNode = new Node() { _k = 3, a = new List<int>(), b = new List<int>() };
            stack.Push(FirstNode);
            timer.Start();
            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                if (node.IsSovled() && !Solutions.Contains(node))
                {
                    timer.Stop();
                    Console.WriteLine("===SOLUTION FOUND===");
                    node.PrintArrays();
                    //Console.WriteLine("{0:0,000} nodes checked", CheckedNodes.Count);
                    Console.WriteLine("Time: {0}", timer.Elapsed.ToString());
                    Solutions.Add(node);
                    //break;
                }
                else
                {
                    //CheckedNodes.Add(node);
                    foreach(Node childNode in node.GetChildren())
                    {
                        if (!stack.Contains(childNode))
                        {
                            stack.Push(childNode);
                        }
                    }
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
