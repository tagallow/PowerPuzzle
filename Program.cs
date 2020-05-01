using System;
using System.Collections.Generic;
using System.Linq;

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
            int _k = 4;
            int _n = (int)Math.Pow(2, _k + 1);

            List<int> a = new List<int>();
            List<int> b = new List<int>();
            string seq = FairShareSequence(_n);

            for (int i = 0; i < _n; i++)
            {
                if (seq.ToCharArray()[i] == 'a')
                {
                    a.Add(i);
                }
                else
                {
                    b.Add(i);
                }
            }
            Console.WriteLine(String.Join(", ", a.ToArray()));
            Console.WriteLine(String.Join(", ", b.ToArray()));
            if (IsSolved(a, b, _k))
            {
                Console.WriteLine("correct");
            }
            else
            {
                Console.WriteLine("fail");
            }

            Console.WriteLine("Done");
        }

        private static string FairShareSequence(int n)
        {
            string seq = "ab";
            string seq2 = "";
            while (seq.Length < n)
            {
                foreach (char c in seq.ToCharArray())
                {
                    if (c == 'a')
                    {
                        seq2 += "ab";
                    }
                    else
                    {
                        seq2 += "ba";
                    }
                }
                seq = seq2;
                seq2 = "";
            }

            return seq;

        }
        #region solution checks
        private static bool IsSolved(List<int> a, List<int> b, int _k)
        {
            return SumTest(a, b) && SumPowerTest(a, b, _k);
        }
        private static bool SumTest(List<int> a, List<int> b)
        {
            return a.Sum() == b.Sum();
        }
        private static bool SumPowerTest(List<int> a, List<int> b, int _k)
        {
            List<int> a2 = new List<int>();
            List<int> b2 = new List<int>();

            foreach (int n in a)
                a2.Add((int)Math.Pow(n, _k));

            foreach (int n in b)
                b2.Add((int)Math.Pow(n, _k));

            return a2.Sum() == b2.Sum();
        }
        #endregion

    }
}
