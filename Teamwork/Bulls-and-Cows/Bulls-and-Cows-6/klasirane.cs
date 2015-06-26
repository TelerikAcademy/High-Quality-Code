using System;
using System.Collections.Generic;
using System.Linq;

public class klasirane
{
    private const int KLASIRANE_RAZMER = 5;
    private static klasirane instance;
    private List<KeyValuePair<string, int>> klasiraneto;
    private klasirane()
    {
        this.klasiraneto = new List<KeyValuePair<string, int>>();
    }
    private void Sort()
    {
        this.klasiraneto.Sort(new Comparison<KeyValuePair<string, int>>(
                                                                        (first, second) => second.Value.CompareTo(first.Value)
                                                                        ));
    }
    public bool IsHighScore(int attempts)
    {
        if (this.klasiraneto.Count < KLASIRANE_RAZMER || this.klasiraneto.Last().Value < attempts)
        {
            return true;
        }
        return false;
    }
    public static klasirane GetInstance()
    {
        if (instance == null)
        {
            instance = new klasirane();
        }
        return instance;
    }
    public void Add(string name, int attempts)
    {
        this.klasiraneto.Add(new KeyValuePair<string, int>(name, attempts));
        Sort();
        if (this.klasiraneto.Count > KLASIRANE_RAZMER)
        {
            this.klasiraneto.RemoveAt(this.klasiraneto.Count - 1);
        }

    }
    public void sort()
    {
        if (this.klasiraneto.Count == 0)
        {
            Console.WriteLine("Scoreboard empty!");
            Console.WriteLine();
            return;
        }
        Sort();
        Console.WriteLine("Scoreboard:");
        for (int index = 0; index < this.klasiraneto.Count; index++)
        {
            string name = this.klasiraneto[index].Key;
            int attempts = this.klasiraneto[index].Value;
            Console.WriteLine("{0}. {1} --> {2} guesses", index + 1, name, attempts);
        }
        Console.WriteLine();
    }
}

