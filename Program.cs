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
            Node n1 = new Node() { _k = 0 };
            Node n2 = new Node() { _k = 3 };
            Node n3 = new Node() { _k = 1 };

            q.Add(n1);
            q.Add(n2);
            q.Add(n3);

            Console.WriteLine(q.Dequeue()._k);
            Console.WriteLine(q.Dequeue()._k);
            Console.WriteLine(q.Dequeue()._k);

            Console.ReadKey();

        }
    }
}
