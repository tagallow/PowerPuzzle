using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kts.AStar;


namespace PowerPuzzle
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomMeldablePriorityQueue<Node> q = new RandomMeldablePriorityQueue<Node>();
            Node FirstNode = new Node() { _k = 3, a = new List<int>(), b = new List<int>() };
            q.Add(FirstNode);
            while (q.Count > 0)
            {
                Node node = q.Dequeue();
                if (node.IsSovled())
                {
                    Console.WriteLine("===SOLVED===");
                    node.PrintArrays();
                    break;
                }
                else
                {
                    foreach(Node childNode in node.GetChildren())
                    {
                        q.Add(childNode);
                    }
                }
            }

            Console.WriteLine("Done");
            Console.ReadKey();

        }
    }
}
