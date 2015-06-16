using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

class StopwatchDemo
{
    static void DisplayExecutionTime(Action action)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        action();
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed);
    }

    static void Main()
    {
        string str = new string('a', 5000000);

        Console.Write("Traditional for-loop:\t");
        DisplayExecutionTime(() =>
        {
            int count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == 'a')
                {
                    count++;
                }
            }
        });

        Console.Write("Optimized for-loop:\t");
        DisplayExecutionTime(() =>
        {
            int count = 0;
            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                if (str[i] == 'a')
                {
                    count++;
                }
            }
        });

        Console.Write("Foreach-loop:\t\t");
        DisplayExecutionTime(() =>
        {
            int count = 0;
            foreach (var ch in str)
            {
                if (ch == 'a')
                {
                    count++;
                }
            }
        });

        Console.WriteLine();

        Console.Write("new String(): \t\t");
        DisplayExecutionTime(() =>
        {
            string s = new String('a', 20000000);
        });

        Console.Write("char[]: \t\t");
        DisplayExecutionTime(() =>
        {
            char[] chars = new char[20000000];
            for (int i = 0; i < 20000000; i++)
            {
                chars[i] = 'a';
            }
        });

        Console.Write("byte[]: \t\t");
        DisplayExecutionTime(() =>
        {
            byte[] bytes = new byte[20000000];
            byte byteA = (byte)'a';
            for (int i = 0; i < 20000000; i++)
            {
                bytes[i] = byteA;
            }
        });

        Console.Write("StringBuilder: \t\t");
        DisplayExecutionTime(() =>
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 20000000; i++)
            {
                sb.Append('a');
            }
        });

        Console.Write("Enumerable.Repeat(): \t");
        DisplayExecutionTime(() =>
        {
            char[] chars = Enumerable.Repeat('a', 20000000).ToArray();
        });
    }
}
