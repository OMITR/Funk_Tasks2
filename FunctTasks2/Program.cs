using System;
using System.Collections;
using System.Collections.Generic;

namespace FunctTasks2
{
    class Program
    {
        static void Main(string[] args)
        {
            Task4();
        }

        private static void Task1()
        {
            string[] str = Console.ReadLine().Split(" ");

            Func<string[], int[]> parse = strs =>
            {
                int[] ints = new int[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    ints[i] = Int32.Parse(strs[i]);
                }
                return ints;
            };

            int[] array = parse(str);

            Func<int[], int[]> add = ints =>
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i]++;
                }
                return ints;
            };

            Func<int[], int[]> multiply = ints =>
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i] = ints[i] * 2;
                }
                return ints;
            };

            Func<int[], int[]> substract = ints =>
            {
                for (int i = 0; i < ints.Length; i++)
                {
                    ints[i]--;
                }
                return ints;
            };

            Action<int[]> print = ints =>
            {
                Console.WriteLine(string.Join(" ", ints));
            };

            string command = "";

            while (command != "end")
            {
                command = Console.ReadLine();

                switch (command)
                {
                    case "add":
                        add(array);
                        break;
                    case "multiply":
                        multiply(array);
                        break;
                    case "substract":
                        substract(array);
                        break;
                    case "print":
                        print(array);
                        break;
                }
            }
        }

        private static void Task2()
        {
            string[] str = Console.ReadLine().Split(" ");

            List<int> intsList = new List<int>();
            for (int s = 0; s < str.Length; s++)
            {
                intsList.Add(s);
            }

            Func<List<int>, List<int>> reverseAndRemove = ints =>
            {
                intsList.Reverse();
                int condition = Int32.Parse(Console.ReadLine());
                for (int i = 0; i < ints.Count; i++)
                {
                    if (ints[i] % condition == 0)
                    {
                        ints.Remove(ints[i]);
                        i--;
                    }
                }
                return ints;
            };

            Console.WriteLine(string.Join(" ", reverseAndRemove(intsList)));
        }

        private static void Task3()
        {
            int wordLength = Int32.Parse(Console.ReadLine());
            string str = Console.ReadLine();

            List<string> strsList = new List<string>(str.Split(" "));

            Func<int, List<string>, List<string>> getWords = (maxLength, strs) =>
            {
                for (int i = 0; i < strs.Count; i++)
                {
                    if (strs[i].Length > maxLength)
                    {
                        strs.Remove(strs[i]);
                    }
                }
                return strs;
            };

            Console.WriteLine(string.Join(" ", getWords(wordLength, strsList)));
        }

        private static void Task4()
        {
            string[] str = Console.ReadLine().Split(" ");

            Func<string[], int[]> parse = strs =>
            {
                int[] ints = new int[strs.Length];
                for (int i = 0; i < strs.Length; i++)
                {
                    ints[i] = Int32.Parse(strs[i]);
                }

                return ints;
            };

            var comparer = Comparer<int>.Create((x, y) =>
            {
                if (x % 2 == 0 && y % 2 != 0)
                    return -1;
                if (x % 2 != 0 && y % 2 == 0)
                    return 1;
                return x.CompareTo(y);
            });

            var num = parse(str);
            Array.Sort(num, comparer);

            Console.WriteLine(string.Join(" ", num));
        }
    }
}
